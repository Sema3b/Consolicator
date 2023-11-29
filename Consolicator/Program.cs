using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Consolicator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Consolicator!\nPlease type an operation or x to exit:");

            Calculate();
            void Calculate()
            {

                string inputOne = Convert.ToString(Console.ReadLine()); // eingabe machen und dann saeubern
                inputOne = CleanInput("", " ");
                string CleanInput(string str, string replacement)
                {
                    return str.Replace(str, replacement);
                }
                Console.WriteLine(inputOne);

                string[] input = inputOne.Split(' ');

                char[] operators = { '+', '-', '*', '/', '!', '^' };
                int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                //tryparse
                //while eingabe nicht x
                //tolower x
                //for schleifen weg
                //leertasten cleaninput methode erstellen
                if (!string.IsNullOrEmpty(inputOne)) // kontrolliert, ob ueberhaupt etwas eingegeben wurde
                {
                    int sum = 0;
                    if (inputOne.Equals("x"))
                    {
                        return;
                    }
                    for (int i = 0; i < numbers.Length; i++) // geht ganze zeit in schleife
                    {
                        if (numbers[i].ToString().Equals(input[0])) // kontrolliert das erster wert eine zahl ist
                        {
                            int newIntOne = Int32.Parse(input[0]);
                            for (var j = 0; j < operators.Length; j++)
                            {
                                if (operators[j].ToString().Equals(input[1])) // kontrolliert, das zweite stelle ein operator ist
                                {
                                    int newIntTwo = Int32.Parse(input[2]);

                                    // funktionen erstellen, mit der input[0] mit dem entsprechenden operator mit input[2] kalkuliert wird
                                    switch (operators[j])
                                    {
                                        case '+':
                                            sum = newIntOne + newIntTwo;
                                            break;

                                        case '-':
                                            sum = newIntOne - newIntTwo;
                                            break;

                                        case '*':
                                            sum = newIntOne * newIntTwo;
                                            break;

                                        case '/':
                                            sum = newIntOne / newIntTwo;
                                            break;

                                        case '^':
                                            sum = newIntOne ^ newIntTwo;
                                            break;

                                        //case '!':
                                        default: 
                                            throw new ArgumentException();
                                    }

                                }
                                Console.WriteLine(sum);
                                Retype(sum);
                            }

                        }

                    }

                }
                else
                {
                    Console.WriteLine("Ausnahme spaeter hier");// weil nichts eingegeben wurde
                }
            }

            void Retype(int sum)
            {
                //sum so integrieren, dass neue eingaben darauf aufbauen
                Console.WriteLine("Please type an operation or x to exit:");
                Calculate();
            }
            
        }
    }
}

//switch case zu ! erstellen
// numbers array umaendern, da man auch mehrstellige zahlen braucht