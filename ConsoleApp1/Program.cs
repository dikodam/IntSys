using System;

namespace ConsoleApp1
{
    // Aufgabe 1: Geeigneter Delegate
    public delegate void RechenOperation(double a, double b);

    internal class Program
    {
        private static void Main(string[] args)
        {
            var operand1 = RequestUserInput("Ersten Operand: ");
            var operand2 = RequestUserInput("Zweiten Operand: ");

            // Aufgabe 2: Erstelle Multicast Delegaten...
            // ...via Operatoren
            RechenOperation meineOperation = Addiere;
            meineOperation += Multipliziere;

            // ...via Methode der Klasse Delegate
            RechenOperation add = Addiere;
            RechenOperation mult = Multipliziere;
            Delegate[] delArr = { meineOperation, add, mult };
            meineOperation = (RechenOperation)Delegate.Combine(delArr);

            // ...via Anonyme Methode
            meineOperation += ((double a, double b) => { Console.WriteLine($"Summe:   {a} + {b} = {a + b}"); });
            meineOperation += ((double a, double b) => { Console.WriteLine($"Produkt: {a} * {b} = {a * b}"); });

            meineOperation(operand1, operand2);
            Console.ReadLine();

        }

        private static double RequestUserInput(string askFor)
        {
            double operand = Double.MinValue;
            try
            {
                Console.Write(askFor);
                operand = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message}");
                Environment.Exit(0);
            }
            return operand;
        }

        private static void Addiere(double op1, double op2) { Console.WriteLine($"Summe:   {op1} + {op2} = {op1 + op2}"); }
        private static void Multipliziere(double op1, double op2) { Console.WriteLine($"Produkt: {op1} * {op2} = {op1 * op2}"); }
    }
}
