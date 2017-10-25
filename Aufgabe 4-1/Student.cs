using System;

namespace Aufgabe_4_1
{
    internal class Student
    {
        protected int EineMatrikelnummer;

        public int Matrikelnummer
        {
            get => EineMatrikelnummer;
            set
            {
                if (value.ToString().Length != 6)
                    throw new ArgumentException();
                else
                    EineMatrikelnummer = value;
            }
        }
    }
}
