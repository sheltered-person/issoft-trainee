using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    //IEquatable is used here for correct Contains and Remove Catalog methods.
    public class Book : IEquatable<Book>
    {
        public string Title { get; }
        public DateTime? PublicationDate { get; init; }

        private readonly SortedSet<string> _authors;
        public IEnumerable<string> Authors => _authors.ToList();

        public Book(string title, DateTime? publicationDate = null, 
            params string[] authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Book title can't be null or empty string.");
            }

            Title = title;
            PublicationDate = publicationDate;

            if (authors is not null)
            {
                _authors = new(authors);
            }
        }

        public override string ToString()
        {
            StringBuilder authors = new();

            foreach (string author in _authors)
            {
                authors.Append($"\n\t{author}");
            }

            return $"Title: {Title}\n" +
                $"Publication: {PublicationDate?.ToString() ?? "-"}\n" +
                $"Authors: {authors}\n";
        }

        //Interface method.
        public bool Equals(Book other)
        {
            if (Equals(Title, other.Title) && 
                Equals(PublicationDate, other.PublicationDate))
            {
                if ((_authors is null && other._authors is null) ||
                    _authors.SetEquals(other._authors))
                {
                    return true;
                }
            }

            return false;
        }

        //Overrided in addition to IEquatable interface.
        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return Equals(book);
            }

            throw new InvalidCastException("Object doesn't represent a book.");
        }

        public override int GetHashCode()
        {
            int hash = Title.GetHashCode()
               + PublicationDate?.GetHashCode() ?? 0;

            foreach (string author in _authors)
            {
                hash += author.GetHashCode();
            }

            return hash;
        }
    }
}
