using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Consolicator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Consolicator!\nPlease type an operation or x to exit:");

            string inputOne = Console.ReadLine();
            string cleanedInput = inputOne.Replace(" ", "");


            if (!string.IsNullOrEmpty(cleanedInput)) // kontrolliert, ob ueberhaupt etwas eingegeben wurde
            {

                while (!cleanedInput.ToLower().Equals("x")) // solange eingabe nicht x ist
                {
                    int sum = 0;
                    char[] operators = { '+', '-', '*', '/', '^', '!' };
                    int indexOperators = cleanedInput.IndexOfAny(operators);// sucht im input nach den index des operators
                    int firstNumber = int.Parse(cleanedInput.Substring(0, indexOperators));// speichert die erste Zahl ab, indem er von index 0 bis indexoperator die zahl rausschreibt
                    int length = cleanedInput.Length; // length of input
                    int secondNumber = int.Parse(cleanedInput.Substring(indexOperators, length - indexOperators));//speichert die zweite Zahl ab, indem er von indexopoerator bis lastindex vom string die zahl rausschreibt

                    string whichOperator = cleanedInput.Substring(indexOperators, 1);
                    int lengthOfFirstNewNumber = length - (secondNumber - indexOperators);// used later to remove first number of the new input  

                    if (Regex.IsMatch(cleanedInput, @"^\d")) // prueft, ob erste Stelle eine Zahl ist
                    {





                        //newInput.Remove(0, sumNumber);


                        //int newSecondNumber = int.Parse(cleanedInput.Substring(newindex, length - newindex));

                        switch (whichOperator)
                        {
                            case "+":
                                sum = firstNumber + secondNumber;
                                break;

                            case "-":
                                sum = firstNumber - secondNumber;
                                break;

                            case "*":
                                sum = firstNumber * secondNumber;
                                break;

                            case "/":
                                sum = firstNumber / secondNumber;
                                break;

                            case "^":
                                sum = firstNumber ^ secondNumber;
                                break;

                            //case "!":
                            //    sum = firstNumber ! secondNumber;
                            //    break;

                            default:
                                break;

                        }
                        Console.Clear();
                        Console.WriteLine($"{cleanedInput} = {sum}");
                        Console.WriteLine(sum);
                        Console.WriteLine("Please type an operation or x to exit:");

                        cleanedInput = Console.ReadLine().Replace(" ", "");

                    }
                    else if (!string.IsNullOrEmpty(cleanedInput)) // used when new input doesnt start with number, but contains a operator
                    {
                        cleanedInput.Remove(0, lengthOfFirstNewNumber);
                        string newInput = cleanedInput.Substring(0, length - lengthOfFirstNewNumber);
                        if (newInput.Contains("+") || newInput.Contains("-") || newInput.Contains("*") || newInput.Contains("/") || newInput.Contains("^") || newInput.Contains("!"))
                        {
                            switch (whichOperator)
                            {
                                case "+":
                                    sum = firstNumber + secondNumber;
                                    break;

                                case "-":
                                    sum = firstNumber - secondNumber;
                                    break;

                                case "*":
                                    sum = firstNumber * secondNumber;
                                    break;

                                case "/":
                                    sum = firstNumber / secondNumber;
                                    break;

                                case "^":
                                    sum = firstNumber ^ secondNumber;
                                    break;

                                //case "!":
                                //    sum = firstNumber ! secondNumber;
                                //    break;

                                default:
                                    break;

                            }
                        }
                    }


                    //if it is there, cut out the first number of the new input and continue with the rest of the string
                    //continue history => sum+newinput(which has been edited by removing first number)
                    //fakultaet
                    //place "sum"somewhere, where you can add on it 
                }
            }

        }

    }
}