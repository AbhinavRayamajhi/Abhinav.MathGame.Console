using System;
using System.Net.Http.Headers;
using System.Numerics;

Console.WriteLine("Wecome to my Math Game!\n");
Console.WriteLine("If you want to exit the program, after the operator selection just give a wrong answer and follow the prompts.");

Random randomInt = new Random(); 
int score = 0;

Start:

Console.WriteLine(); // new line for formatting

Console.Write("Enter your difficulty level(1 - 10): ");
string? userInputDifficulty = Console.ReadLine();

//Code to check for non numerical inputs for difficulty by user
if (int.TryParse(userInputDifficulty, out int difficulty)) 
{
    Console.WriteLine($"Your selected difficulty is {difficulty}.");
}
else
{
    Console.WriteLine("Invalid Input!\n");
    goto Start;
}

if (difficulty < 1 | difficulty > 10) // Checking to make sure input is inside the specified constraints
{
    Console.WriteLine("Invalid Difficulty.\n");
    goto Start;
}

difficulty--; // subtract difficulty to make level 10 harder and troll user by setting level 1 to contain problems such as 0 + 0, 0 - 0 and so on and also give 0 score for each solved problem
Console.WriteLine(difficulty);

Console.Write("\nEnter the operations that you want to play with(+,-,*,/): ");
string? operations = Console.ReadLine();

Console.WriteLine(); 

//switch statement to direct user to proper segement based on selected operator
switch(operations)
{
    case "+":
        goto Addition;
    case "-":
        goto Subtraction;
    case "*":
        goto Multiplication;
    case "/":
        goto Division;
    default:
        Console.WriteLine("Invalid Operator!\n");
        goto Start;
}

Addition:

int additionDifficulty = difficulty * difficulty; // squaring difficulty to make addition harder

int firstNumToAdd = randomInt.Next(1, 10) * additionDifficulty;
int secondNumToAdd = randomInt.Next(1, 10) * additionDifficulty;
int sum = firstNumToAdd + secondNumToAdd;

Console.Write($"What is {firstNumToAdd} + {secondNumToAdd}?: ");
string? userAdditionAnswer = Console.ReadLine();
Console.WriteLine(); 

//checking for non numerical input for answer by user
if (int.TryParse(userAdditionAnswer, out int additionAnswer))
{
}
else
{
    Console.WriteLine("Invalid Input!\n");
    goto Addition;
}

//checking if user answer is correct 
if (additionAnswer == sum)
{
    Console.WriteLine($"Correct answer. {firstNumToAdd} + {secondNumToAdd} = {sum}.");
    score += difficulty; // incrementing score based on difficulty
    Console.WriteLine($"Your score is {score}.\n");
    goto Addition;
}
else
{
    Console.WriteLine($"Wrong Answer :(. {firstNumToAdd} + {secondNumToAdd} = {sum}");
    goto Retry;
}

Subtraction:

int subtractionDifficulty = difficulty * difficulty; // squaring difficulty to make subtraction harder

int firstNumToSubtract = randomInt.Next(1, 10) * subtractionDifficulty;
int secondNumToSubtract = randomInt.Next(1, 10) * subtractionDifficulty;

if (secondNumToSubtract > firstNumToSubtract) // Swapping the numbers if second number is greater than first number to avoid negative numbers
{
    int temp = firstNumToSubtract;
    firstNumToSubtract = secondNumToSubtract;
    secondNumToSubtract = temp;
}

int difference = firstNumToSubtract - secondNumToSubtract;

Console.Write($"What is {firstNumToSubtract} - {secondNumToSubtract}?: ");
string? userSubtractionAnswer = Console.ReadLine();
Console.WriteLine();

//checking for non numerical input for answer by user
if (int.TryParse(userSubtractionAnswer, out int subtractionAnswer))
{
}
else
{
    Console.WriteLine("Invalid Input!\n");
    goto Subtraction;
}

if (subtractionAnswer == difference)
{
    Console.WriteLine($"Correct answer. {firstNumToSubtract} - {secondNumToSubtract} = {difference}.");
    score += difficulty; // incrementing score based on difficulty
    Console.WriteLine($"Your score is {score}.\n");
    goto Subtraction;
}
else
{
    Console.WriteLine($"Wrong Answer :(. {firstNumToSubtract} - {secondNumToSubtract} = {difference}");
    goto Retry;
}

Multiplication:

int firstNumToMultiply = randomInt.Next(1, 10) * difficulty;
int secondNumToMultiply = randomInt.Next(1, 10) * difficulty;
int product = firstNumToMultiply * secondNumToMultiply;

Console.Write($"What is {firstNumToMultiply} * {secondNumToMultiply}?: ");
string? userMultiplicationAnswer = Console.ReadLine();
Console.WriteLine();

if (int.TryParse(userMultiplicationAnswer, out int multiplicationAnswer))
{
}
else
{
Console.WriteLine("Invalid Input!\n");
goto Multiplication;
}

if (multiplicationAnswer == product)
{
    Console.WriteLine($"Correct answer. {firstNumToMultiply} * {secondNumToMultiply} = {product}.");
    score += difficulty; // incrementing score based on difficulty
    Console.WriteLine($"Your score is {score}.\n");
    goto Multiplication;
}
else
{
    Console.WriteLine($"Wrong Answer :(. {firstNumToMultiply} * {secondNumToMultiply} = {product}");
    goto Retry;
}

Division:

int secondNumToDivide = randomInt.Next(1, 10) * difficulty;
int quotient = randomInt.Next(1, 10) * difficulty; // Generate quotient first so that division answers are always integers
int firstNumToDivide = secondNumToDivide * quotient; 

Console.Write($"What is {firstNumToDivide} / {secondNumToDivide}?: ");
string? userDivisionAnswer = Console.ReadLine();
Console.WriteLine();

if (int.TryParse(userDivisionAnswer, out int divisionAnswer))
{
}
else
{
    Console.WriteLine("Invalid Input!\n");
    goto Division;
}

if (divisionAnswer == quotient)
{
    Console.WriteLine($"Correct answer. {firstNumToDivide} / {secondNumToDivide} = {quotient}.");
    score += difficulty; // incrementing score based on difficulty
    Console.WriteLine($"Your score is {score}.\n");
    goto Division;
}
else
{
    Console.WriteLine($"Wrong Answer :(. {firstNumToDivide} / {secondNumToDivide} = {quotient}");
    goto Retry;
}

Retry:

Console.WriteLine($"Your final score was {score}\n");
score = 0;
Console.Write("Try again (Y/N): ");
string? tryAgain = Console.ReadLine();

if (tryAgain?.ToLower() == "y")
{
    Console.WriteLine();
    goto Start;
}
else
{
    Console.WriteLine("Thank you for playing my Math Game!");
    Environment.Exit(0);
}
