using System;

namespace Task2
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Classifier classifier = new("data.txt", ',');
            Console.WriteLine(classifier.GetClass(8.0, 6.0, 17));
        }
    }
}
