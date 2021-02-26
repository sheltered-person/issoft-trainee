using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input values.
            double t, v;

            Console.Write("Enter temperature, C: ");
            t = double.Parse(Console.ReadLine());

            Console.Write("Enter wind velocity, m/s: ");
            v = double.Parse(Console.ReadLine());

            //Convertation to F and mph.
            const double fFactor = 1.8, 
                fTerm = 32.0, 
                mphFactor = 0.44704;

            t = t * fFactor + fTerm;
            v /= mphFactor;

            //Counting the effective temperature.
            const double wTerm1 = 35.74, 
                wFactor1 = 0.6215,
                wFactor2 = 0.4275, 
                wTerm2 = 35.75, 
                wDegree = 0.16;

            double w = wTerm1 + wFactor1 * t + (wFactor2 * t - wTerm2) * Math.Pow(v, wDegree);
            w = (w - fTerm) / fFactor;

            //Output results.
            Console.WriteLine($"Effective temperature, C: {w}");
            
            if (Math.Abs(t) > 50 || v > 120 || v < 3)
            {
                Console.WriteLine("The result may contain an error.");
            }
        }
    }
}
