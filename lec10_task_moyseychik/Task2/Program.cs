using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //One try-catch is used because og the little peace of testing code here.
            try
            {
                Segment segment1 = (3, -1),
                    segment2 = new(-1, 3),
                    segment3 = (3, 8);

                Console.WriteLine($"1. {segment1}, hash {segment1.GetHashCode()}, " +
                    $"length {(uint)segment1}");

                Console.WriteLine($"2. {segment2}, hash {segment2.GetHashCode()}, " +
                    $"length {(uint)segment2}");

                Console.WriteLine($"3. {segment3}, hash {segment3.GetHashCode()}, " +
                    $"length {(uint)segment3}");

                Console.WriteLine($"\nEquality of segments #1 and #2: {segment1.Equals(segment2)}");
                Console.WriteLine($"Sum of segments #1 and #3: {segment1 + segment3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
