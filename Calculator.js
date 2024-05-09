// Importing the prompt-sync library to enable user input in the console.
const prompt = require('prompt-sync')();

//Function for addition.
function add(x, y)
{
    return x + y;
}

//Function for subtraction.
function subtract(x, y)
{
    return x - y;
}

//Function for multiplication.
function multiply (x, y)
{
    return x * y;
}

//Function for division.
function divide(x, y)
{
    //First checking if the denominator is zero.
    while(true)
    {
        if(y == 0)
        {
            console.log("Denominator can not be zero!");
            y = checkDouble(); //If input is zero, asking user to input non-zero denominator.
        }
        else
        {
            return x / y;
        }
    }
}

//function for calculating remainder
function calculateRemainder(x, y)
{
    return x % y;
}

//Function for calculating exponentiation of a number.
function calculateExponentiation(x, y)
{
    var result = 1;
    //First checking if exponent is negative.
    while(true)
    {
        if(y < 0)
        {
            console.log("Exponent can not be negative!");
            y = checkDouble(); //If input is negative, asking user to input new non-negative exponent.
        }
        else
        {
            for(let i = 0; i < y; i++)
            {
                result = result * x;
            }
            return result;
        }
    }
}

//Function to calculate the square root of a number.
function calculateSquareRoot(x)
{
    return Math.sqrt(x);
}

//Function to check if the input is a valid double.
function checkDouble()
{
    var x = 0;
    while(true)
    {
        var input = prompt();
        if (isNaN(input) == false) 
        {
            return parseFloat(input);
        } 
        else
        {
            console.log("Invalid input! Input must be a number!");
        }      
    }
}

//Function to check if the input is a valid mathematical operation
function checkOperation()
{
    while(true)
    {
        var input = prompt();

        // Validating the input against supported operations.
        if(input == "+" || input == "-" || input == "*" || input == "/" || input == "%"
        || input == "^" || input == "s" || input == "M" || input == "m")
        {
            return input;
        }
        else if(input == "q" || input == "Q")
        {
            process.exit(); // Exiting the program if the user inputs 'q' or 'Q'.
        }
        else
        {
            console.log("Invalid input! Input must be operation!")
        }
    }
}

// Function to check the second input after the operation.
function checkSecondInput()
{
    while(true)
    {
        var input = prompt();

        if (isNaN(input) == false) 
        {
            return parseFloat(input);
        } 
        else if (isNaN(input) == true)
        {
            // Handling special operations and commands.
            if (input == "+" || input == "-" || input == "*" || input == "/" 
            || input == "%" || input == "^" || input == "s" || input == "M" 
            || input == "m" || input == "P" || input == "p") 
            {
                return input;
            } 
            else if (input === "") 
            {  
              console.log();// Handling empty input.
            } 
            else if (input == "Q" || input == "q") 
            {
              process.exit(); // Exiting the program if the user inputs 'q' or 'Q'.
            } 
            else if ((input[0] == "R" || input[0] == "r") && (isNaN(input.charAt(1)) == false))
            {
                return input; // Handling retrieval of stored numbers.
            }
        } 
        else 
        {
            console.log("Invalid input! Input must be a number or operation!");
        }
    }
}

//Declaring variables to store input numbers and results.
var firstNumber;
var secondNumber;
var result;
var operation;
var secondOperation;
var firstWhile = true;
var secondWhile = true;
var secondOperationWhile = true;
var switchWhile = true;

//Aray to store saved numbers.
let storedNumbers = [];

// Displaying the welcome message and list of supported operations.
console.log("        >>> Calculator <<<");
console.log("-----------------------------------");
console.log("Calculator can:" +
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
    "\n \t Retrieve and continue with number from the list (Rn - where n is index of number on the list" +
    "\n \t Quit program (q)");
console.log("-----------------------------------");

// Prompting user to input the first number.
firstNumber = checkDouble();

