namespace MathGame
{
    using System;

    internal class GameEngine
    {
        Dictionary<string, string> operatorDict = new()
        {
            { "Addition", "+" },
            { "Subtraction", "-" },
            { "Multiplication", "*" },
            { "Division", "/" }
        };

        List<string> currentGameHistory = new();
        int score = 0;

        internal void game(string operatorChoice)
        {
            bool gameOver = false;
            Random randInt = new();

            Console.Clear();

            Console.WriteLine($"Welcome to the {operatorChoice} game.\n");
            int firstNum, secondNum;

            int difficulty = Helper.GetDifficulty();

            Console.Clear();
            Console.WriteLine($"Your selected difficulty is {difficulty}. \n");

            do
            {
                if (operatorChoice == "Division")
                {
                    List<int> divisionNumbers = Helper.GenerateDivisionNumbers();
                    firstNum = divisionNumbers[0];
                    secondNum = divisionNumbers[1];
                }
                else
                {
                    firstNum = randInt.Next(1, 10);
                    secondNum = randInt.Next(1, 10);
                }
                Console.WriteLine($"What is {firstNum} {operatorDict[operatorChoice]} {secondNum}?: ");
                int userAnswer = Helper.ValidateAnswer(Console.ReadLine());

                int correctAnswer = operatorChoice switch
                {
                    "Addition" => firstNum + secondNum,
                    "Subtraction" => firstNum - secondNum,
                    "Multiplication" => firstNum * secondNum,
                    "Division" => firstNum / secondNum,
                    _ => 0
                };

                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine($"Correct answer. {firstNum} {operatorDict[operatorChoice]} {secondNum} = {correctAnswer}. \n");
                    score++;
                    currentGameHistory.Add($"{firstNum} {operatorDict[operatorChoice]} {secondNum} = {correctAnswer}");

                }
                else
                {
                    Console.WriteLine($"Wrong Answer :(. {firstNum} {operatorDict[operatorChoice]} {secondNum} = {correctAnswer}");
                    Console.Write($"Game Over! Final score was {score}. Press any key to continue...");

                    currentGameHistory.Add($"{firstNum} {operatorDict[operatorChoice]} {secondNum} = {userAnswer} was incorrect. Correct answer is {correctAnswer} \n");
                    Helper.fullGameHistory.Add(currentGameHistory);
                    currentGameHistory.Clear();

                    score = 0;
                    gameOver = true;

                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!gameOver);
        }
    }
}
