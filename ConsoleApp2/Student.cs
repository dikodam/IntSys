using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        protected int matrikelnummer;

        public int Matrikelnummer
        {
            get { return matrikelnummer; }
            set
            {
                if (value.ToString().Length != 6)
                {
                    StudentEvent?.Invoke();
                }
                else
                {
                    matrikelnummer = value;
                }
            }
        }

        public event StudentDel StudentEvent;
    }
}
