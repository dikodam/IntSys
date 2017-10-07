using System;

namespace ConsoleApp2
{
    internal delegate void StudentDel();

    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = new Student { Matrikelnummer = 123456 };
            s.StudentEvent += () => throw new Exception("Ungültige Nummer");

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
