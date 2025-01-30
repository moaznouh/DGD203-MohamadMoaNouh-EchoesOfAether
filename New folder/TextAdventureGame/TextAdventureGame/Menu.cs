using System;

namespace TextAdventureGame
{
    enum MenuOption { NewGame, Credits, Quit } 

    class Menu
    {
        public MenuOption SelectedOption { get; private set; }

        public void ShowMenu()
        {
            Console.WriteLine("\nWelcome to Echoes Of Aether !");
            Console.WriteLine("1. New Game");
     
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Quit");
            Console.Write("\nSelect an option: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    SelectedOption = MenuOption.NewGame;
                    break;
           
                case "2":
                    SelectedOption = MenuOption.Credits;
                    break;
                case "3":
                    SelectedOption = MenuOption.Quit;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    ShowMenu();
                    break;
            }
        }
    }
}