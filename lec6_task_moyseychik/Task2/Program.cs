using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Init some practical training.
            Lesson[] lessons =
            {
                new Practice(),
                new Practice(description: "Classes practice task"),
                new Practice(taskLink: @"https://drive.google.com/drive/task", 
                    solutionLink: @"https://drive.google.com/drive/solution")
            };

            Training training2020 = new(lessons);
            Console.WriteLine($"Trainging 2020: \n\n{training2020}");

            //Testing of addition method.
            Lecture lecture = new(topic: "Generics");

            training2020.Add(lecture);
            Console.WriteLine($"\nModified training 2020: \n\n{training2020}");

            //Testing of cloning.
            Training training2021 = training2020.Clone();
            Console.WriteLine($"\nNew 2021 training: \n\n{training2021}");

            //Test if arrays of two trainings are the same or the copy.
            Console.WriteLine("\nShowing the difference between training 2020 and 2021 array:\n");
            training2021.Add(new Lecture());

            Console.WriteLine(training2020);
            Console.WriteLine(training2021);
        }
    }
}
