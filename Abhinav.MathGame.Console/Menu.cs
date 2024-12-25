namespace MathGame
{
    using System;

    internal class Menu
    {
        GameEngine gameClass = new();

        internal void ShowMenu(string name)
        {
            Console.Clear();
            Console.Write($"Wecome to my Math Game, {name}. Press any key to continue...");
            Console.ReadKey();

            bool isGameOn = true;

            Console.Clear();

            do
            {
                Console.WriteLine(@"What game would you like to play today? Choose from the options below:
1 - View Previous Games
2 - Addition
3 - Subtraction
4 - Multiplication
5 - Division
6 - Quit the program");

                Console.WriteLine();
                string? userChoice = Console.ReadLine();

                switch (userChoice?.Trim().ToLower())
                {
                    case "1":
                        Helper.PrintGames();
                        break;
                    case "2":
                        gameClass.game("Addition");
                        break;
                    case "3":
                        gameClass.game("Subtraction");
                        break;
                    case "4":
                        gameClass.game("Multiplication");
                        break;
                    case "5":
                        gameClass.game("Division");
                        break;
                    case "6":
                        gameClass.game("Thank you for playing my game.");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!\n");
                        break;
                }
            } while (isGameOn);
        }
    }
}
