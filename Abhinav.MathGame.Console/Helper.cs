namespace MathGame
{
    internal class Helper
    {
        internal static List<List<string>> fullGameHistory = new();

        internal static int ValidateAnswer(string? userString)
        {
            int result;
            while (!int.TryParse(userString, out result))
            {
                Console.Write("Invalid Input! ");
                Console.Write("Please enter a valid integer: ");
                userString = Console.ReadLine();
            }
            return result;
        }

        internal static void PrintGames()
        {
            Console.Clear();
            foreach (List<string> singleGameHistory in fullGameHistory)
            {
                foreach (string history in singleGameHistory)
                {
                    Console.WriteLine(history);
                }
            }
            Console.Write("Press any key to go back to menu...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static List<int> GenerateDivisionNumbers()
        {
            Random randInt = new();
            int firstNum = randInt.Next(1, 99);
            int secondNum = randInt.Next(1, 99);

            List<int> result = new(2);

            while(firstNum % secondNum != 0)
            {
                firstNum = randInt.Next(1, 99);
                secondNum = randInt.Next(1, 99);
            }

            result.Add(firstNum);
            result.Add(secondNum);

            return result;

        }

        internal static int GetDifficulty()
        {
            int difficulty = 0;

            Console.Write("Enter your difficulty level(1 - 10): ");

            difficulty = Helper.ValidateAnswer(Console.ReadLine());

            if (difficulty < 11 && difficulty > 0)
            {
                return difficulty;
            }
            else
            {
                Console.WriteLine("Invalid Difficulty! \n");
                return GetDifficulty();
            }
        }
    }
}

