using System;
using System.Net.Http.Headers;
using System.Numerics;

Console.WriteLine("Wecome to my Math Game!\n");
Console.WriteLine("If you want to exit the program, after the operator selection just give a wrong answer and follow the prompts.");

Random randomInt = new Random(); // object to create random integer;
int answer; // user answers will be stored in this variable
int score = 0; // variable to track user score

Start:

Console.WriteLine(); // code for new line for formatting

Console.Write("Enter your difficulty level(1 - 10): ");
string userInputDifficulty = Console.ReadLine();

//Code to check for invalid input for difficulty by user
if (int.TryParse(userInputDifficulty, out int difficulty)) 
{
    Console.WriteLine($"Your selected difficulty is {difficulty}.");
}
else
{
    Console.WriteLine("Invalid Input!\n");
    goto Start;
}

if (difficulty < 1 | difficulty > 100) // Checking for valid difficulty input
{
    Console.WriteLine("Invalid Difficulty.\n");
    goto Start;
}

difficulty--; // subtract difficulty to make level 100 harder and troll user by setting level 1 as 0 + 0, 0 - 0 and so on and also give 0 score for level one

Invalid:

Console.Write("\nEnter the operations that you want to play with(+,-,*,/): ");
string operations = Console.ReadLine();

Console.WriteLine(); 

//switch statement to direct user to proper segement based on selected operator
switch(operations)
{
    case "+":
        goto Addition;
    case "-":
        goto Subtraction;
}

Addition:

int additionDifficulty = difficulty ^ 2; // squaring difficulty to make addition harder

int firstNumToAdd = randomInt.Next(1, 10) * additionDifficulty;
int secondNumToAdd = randomInt.Next(1, 10) * additionDifficulty;
int sum = firstNumToAdd + secondNumToAdd;

Console.Write($"What is {firstNumToAdd} + {secondNumToAdd}?: ");
string userAnswer = Console.ReadLine();
Console.WriteLine(); 

//checking for invalid input for answer by user
if (int.TryParse(userAnswer, out answer))
{
}
else
{
    Console.WriteLine("Invalid Input!\n");
    goto Addition;
}

//checking if user answer is correct 
if (answer == sum)
{
    Console.WriteLine($"Correct answer. {firstNumToAdd} + {secondNumToAdd} = {sum}.");
    score += difficulty; // incrementing score based on difficulty
    Console.WriteLine($"Your score is {score}.\n");
    goto Addition;
}

else
{
    Console.WriteLine("Wrong Answer. :(");
}

goto Retry;

Retry:

Console.WriteLine($"Your score was {score}\n");
score = 0;
Console.Write("Try again or exit? (Y/N): ");
string tryAgain = Console.ReadLine();

if (tryAgain.ToLower() == "y")
{
    Console.WriteLine();
    goto Start;
}
else
{
    Environment.Exit(0);
}

Subtraction:

int subtractionDifficulty = difficulty ^ 2; // squaring difficulty to make addition harder

int firstNumToSubtract = randomInt.Next(1, 10) * subtractionDifficulty;
int secondNumToSubtract = randomInt.Next(1, 10) * subtractionDifficulty;
int difference = Math.Abs(firstNumToAdd + secondNumToAdd);



