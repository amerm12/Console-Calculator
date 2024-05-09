using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables to store input numbers and results
            double firstNumber;
            double secondNumber;
            double result;
            string operation;
            string secondOperation;
            bool firstWhile = true;
            bool secondWhile = true;
            bool secondOperationWhile = true;
            bool switchWhile = true;

            //Array to store saved numbers
            List<double> storedNumbers = new List<double>();

            //Displaying the welcome message and list of supported operations
            Console.WriteLine("        >>> Calculator <<<");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Calculator can:" +
                "\n \t Add (+) " +
                "\n \t Subtract (-)" +
                "\n \t Multiply (*) " +
                "\n \t Divide (/)" +
                "\n \t Calculate Remainder (%)" +
                "\n \t Calculate Exponent (^)" +
                "\n \t Calculate Square Root (s)" +
                "\n \t Start calculation (= / Enter on keyboard)" +
                "\n \t Save last input (M)" +
                "\n \t List all saved numbers (P)" +
                "\n \t Retrieve and continue with number from the list (Rn - where n is index of number on the list)" +
                "\n \t Quit program (q)");
            Console.WriteLine("-----------------------------------");

            //Prompting user to input the first number
            firstNumber = CheckDouble();

            //Main loop for calculator operations
            while (firstWhile == true)
            {
                secondWhile = true;
                //Prompting user to input the operation
                operation = CheckOperation();

                //Handling special operation for saving the first number.
                if (operation == "M" || operation == "m")
                {
                    storedNumbers.Add(firstNumber);
                    Console.WriteLine(firstNumber + "<- is added to the list!");
                    operation = CheckOperation();
                }

                //Second loop for second input and operations 
                while (secondWhile == true)
                {
                    secondOperationWhile = true;
                    switchWhile = true;

                    if (operation == "s")
                    {
                        secondNumber = 0;
                    }
                    else
                    {
                        secondNumber = CheckDouble();
                    }

                    //Performing the requested operation
                    switch (operation)
                    {
                        case "+":
                            result = Add(firstNumber, secondNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + "<- is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        case "-":
                            result = Subtract(firstNumber, secondNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + " is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        case "*":
                            result = Multiply(firstNumber, secondNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + " is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        case "/":
                            result = Divide(firstNumber, secondNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + " is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        case "%":
                            result = CalculateRemainder(firstNumber, secondNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + " is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        case "^":
                            result = CalculateExponentiation(firstNumber, secondNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + " is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        case "s":
                            result = CalculateSquareRoot(firstNumber);
                            firstNumber = result;
                            while (switchWhile == true)
                            {
                                ConsoleKeyInfo g = Console.ReadKey();

                                if (g.KeyChar == '=' || g.Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine("\n" + result);
                                    switchWhile = false;
                                }
                                else if (char.ToUpper(g.KeyChar) == 'M')
                                {
                                    storedNumbers.Add(secondNumber);
                                    Console.WriteLine("\n" + secondNumber + " is added to the list!");
                                    switchWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input! Input must be equals/enter or M!");
                                    switchWhile = true;
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }

                    //Handling the retrieval of stored number or additional operations
                    while (secondOperationWhile == true)
                    {
                        secondOperation = CheckSecondInput();

                        if (Regex.IsMatch(secondOperation, @"[+-]?\d+(.\d+)?") == false)
                        {
                            //Saving number to the list
                            if (secondOperation == "M" || secondOperation == "m")
                            {
                                storedNumbers.Add(firstNumber);
                                Console.WriteLine(firstNumber + "<- is added to the list!");
                                secondOperationWhile = true;
                            }
                            //Printing out saved numbers list
                            else if (secondOperation == "P" || secondOperation == "p")
                            {
                                int n = 1;
                                Console.WriteLine("----------");
                                Console.WriteLine("List of saved numbers: ");
                                foreach (double number in storedNumbers)
                                {
                                    Console.WriteLine("[" + n + "] " + number);
                                    n++;
                                }
                                Console.WriteLine("----------");
                                secondOperationWhile = true;
                            }
                            else
                            {
                                firstWhile = false;
                                secondWhile = true;
                                operation = secondOperation;
                                secondOperationWhile = false;
                            }
                        }
                        //Retrieving stored numbers by index
                        else if ((secondOperation[0] == 'R' || secondOperation[0] == 'r') && Char.IsDigit(secondOperation[1]))
                        {
                            int rNum = int.Parse(secondOperation[1].ToString());
                            if (rNum <= storedNumbers.Count && rNum > 0)
                            {
                                    firstNumber = storedNumbers[rNum - 1];
                                    Console.WriteLine("You accessed number: " + firstNumber);
                                    secondOperationWhile = true;
                            }
                            else if (rNum > storedNumbers.Count)
                            {
                                Console.WriteLine("Result does not exist at location!");
                                secondOperationWhile = true;
                            }
                            else if ((rNum) <= 0)
                            {
                                Console.WriteLine("Result does not exist at location!");
                                secondOperationWhile = true;
                            }
                        }

                        else if (Regex.IsMatch(secondOperation, @"[+-]?\d+(.\d+)?") == true)
                        {
                            firstWhile = true;
                            secondWhile = false;
                            firstNumber = Convert.ToDouble(secondOperation);
                            secondOperationWhile = false;
                        }
                    }
                }
            }
        }

        //Function for addition
        static double Add(double x, double y)
        {
            return x + y;
        }

        //Function for subtraction
        static double Subtract(double x, double y)
        {
            return x - y;
        }

        //Function for multiplication
        static double Multiply(double x, double y)
        {
            return x * y;
        }

        //Function for division
        static double Divide(double x, double y)
        {
            while (true)
            {
                if (y == 0)
                {
                    Console.WriteLine("Denominator can not be zero. Input second number again: ");
                    y = CheckDouble();
                }
                else
                {
                    return x / y;
                }
            }
        }

        //Function for calculating reminder
        static int CalculateRemainder(double x, double y)
        {
            return (int)(x % y);
        }

        //Function for calculating exponentiation of a number
        static double CalculateExponentiation(double x, double y)
        {
            double result = 1;
            while (true)
            {
                y = Convert.ToInt64(y);
                if (y < 0)
                {
                    Console.WriteLine("Exponent can not be negative! Input any positive exponent: ");
                    y = CheckDouble();
                }
                else
                {
                    for (int i = 0; i < y; i++)
                    {
                        result = result * x;
                    }

                    return result;
                }
            }

        }

        //Function to calculate the square root of a number
        static double CalculateSquareRoot(double x)
        {
            return Math.Sqrt(x);
        }

        //Function to check if the input is a valid double
        static double CheckDouble()
        {
            double x = 0;
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    x = double.Parse(input);
                    return x;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Input must be number!");
                }
            }
        }

        //Function to check if the input if a valid mathematical operation
        static string CheckOperation()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "+" || input == "-" || input == "*" || input == "/" || input == "%"
                    || input == "^" || input == "s" || input == "M" || input == "m")
                {
                    return input;
                }
                else if (input == "q" || input == "Q")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Invalid input! Input must be operation!");
                }
            }
        }

        //Function to check the second input after the operation
        static string CheckSecondInput()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    double x = double.Parse(input);
                    string y = x.ToString();
                    return y;
                }
                catch (FormatException)
                {
                    if (input == "+" || input == "-" || input == "*" || input == "/"
                        || input == "%" || input == "^" || input == "s" || input == "M"
                        || input == "m" || input == "P" || input == "p")
                    {
                        return input;
                    }
                    else if (string.IsNullOrEmpty(input))
                    {

                    }
                    else if (input == "q" || input == "Q")
                    {
                        Environment.Exit(1);
                    }
                    else if ((input[0] == 'R' || input[0] == 'r') && Char.IsDigit(input[1]))
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Input must be number or operation!");
                    }
                }
            }
        }
    }
}