using System;
using System.IO;

namespace Task1.Tests
{
    internal class Program
    {
        internal static void PrintFile(string file)
        {
            Console.WriteLine($"\"{file}\" file contents:");

            using StreamReader reader = new(file);

            string line;

            while ((line = reader.ReadLine()) is not null)
            {
                Console.WriteLine($"\t{line}");
            }

            Console.WriteLine();
        }

        internal static void Main(string[] args)
        {
            TestClass testClass = new();
            TestStruct testStruct = new(23, true);

            Logger classLogger = new("class.json");
            Logger structLogger = new("struct.json");
            
            classLogger.Track(testClass);
            structLogger.Track(testStruct);

            PrintFile(classLogger.JsonFile);
            PrintFile(structLogger.JsonFile);
        }
    }
}
