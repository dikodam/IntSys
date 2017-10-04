using System;

namespace ConsoleApp1
{
    public delegate void RechenOperation(double a, double b);

    internal class Program
    {
        private static void Main(string[] args)
        {
            RechenOperation meineOperation = null;
            try
            {
                Console.Write("Ersten Operand: ");
                var operand1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Zweiten Operand: ");
                var operand2 = Convert.ToDouble(Console.ReadLine());

                meineOperation += Addiere;
                meineOperation += Multipliziere;

                RechenOperation add = Addiere;
                RechenOperation mult = Multipliziere;
                Delegate[] delArr = { meineOperation, add, mult };
                meineOperation = (RechenOperation)Delegate.Combine(delArr);

                meineOperation += ((double a, double b) => { Console.WriteLine(a + b); });
                meineOperation += ((double a, double b) => { Console.WriteLine(a * b); });

                meineOperation(operand1, operand2);
                Console.ReadLine();
            }
            catch (FormatException) { Console.WriteLine("Falsche Eingabe"); }
        }

        private static void Addiere(double op1, double op2) { Console.WriteLine(op1 + op2); }
        private static void Multipliziere(double op1, double op2) { Console.WriteLine(op1 * op2); }
    }
}