// Main loop for calculator operations.
while(firstWhile == true)
{
    secondWhile = true;

    // Asking user to input the operation.
    operation = checkOperation();

    // Handling special operation for saving the first number.
    if(operation == "M" || operation == "m")
    {
        storedNumbers.push(firstNumber);
        console.log(firstNumber + "<- is added to the list!");
        operation = checkOperation();
    }

     // Secondary loop for second input and operations.
    while(secondWhile == true)
    {
        secondOperationWhile = true;
        switchWhile = true;

        // Handling square root operation separately.
        if(operation == "s")
        {
            secondNumber = 0;
        }
        else
        {
            secondNumber = checkDouble();
        }

        // Performing the requested operation.
        switch(operation)
        {
            // Addition operation.
            case "+":
                result = add(firstNumber, secondNumber);
                firstNumber = result;

                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;

            // Subtraction operation.  
            case "-":
                result = subtract(firstNumber, secondNumber);
                firstNumber = result;
                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;

            // Multiplication operation.
            case "*":
                result = multiply(firstNumber, secondNumber);
                firstNumber = result;
                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;

            // Division operation.
            case "/":
                result = divide(firstNumber, secondNumber);
                firstNumber = result;
                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;

            // Remainder calculation operation.
            case "%":
                result = calculateRemainder(firstNumber, secondNumber);
                firstNumber = result;
                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;  

            // Exponentiation operation.
            case "^":
                result = calculateExponentiation(firstNumber, secondNumber);
                firstNumber = result;
                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;  

            // Square root calculation operation.
            case "s":
                result = calculateSquareRoot(firstNumber, secondNumber);
                firstNumber = result;
                while(switchWhile == true)
                {
                    var g = prompt();
                    if(g == "=" || g == "")
                    {
                        console.log(result);
                        switchWhile = false;
                    }  
                    else if(g == "M" || g == "m")
                    {
                        storedNumbers.push(secondNumber);
                        console.log(secondNumber + "<- is added to the list");
                        switchWhile = true;
                    }
                    else
                    {
                        console.log("Invalid input! Input must be equals/enter or M!");
                        switchWhile = true;
                    }
                }
                break;
               
            // Default case for invalid input.
            default:
                console.log("Invalid input!");
                break;         
        }

        // Handling retrieval of stored numbers or additional operations.
        while(secondOperationWhile == true)
        {
            secondOperation = checkSecondInput();

            // Retrieving stored numbers by index.
            if ((secondOperation[0] == 'R' || secondOperation[0] == 'r') && (/\d/.test(secondOperation.charAt(1))))
            {
                var Rnum = parseInt(secondOperation.charAt(1));
                if(Rnum <= storedNumbers.length && Rnum > 0)
                {
                    firstNumber = storedNumbers[Rnum - 1];
                    console.log("You accessed number: " + firstNumber);
                    secondOperationWhile = true;
                }
                else if(Rnum > storedNumbers.length)
                {
                    console.log("Result does not exist at location!");
                    secondOperationWhile = true;
                }
                else if(Rnum <= 0)
                {
                    console.log("Result does not exist at location!");
                    secondOperationWhile = true;
                }
            }

            else if(isNaN(secondOperation) == true) 
            {
                // Handling special operations and commands.
                if (secondOperation == "M" || secondOperation == "m")
                {
                    storedNumbers.push(firstNumber);
                    console.log(firstNumber + "<- is added to the list!");
                    secondOperationWhile = true;
                }
                else if (secondOperation == "P")
                {
                    console.log("----------");
                    console.log("List of saved numbers: ");
                    for (var n = 0; n < storedNumbers.length; n++) 
                    {
                        console.log("[" + (n + 1) + "]" + storedNumbers[n]); 
                    }
                    console.log("----------");
                    secondOperationWhile = true;
                }
                else
                {
                    firstWhile = false;
                    secondWhile = true;
                    operation = String(secondOperation);
                    secondOperationWhile = false;
                }
            }
            
            else 
            {
                secondOperationWhile = false;
                firstWhile = true;
                secondWhile = false;
                firstNumber = parseFloat(secondOperation);
            }
        }       
    }
}