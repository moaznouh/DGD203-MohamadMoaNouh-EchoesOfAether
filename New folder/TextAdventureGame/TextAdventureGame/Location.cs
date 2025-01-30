namespace TextAdventureGame
{
    class Location
    {
        public string Name { get; }
        public string Description { get; }
        public bool HasInteractiveElement { get; }
        public bool HasNPC { get; } // New property for NPC
        public Location North { get; set; }
        public Location South { get; set; }
        public Location East { get; set; }
        public Location West { get; set; }

        public Location(string name, string description, bool hasInteractiveElement, bool hasNPC = false)
        {
            Name = name;
            Description = description;
            HasInteractiveElement = hasInteractiveElement;
            HasNPC = hasNPC; // Initialize NPC property
        }
    }
}