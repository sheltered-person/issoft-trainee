using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        //Test class.
        class A
        {
            private string hello;

            public string OK;

            public string TestString { get; }

            private string PrivateString { get; set; }

            public string EmptyString { get; set; }

            private int someInt;

            public double SomeDouble { get; set; }

            public override string ToString()
            {
                return $"hello = {hello}\n" +
                       $"OK = {OK}\n" +
                       $"TestString (without set) = {TestString}\n" +
                       $"PrivateString = {PrivateString}\n" +
                       $"EmptyString = {EmptyString}\n" +
                       $"someInt = {someInt}\n" +
                       $"SomeDouble = {SomeDouble}";
            }
        }

        internal static void Main(string[] args)
        {
            Dictionary<string, string> data = new()
            {
                ["HELLO"] = "hello string",
                ["ok"] = "OK STRING",
                ["privatestring"] = "private string",
                ["TestString"] = "tested",
                ["someint"] = "32",
                ["somedouble"] = "-13.01"
            };

            SimpleBinder binder = SimpleBinder.GetBinder();

            A a = binder.Bind<A>(data);

            Console.WriteLine(a);
        }
    }
}
