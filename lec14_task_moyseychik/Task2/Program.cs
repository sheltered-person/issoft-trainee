using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book sandmanBook, martinEdenBook, lordOfFliesBook;

            try
            {
                sandmanBook = new("Sandman", null,
                    "Nil Geiman", "Yositaka Amano");

                martinEdenBook = new("Martin Eden", DateTime.Parse("01/09/1909"),
                    "Jack London");

                lordOfFliesBook = new("Lord of Flies", null,
                    "William Golding");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Catalog catalog = new();

            try
            {
                catalog.Add("123-4-56-789012-3", sandmanBook);
                catalog.Add("111-2-33-444444-5", martinEdenBook);

                ShowCatalog(catalog);

                if (catalog.ContainsKey("1112334444445"))
                {
                    Console.WriteLine($"\n{catalog["1112334444445"]}");
                }
                
                catalog["111-2-33-444444-5"] = lordOfFliesBook;

                if (!catalog.Contains(new("111-2-33-444444-5", martinEdenBook)))
                {
                    Console.WriteLine($"Key 111-2-33-444444-5 was modified! New value:\n");
                    Console.WriteLine(catalog["1112334444445"]);
                }

                ShowCatalog(catalog);
                catalog.Remove("1234567890123");
                catalog.Remove(new KeyValuePair<string, Book>("1112334444445", lordOfFliesBook));
                ShowCatalog(catalog);

                catalog.Add("1112334444445", sandmanBook);
                catalog.Add("1112334444445", martinEdenBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
        }

        static void ShowCatalog(Catalog catalog)
        {
            Console.WriteLine("Current catalog:");

            foreach (KeyValuePair<string, Book> entry in catalog)
            {
                Console.WriteLine($"\tISBN : {entry.Key}. Book: {entry.Value.Title}.");
            }
        }
    }
}
