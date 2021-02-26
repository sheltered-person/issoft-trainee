using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /* Lecture lesson with the topic. 
     * Init modifier used to save the encapsulation priciple.*/

    public class Lecture : Lesson
    {
        public string Topic { get; init; }

        public Lecture(string description = null, string topic = null) : base(description)
        {
            Topic = topic;
        }

        public override string ToString()
        {
            return $"Lecture\n" +
                $"\tTopic: {Topic ?? "-"}\n" +
                $"\tDescription: {Description ?? "-"}\n";
        }

        public override Lecture Clone()
        {
            return new Lecture(Description, Topic);
        }
    }
}
