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
            bool firstEntry = true;
            int sum = 0;
            string history = "";

            if (!string.IsNullOrEmpty(cleanedInput)) // kontrolliert, ob ueberhaupt etwas eingegeben wurde
            {

                while (!cleanedInput.ToLower().Equals("x")) // solange eingabe nicht x ist
                {
                    char[] operators = { '+', '-', '*', '/', '^', '!' };
                    int indexOperators = cleanedInput.IndexOfAny(operators);// sucht im input nach den index des operators

                    int length = cleanedInput.Length; // length of input
                    int secondNumber = 0;

                    string whichOperator = cleanedInput.Substring(indexOperators, 1);

                    if (!whichOperator.Equals("!"))
                    {
                        secondNumber = int.Parse(cleanedInput.Substring(indexOperators + 1, length - (indexOperators + 1)));//speichert die zweite Zahl ab, indem er von indexopoerator bis lastindex vom string die zahl rausschreibt
                    }



                    if (firstEntry) // prueft, ob erste Stelle eine Zahl ist
                    {

                        int firstNumber = int.Parse(cleanedInput.Substring(0, indexOperators));// speichert die erste Zahl ab, indem er von index 0 bis indexoperator die zahl rausschreibt
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
                                if(secondNumber == 0)
                                {
                                    Console.WriteLine("Durch 0 ist nicht teilbar. Bitte eine neue Zahl eingeben.");
                                    secondNumber = Convert.ToInt32(Console.ReadLine());
                                }
                                sum = firstNumber / secondNumber;


                                break;

                            case "^":
                                sum = (int)Math.Pow((double)firstNumber, (double)secondNumber);
                                break;

                            case "!":
                                sum = 1;
                                for (int k = 1; k <= firstNumber; k++)
                                {
                                    sum *= k;
                                }
                                break;

                            default:
                                break;

                        }
                        history = $"{cleanedInput} = {sum}";
                        firstEntry = false;
                    }
                    else if (cleanedInput.Contains("+") || cleanedInput.Contains("+") || cleanedInput.Contains("-") || cleanedInput.Contains("*") || cleanedInput.Contains("/") || cleanedInput.Contains("^") || cleanedInput.Contains("!")) // used when new input doesnt start with number, but contains a operator
                    {
                        //int lengthOfFirstNewNumber = length - (secondNumber - indexOperators);// used later to remove first number of the new input
                        //cleanedInput.Remove(0, lengthOfFirstNewNumber);
                        //string newInput = cleanedInput.Substring(0, length - lengthOfFirstNewNumber);
                        //int newInputLength = newInput.Length;
                        //int newSecondNumber = int.Parse(newInput.Substring(indexOperators + 1,newInputLength - indexOperators));

                        switch (whichOperator)
                        {
                            case "+":
                                sum = sum + secondNumber;
                                break;

                            case "-":
                                sum = sum - secondNumber;
                                break;

                            case "*":
                                sum = sum * secondNumber;
                                break;

                            case "/":
                                sum = sum / secondNumber;
                                break;

                            case "^":
                                sum = (int)Math.Pow((double)sum, (double)secondNumber);
                                break;

                            case "!":
                                int schlamm = sum;
                                sum = 1;
                                for (int k = 1; k <= schlamm; k++)
                                {
                                    sum*= k;
                                }
                                break;

                            default:
                                break;


                        }
                        history += $"{cleanedInput} = {sum}";
                    }


                    Console.Clear();
                    Console.WriteLine($"{history}");
                    Console.WriteLine(sum);
                    Console.WriteLine("Please type an operation or x to exit:");

                    cleanedInput = Console.ReadLine().Replace(" ", "");

                    //if it is there, cut out the first number of the new input and continue with the rest of the string
                    //continue history => sum+newinput(which has been edited by removing first number)
                    //fakultaet
                    //place "sum"somewhere, where you can add on it 
                    //where is TryParse more useful 
                }
            }

        }

    }
}