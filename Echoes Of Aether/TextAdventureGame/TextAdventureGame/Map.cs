using System;

namespace TextAdventureGame
{
    class Map
    {
        public Location CurrentLocation { get; private set; }

        public Map()
        {
            // Initialize locations
            Location forest = new Location("Whispering Forest", "\nA dense, eerie forest where the wind carries faint whispers. Tall trees block the sun, casting long shadows.", true);
            Location village = new Location("Village of Hollowbrook", "\nA small, quiet village with cottages and a central square. Villagers glance at you nervously.", false, true); // Village has an NPC
            Location cave = new Location("Cave of Echoes", "\nA dark, foreboding cave. The air is damp, and faint whispers echo from within.", true);

            // Connect locations
            forest.North = village;
            village.South = forest;
            village.East = cave;
            cave.West = village;

            CurrentLocation = forest; // Start in the Whispering Forest
        }

        public void Move(string direction)
        {
            switch (direction.ToUpper())
            {
                case "W": // North
                    if (CurrentLocation.North != null)
                        CurrentLocation = CurrentLocation.North;
                    break;
                case "S": // South
                    if (CurrentLocation.South != null)
                        CurrentLocation = CurrentLocation.South;
                    break;
                case "D": // East
                    if (CurrentLocation.East != null)
                        CurrentLocation = CurrentLocation.East;
                    break;
                case "A": // West
                    if (CurrentLocation.West != null)
                        CurrentLocation = CurrentLocation.West;
                    break;
                default:
                    Console.WriteLine("Invalid direction. Use W, A, S, or D to move.");
                    break;
            }
        }
    }
}