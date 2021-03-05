using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Key empty = new();
            Console.WriteLine(empty);

            //Example from the task.
            Key cs = new(Note.C, Accidental.Sharp, Octave.First);
            Console.WriteLine(cs);

            Key df = new(Note.D, Accidental.Flat, Octave.First);

            //Preferable to use CompareTo to avoid boxing here.
            Console.WriteLine(cs.Equals(df));
            Console.WriteLine(cs.CompareTo(df));

            //Some more examples with different keys.
            Key a = new(Note.A, Accidental.None, Octave.Contra);

            int comparing = cs.CompareTo(a);

            if (comparing == 0)
            {
                Console.WriteLine($"Keys \"{cs}\" and \"{a}\" are the same.");
            }
            else if (comparing < 0)
            {
                Console.WriteLine($"Key \"{a}\" lies to the right of \"{cs}\".");
            }
            else
            {
                Console.WriteLine($"Key \"{a}\" lies to the left of \"{cs}\".");
            }

            try
            {
                Console.WriteLine("\nAn attempt to init some invalid keys:");
                Key invalidKey = new(Note.E, Accidental.None, (Octave)10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
