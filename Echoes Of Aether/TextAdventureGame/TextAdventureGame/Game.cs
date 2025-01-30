using System;

namespace TextAdventureGame
{
    class Game
    {
        private Menu menu;
        private Map map;
        private Player player;

        public Game()
        {
            menu = new Menu();
            map = new Map();
            player = new Player();
        }

        public void Start()
        {
            menu.ShowMenu();
            if (menu.SelectedOption == MenuOption.NewGame)
            {
                Play();
            }
            else if (menu.SelectedOption == MenuOption.Credits)
            {
                ShowCredits();
            }
            else if (menu.SelectedOption == MenuOption.Quit)
            {
                QuitGame();
            }
        }

        private void Play()
        {
            Console.WriteLine("\nWelcome to Eldoria, a land of mystery and danger.");
            Console.WriteLine("Legends speak of the Eclipse Amulet, hidden in the Cave of Echoes. Many have sought it, but none have returned.");
            Console.WriteLine("Your journey begins in the Whispering Forest, where shadows whisper secrets and the path ahead is uncertain.");

            while (true)
            {
                Console.WriteLine("\nCurrent Location: " + map.CurrentLocation.Name);
                Console.WriteLine(map.CurrentLocation.Description);

                if (map.CurrentLocation.HasInteractiveElement)
                {
                    HandleInteraction();
                }

                if (map.CurrentLocation.HasNPC)
                {
                    HandleNPCInteraction();
                }

                Console.WriteLine("\nWhere would you like to go? (W/A/S/D) or (Q)uit");
                string input = Console.ReadLine().ToUpper();

                if (input == "Q")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }

                map.Move(input);
            }
        }

        private void HandleInteraction()
        {
            if (map.CurrentLocation.Name == "Whispering Forest" && !player.HasItem("Key"))
            {
                Console.WriteLine("You find a hollow tree. Inside, you discover a rusty key and a note:");
                Console.WriteLine("\"Beware the Cave of Echoes. Only the key can unlock its secrets.\"");
                Console.WriteLine("\nDo you want to take the key? (Y/N)");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    player.AddItem(new Item("Key", "A small, rusty key."));
                    Console.WriteLine("You picked up the key!");
                }
            }
            else if (map.CurrentLocation.Name == "Cave of Echoes" && player.HasItem("Key"))
            {
                Console.WriteLine("You use the rusty key to unlock the iron gate. It creaks open, revealing a dark path.");
                Console.WriteLine("Inside, the Eclipse Amulet rests on a pedestal. A voice booms:");
                Console.WriteLine("\"Do you seek power, truth, or destruction? Choose wisely.\"");
                Console.WriteLine("1. Power");
                Console.WriteLine("2. Truth");
                Console.WriteLine("3. Destruction");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nThe amulet’s dark energy consumes you. You emerge as a tyrant, ruling Eldoria with fear.");
                        Console.WriteLine("But the amulet’s curse eats at your soul, and you realize too late the price of power.");
                        break;
                    case "2":
                        Console.WriteLine("\nYou claim the amulet and see visions of Eldoria’s past. With its truth, you vow to rebuild the kingdom.");
                        Console.WriteLine("The villagers cheer, but the whispers remind you: the journey is not over.");
                        break;
                    case "3":
                        Console.WriteLine("\nYou shatter the amulet, silencing the whispers. The villagers rejoice, but Eldoria’s secrets are lost forever.");
                        Console.WriteLine("You walk away, knowing you saved the world but destroyed its greatest treasure.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. The amulet vanishes, and the cave collapses around you.");
                        break;
                }

                Console.WriteLine("Returning to the main menu...");
                Start();
            }
        }

        private void HandleNPCInteraction()
        {
            if (map.CurrentLocation.Name == "Village of Hollowbrook")
            {
                Console.WriteLine("\nAn old farmer sits on a bench. He looks at you with worry.");
                Console.WriteLine("Farmer: \"The key to the Cave of Echoes lies in the Whispering Forest. Find it, but know the amulet’s power comes at a cost.\"");
            }
        }

        private void ShowCredits()
        {
            Console.WriteLine("Credits:");
            Console.WriteLine("Game developed by Mohamad Moaz Nouh.");
            Console.WriteLine("Inspired by Frieren .");
            Console.WriteLine("Chat GPT help in writng and develpping this game.");
            Console.WriteLine("Thank you for playing!");
            Start();
        }

        private void QuitGame()
        {
            Console.WriteLine("Thank you for playing! Goodbye!");
            Environment.Exit(0);
        }
    }
}