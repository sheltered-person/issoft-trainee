using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //The top of the lessons hierarchy - some abstract lesson with the description.
    public abstract class Lesson
    {
        public string Description { get; init; }

        public Lesson(string description = null)
        {
            Description = description;
        }

        //public abstract Lesson Clone();
    }
}
