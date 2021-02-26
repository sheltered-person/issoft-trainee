using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Practical lesson with text links for the task and solution.

    public class Practice : Lesson
    {
        public string TaskLink { get; init; }

        public string SolutionLink { get; init; }

        public Practice(string description = null, string taskLink = null, 
            string solutionLink = null) : base(description) 
        {
            TaskLink = taskLink;
            SolutionLink = solutionLink;
        }

        public override string ToString()
        {
            return $"Practice\n" +
                $"\tDescription: {Description ?? "-"}\n" +
                $"\tTask: {TaskLink ?? "-"}\n" +
                $"\tSolution: {SolutionLink ?? "-"}\n";
        }

        public override Practice Clone()
        {
            return new Practice(Description, TaskLink, SolutionLink);
        }
    }
}
