using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace Task2
{
    //k-NN classifier class
    public class Classifier
    {
        private List<(string name, double x, double y)> _data;

        public string File { get; }

        public char Delimiter { get; }

        //Takes path to file and delimiter of values in file string.
        public Classifier(string file, char delimiter)
        {
            File = file;
            Delimiter = delimiter;
            _data = new();
            
            LoadDataFromFile();
        }

        //Counts class of (x, y) point by k nearest neighbors.
        public string GetClass(double x, double y, int k)
        {
            if (k <= 0 || k > _data.Count)
            {
                throw new ArgumentException($"K parameter can't be negative, zero " +
                    $"or more than train dataset size ({_data.Count})");
            }

            Distance[] distance = new Distance[_data.Count];

            Parallel.For(0, _data.Count, i =>
            {
                distance[i] = new(i, (x, y), (_data[i].x, _data[i].y));
            });

            IEnumerable<string> result = distance
                .OrderBy(dist => dist.SquaredDistance)
                .Take(k)
                .GroupBy(dist => _data[dist.Index].name)
                .OrderBy(group => group.Count())
                .TakeLast(1)
                .Select(group => group.Key);

            return result.ElementAt(0);
        }

        //Data loader from text file.
        private void LoadDataFromFile()
        {
            using StreamReader reader = new(File);

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                _data.Add(ParseLine(line));
            }
        }

        //File lin parser.
        private (string, double, double) ParseLine(string line)
        {
            string[] parts = line.Split(Delimiter);

            if (parts.Length != 3)
            {
                throw new FormatException($"String {line} of the file {File}" +
                    $" has wrong format. Use format: string{Delimiter}double{Delimiter}double");
            }

            return (parts[0], double.Parse(parts[1]), 
                double.Parse(parts[2]));
        }
    }
}
