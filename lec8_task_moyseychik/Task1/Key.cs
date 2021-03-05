using System;

namespace Task1
{
    public struct Key : IComparable<Key>
    {
        public Octave Octave { get; }

        public Note Note { get; }

        public Accidental Accidental { get; }

        public Key(Note note, Accidental accidental, Octave octave)
        {
            if (!Enum.IsDefined(typeof(Note), note)
                || !Enum.IsDefined(typeof(Accidental), accidental)
                || !Enum.IsDefined(typeof(Octave), octave))
            {
                throw new ArgumentException("Error: agruments contain some invalid value.");
            }

            if (octave == Octave.Subcontra && note < Note.A
                || octave == Octave.Fifth && note > Note.C)
            {
                throw new ArgumentException("Error: no such key on the keyboard.");
            }

            Octave = octave;
            Note = note;
            Accidental = accidental;
        }

        //Equals method, based on the key number on the keyboard.
        public override bool Equals(object obj)
        {
            if (obj is Key key)
            {
                int hash1 = GetHashCode(),
                    hash2 = key.GetHashCode();

                return hash1 == hash2;
            }

            return false;
        }

        /* Due to enums specification hashcode represents key number on piano keyboard.
         * Assume that each octave has 12 keys on the keyboard. */
        public override int GetHashCode()
        {
            return (int)Note + (int)Accidental + (int)Octave;
        }

        public override string ToString()
        {
            return $"{Note} {Accidental}, {Octave} octave";
        }

        /* Return: 0 - if keys are the same, 1 - if this key lies higher, else -1 */
        public int CompareTo(Key other)
        {
            int hash1 = GetHashCode(),
                hash2 = other.GetHashCode();

            return hash1 - hash2;
        }
    }
}
