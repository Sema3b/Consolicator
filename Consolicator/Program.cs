using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Console.WriteLine("Welcome to Consolicator!\n\r");
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
                }

                var input = Console.ReadLine();
                stringOperation = CleanInput(input);

                if (stringOperation == "x")
                {
                    break;
                }

                string operat = GetOperator(input);
                if (operat == string.Empty)
                {
                    Console.WriteLine("Invalid operator");
                    Console.Clear();
                    Run();
                }

                firstNumber = GetFirstNumber(input, operat);
                secondNumber = GetSecondNumber(input, operat);

                switch (operat)
                {
                    case "+":
                        currentValue = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                        currentCalculationText += string.Format("{0} + {1}", firstOperation ? firstNumber : string.Empty, secondNumber);
                        break;
                    case "-":
                        currentValue = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                        currentCalculationText += string.Format("{0} - {1}", firstNumber, secondNumber);
                        break;
                    case "*":
                        currentValue = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                        currentCalculationText += string.Format("{0} * {1}", firstNumber, secondNumber);
                        break;
                    case "/":
                        if (secondNumber == "0")
                        {
                            Console.WriteLine("Cannot divide by zero");
                            Console.Clear();
                            Run();
                        }
                        currentValue = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                        currentCalculationText += string.Format("{0} / {1}", firstNumber, secondNumber);
                        break;
                    case "!":
                        if (Convert.ToInt32(firstNumber) < 0)
                        {
                            Console.WriteLine("Cannot calculate factorial of negative number");
                            Console.Clear();
                            Run();
                        }
                        currentValue = CalculateFactorial(Convert.ToInt32(firstNumber));
                        currentCalculationText += string.Format("!{0}", firstNumber);
                        break;
                    case "^":
                        if (Convert.ToInt32(secondNumber) < 0)
                        {
                            Console.WriteLine("Cannot calculate power of negative number");
                            Console.Clear();
                            Run();
                        }
                        currentValue = Convert.ToDecimal(Math.Pow(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber)));
                        currentCalculationText += string.Format("{0} ^ {1}", firstNumber, secondNumber);
                        break;
                    default:
                        Console.WriteLine("Invalid operator");
                        break;
                }

                firstOperation = false;
                Console.Clear();
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

            var result = input.Replace(" ", string.Empty);
            result = result.Replace("(", string.Empty);
            result = result.Replace(")", string.Empty);
            result = Regex.Replace(result, @"[a-yA-YzZ]", string.Empty);
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
            var index = input.IndexOf(operat);
            var result = input.Substring(0, index);
            if (result == string.Empty)
            {
                return currentValue.ToString();
            }
            return result;
        }

        private string GetSecondNumber(string input, string operat)
        {
            var index = input.IndexOf(operat);
            var result = input.Substring(index + 1, input.Length - index - 1);
            return result;
        }
    }
}
