using System;
using System.Net.Http.Headers;
using System.Numerics;

/*
    This program creates a math game that allows the user to select the difficulty level and the operations they want to play with. I have used goto statements to direct the user to the proper blocks based on operator.
    selection.
 */
Console.WriteLine("Wecome to my Math Game!\n");

Random randomInt = new(); 
int score = 0;
List<string> gameHistory = new();

Start:

Console.Write("Enter P to start the game, H to view game history or E to exit the game: ");
string? userChoice = Console.ReadLine();

if (userChoice?.ToLower() == "e")
{
    Console.WriteLine("Thank you for playing my Math Game!");
    Environment.Exit(0);
}
else if (userChoice?.ToLower() == "h")
{
    Console.WriteLine("Game History: ");
    foreach (string h in gameHistory)
    {
        Console.WriteLine(h);
    }
    Console.WriteLine();
    goto Start;
}
else if (userChoice?.ToLower() != "p")
{
    Console.WriteLine("Invalid Input!\n");
    goto Start;
}
Console.WriteLine(); // empty line for formatting

DifficultySelect:

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
    goto DifficultySelect;
}

if (difficulty < 1 | difficulty > 10) // Checking to make sure input is inside the specified constraints
{
    Console.WriteLine("Invalid Difficulty.\n");
    goto DifficultySelect;
}

difficulty--; // subtract difficulty to make level 10 harder and troll user by setting level 1 to contain problems such as 0 + 0, 0 - 0 and so on and also give 0 score for each solved problem

OperatorSelect:

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
        Console.Write("Invalid Operator!\n");
        goto OperatorSelect;
}

Addition:

int additionDifficulty = difficulty * difficulty; // squaring difficulty to make addition harder

int firstNumToAdd = randomInt.Next(1, 10) * additionDifficulty;
int secondNumToAdd = randomInt.Next(1, 10) * additionDifficulty;
int sum = firstNumToAdd + secondNumToAdd;

string history = $"{firstNumToAdd} + {secondNumToAdd} = {sum}";
gameHistory.Add(history);

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

history = $"{firstNumToSubtract} - {secondNumToSubtract} = {difference}";
gameHistory.Add(history);

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

history = $"{firstNumToMultiply} * {secondNumToMultiply} = {product}";
gameHistory.Add(history);

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
//difficulty++; // This will increase the diffculty so that the requirement for dividend going upto 100 is met. But it also makes level 10 very easy. So , I have commented it out.

int secondNumToDivide = randomInt.Next(1, 10) * difficulty;
int quotient = randomInt.Next(1, 10) * difficulty; // Generate quotient first so that division answers are always integers
int firstNumToDivide = secondNumToDivide * quotient;

history = $"{firstNumToDivide} / {secondNumToDivide} = {quotient}";
gameHistory.Add(history);

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
    //difficulty--; //Reducing difficulty since user can select another operator after going back to start
    Console.WriteLine($"Wrong Answer :(. {firstNumToDivide} / {secondNumToDivide} = {quotient}");
    goto Retry;
}

Retry:

string finalMessage = $"Your final score was {score}\n";
gameHistory.Add(finalMessage);
Console.WriteLine(finalMessage);
score = 0;

Console.Write("Enter Y to return to main menu, H to check game history or any other key to exit: ");
string? tryAgain = Console.ReadLine();

if (tryAgain?.ToLower() == "y")
{
    Console.WriteLine();
    goto Start;
}
else if (tryAgain?.ToLower() == "h")
{
    Console.WriteLine("Game History: ");
    foreach (string h in gameHistory)
    {
        Console.WriteLine(h);
    }
    Console.WriteLine();
    goto Start;
}
else
{
    Console.WriteLine("Thank you for playing my Math Game!");
    Environment.Exit(0);
}
