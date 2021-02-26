using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Training
    {
        //The storage of training lessons (lectures and practices).

        private Lesson[] _lessons;

        //Additional data for adding algorithm.

        private const int alpha = 2;
        private int capacity;

        public int Length { get; private set; }

        //Practical training property.
        public bool IsPractical { get; private set; } = true;

        public Training(params Lesson[] lessons)
        {
            _lessons = lessons;

            capacity = lessons.Length;
            Length = lessons.Length;

            //Check if the training is practical.

            if (lessons != null)
            {
                foreach (Lesson lesson in lessons)
                {
                    if (lesson is Lecture)
                    {
                        IsPractical = false;
                        break;
                    }
                }
            }
        }

        //Simple lessons accessor.
        public Lesson GetLesson(int i)
        {
            if (i >= Length)
            {
                return null;
            }

            return _lessons[i];
        }

        //Adding method.
        public void Add(Lesson lesson)
        {
            if (IsPractical && lesson is Lecture)
            {
                IsPractical = false;
            }

            /*  A convenient algorithm to increase the capacity
                of the array and decrease the cost of coping
                without usage of list. */

            if (capacity == Length)
            {
                capacity *= alpha;

                Lesson[] _newLessons = new Lesson[capacity];
                Array.Copy(_lessons, _newLessons, Length);

                _newLessons[Length] = lesson;
                _lessons = _newLessons;
            }
            else
            {
                _lessons[Length] = lesson;
            }

            Length++;
        }

        /* Deep cloning of training lessons array 
         * (exclude private info about current capacity of the array). */
        public Training Clone()
        {
            Lesson[] _newLessons = new Lesson[Length];
            
            for (int i = 0; i < Length; i++)
            {
                _newLessons[i] = _lessons[i].Clone();
            }

            return new Training(_newLessons);
        }

        //Override ToString for convenient testing.
        public override string ToString()
        {
            StringBuilder training = new StringBuilder(
                $"Practical training: {IsPractical}\nLength, lessons: {Length}\n" +
                $"Program:\n");

            for (int i = 0; i < Length; i++)
            {
                training.Append(_lessons[i]);
            }

            return training.ToString();
        }
    }
}
