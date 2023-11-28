using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Consolicator
{
    internal class Program
    {
        string stringOperation = string.Empty;
        decimal? currentValue = null;
        string currentCalculationText = string.Empty;
        string firstNumber = string.Empty;
        string secondNumber = string.Empty;
        bool firstOperation = true;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Consolicator!");
            Console.WriteLine();

            var calc = new Program();
            calc.Run();
        }

        public void Run()
        {
            while (stringOperation.ToLower() != "x")
            {
                if (firstOperation)
                {
                    Console.WriteLine("Please type an operation ( 1 + 1 ) or 'x' to exit:");
                }
                else
                {
                    Console.WriteLine("{0} = {1}", currentCalculationText, currentValue);
                    Console.WriteLine("Please expand the calculation ( + 1 ) or 'x' to exit:");
                    Console.Write("{0}", currentValue);
                }

                string input = Console.ReadLine();
                stringOperation = CleanInput(input);

                if (stringOperation == "x")
                {
                    break;
                }

                string operat = GetOperator(stringOperation);
                if (operat == string.Empty)
                {
                    Console.WriteLine("Invalid operator. You can use: | + | - | * | / | ^ | ! |");
                    Console.Clear();
                    Run();
                }

                firstNumber = GetFirstNumber(stringOperation, operat);
                secondNumber = GetSecondNumber(stringOperation, operat);

                bool parsedFirst = decimal.TryParse(firstNumber, out decimal firstDecimal);
                bool parsedSecond = decimal.TryParse(secondNumber, out decimal secondDecimal);

                switch (operat)
                {
                    case "+":
                        if (parsedFirst && parsedSecond)
                        {
                            currentValue = firstDecimal + secondDecimal;
                            CalculationHistory(firstNumber, operat, secondNumber);
                        }
                        else
                        {
                            ErrorReRun("The number is not correct.", true);
                        }
                        break;
                    case "-":
                        if (parsedFirst && parsedSecond)
                        {
                            currentValue = firstDecimal - secondDecimal;
                            CalculationHistory(firstNumber, operat, secondNumber);
                        }
                        else
                        {
                            ErrorReRun("The number is not correct.", true);
                        }
                        break;
                    case "*":
                        if (parsedFirst && parsedSecond)
                        {
                            currentValue = firstDecimal * secondDecimal;
                            CalculationHistory(firstNumber, operat, secondNumber);
                        }
                        else
                        {
                            ErrorReRun("The number is not correct.", true);
                        }
                        break;
                    case "/":
                        if (parsedFirst && parsedSecond)
                        {
                            if (secondNumber == "0")
                            {
                                ErrorReRun("Cannot divide by zero.", true);
                            }

                            currentValue = firstDecimal / secondDecimal;
                            CalculationHistory(firstNumber, operat, secondNumber);
                        }
                        else
                        {
                            ErrorReRun("The number is not correct.", true);
                        }
                        break;
                    case "!":
                        if (parsedFirst)
                        {
                            if (firstDecimal < 0)
                            {
                                ErrorReRun("Cannot calculate factorial of negative number.", true);
                            }

                            currentValue = CalculateFactorial(Convert.ToInt32(firstDecimal));
                            CalculationHistory(firstNumber, operat, string.Empty);
                        }
                        else
                        {
                            ErrorReRun("The number is not correct.", true);
                        }
                        break;
                    case "^":
                        if(parsedFirst && parsedSecond)
                        {
                            if (secondDecimal < 0)
                            {
                                ErrorReRun("Cannot calculate power of negative number.", true);
                            }

                            currentValue = Convert.ToDecimal(Math.Pow(Convert.ToDouble(firstDecimal), Convert.ToDouble(secondDecimal)));
                            CalculationHistory(firstNumber, operat, string.Empty);
                        }
                        else
                        {
                            ErrorReRun("The number is not correct.", true);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator");
                        break;
                }

                firstOperation = false;
                Console.Clear();
            }
        }

        private void CalculationHistory(string firstNumber, string operat, string secondNumber)
        {
            currentCalculationText += string.Format("{0} {1} {2}", firstOperation ? firstNumber : string.Empty, operat, secondNumber);
        }

        private void ErrorReRun(string message, bool reRun)
        {
            Console.WriteLine(message);
            Thread.Sleep(2000);
            
            if (reRun)
            {
                Console.Clear();
                Run();
            }
        }

        private decimal? CalculateFactorial(int v)
        {
            decimal? result = 1;
            for (int i = 1; i <= v; i++)
            {
                result *= i;
            }
            return result;
        }

        private string CleanInput(string input)
        {
            if (input.ToLower().Contains("x"))
            {
                return "x";
            }

            string result = input.Replace(" ", string.Empty);
            result = result.Replace("(", string.Empty);
            result = result.Replace(")", string.Empty);
            result = Regex.Replace(result, @"[a-zA-Z]", string.Empty);
            return result;
        }

        private string GetOperator(string input)
        {
            if (input.Contains("+"))
            {
                return "+";
            }
            else if (input.Contains("-"))
            {
                return "-";
            }
            else if (input.Contains("*"))
            {
                return "*";
            }
            else if (input.Contains("/"))
            {
                return "/";
            }
            else if (input.Contains("!"))
            {
                return "!";
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetFirstNumber(string input, string operat)
        {
            if (!firstOperation)
            {
                return currentValue.ToString();
            }

            int index = input.IndexOf(operat);
            string result = input.Substring(0, index);
            
            return result;
        }

        private string GetSecondNumber(string input, string operat)
        {
            int index = input.IndexOf(operat);
            string result = input.Substring(index + 1, input.Length - index - 1);

            return result;
        }
    }
}
