using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Task2
{
    //Dictionary-based collection on hash table with chain collision resolution.
    public class Catalog : IDictionary<string, Book>
    {
        private int tableSize = 256;

        private List<KeyValuePair<string, Book>>[] table;

        private int count;

        public Catalog()
        {
            Clear();
        }

        //IDictionary interface methods.
        public Book this[string key] 
        { 
            get
            {
                string formattedKey = FormatISBN(key);
                int hash = GetHash(formattedKey);
                int position = FindEntry(hash, formattedKey);

                return table[hash][position].Value;
            }

            set
            {
                string formattedKey = FormatISBN(key);
                int hash = GetHash(formattedKey);
                int position = FindEntry(hash, formattedKey);

                table[hash][position] = new(formattedKey, value);
            }
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(string key, Book value)
        {
            string formattedKey = FormatISBN(key);
            int hash = GetHash(formattedKey);

            try
            {
                int position = FindEntry(hash, formattedKey);
            }
            catch (KeyNotFoundException)
            {
                KeyValuePair<string, Book> entry = new(formattedKey, value);

                table[hash].Add(entry);
                count++;

                return;
            }

            throw new ArgumentException($"A book with the same ISBN " +
                $"has already been added. Key: {key}.");
        }

        public void Add(KeyValuePair<string, Book> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            count = 0;
            table = new List<KeyValuePair<string, Book>>[tableSize];

            for (int i = 0; i < tableSize; i++)
            {
                table[i] = new();
            }
        }

        public bool Contains(KeyValuePair<string, Book> item)
        {
            string formattedKey = FormatISBN(item.Key);
            int hash = GetHash(formattedKey);

            try
            {
                int position = FindEntry(hash, formattedKey);
                return table[hash][position].Value.Equals(item.Value);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public bool ContainsKey(string key)
        {
            string formattedKey = FormatISBN(key);

            try
            {
                FindEntry(GetHash(formattedKey), formattedKey);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public IEnumerator<KeyValuePair<string, Book>> GetEnumerator()
        {
            foreach (List<KeyValuePair<string, Book>> row in table)
            {
                foreach (KeyValuePair<string, Book> entry in row)
                {
                    yield return entry;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(string key)
        {
            string formattedKey = FormatISBN(key);
            int hash = GetHash(formattedKey);

            try
            {
                int position = FindEntry(hash, formattedKey);

                table[hash].RemoveAt(position);
                count--;

                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public bool Remove(KeyValuePair<string, Book> item)
        {
            string formattedKey = FormatISBN(item.Key);
            int hash = GetHash(formattedKey);

            try
            {
                int position = FindEntry(hash, formattedKey);

                if (table[hash][position].Value.Equals(item.Value))
                {
                    table[hash].RemoveAt(position);
                    count--;

                    return true;
                }
            }
            catch (KeyNotFoundException)
            { }

            return false;
        }

        //Not implemented functionality of the IDictionary interface.
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out Book value) 
            => throw new NotImplementedException();

        public void CopyTo(KeyValuePair<string, Book>[] array, int arrayIndex)
            => throw new NotImplementedException();

        public ICollection<string> Keys => throw new NotImplementedException();

        public ICollection<Book> Values => throw new NotImplementedException();

        //ISBN format checker.
        private string FormatISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentNullException("ISBN can't be null or empty.");
            }

            Regex checker = new(@"^\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}$",
                RegexOptions.Compiled);

            if (!checker.IsMatch(isbn))
            {
                throw new ArgumentException($"Invalid ISBN format. Key {isbn}.");
            }

            return isbn.Replace("-", "");
        }

        //Hash function for the table.
        private int GetHash(string key)
        {
            int hash = 0;

            foreach (char c in key)
            {
                hash += c;
            }

            hash %= tableSize;
            return hash < 0 ? hash + tableSize : hash;
        }

        //Find the required entry position or throws the exception.
        private int FindEntry(int hash, string key)
        {
            if (table[hash].Count == 0)
            {
                throw new KeyNotFoundException($"No such ISBN in the catalog. Key {key}.");
            }

            for (int i = 0; i < table[hash].Count; i++)
            {
                if (table[hash][i].Key == key)
                {
                    return i;
                }
            }

            throw new KeyNotFoundException($"No such ISBN in the catalog. Key {key}.");
        }
    }
}
