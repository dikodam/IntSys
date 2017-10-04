using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    delegate void StudentDel();
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student() { Matrikelnummer = 123456 };
            s.StudentEvent += () => { throw new Exception("Ungültige Nummer"); };

            while (true)
            {
                Console.WriteLine("M-Nummer:");
                try
                {
                    s.Matrikelnummer = Convert.ToInt32(Console.ReadLine());
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
