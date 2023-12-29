using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Helper;
using CalculatorLibrary;

namespace App 
{
    class Program {
        static void Main(string[] args) 
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            bool endApp = false;
            Calculator calculator = new Calculator();

            while (!endApp)
            {
                string opt;
                string num1 = "";
                string num2 = "";
                double cleanNum1 = 0;
                double cleanNum2 = 0;
                double result = 0;

                num1 = CalculatorHelper.GetInput("First number -> ");
                while (!double.TryParse(num1, out cleanNum1))
                {
                    Console.WriteLine("Invalid input. Try again");
                    num1 = CalculatorHelper.GetInput("First number -> ");
                }

                num2 = CalculatorHelper.GetInput("Second number -> ");
                while (!double.TryParse(num2, out cleanNum2))
                {
                    Console.WriteLine("Invalid input. Try again");
                    num2 = CalculatorHelper.GetInput("First number -> ");
                }

                Console.WriteLine("\nChoose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\te - Exit");

                opt = CalculatorHelper.GetInput("Option -> ");

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, opt); 
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.Write("Your result: {0:0.##}", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                if (opt.ToLower() == "e") endApp = true;
                CalculatorHelper.Clear();
            }

            calculator.Finish();
            return;
        }
    }
}