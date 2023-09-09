using Engine.Models;

namespace Engine.Factories;

internal class WorldFactory
{
    internal World CreateWorld() {
        World newWorld = new World();

        newWorld.AddLocation(-2, -1, "Farmer's Field",
            "There are rows of corn growing here, with giant rats running about.",
            "/Engine;component/Images/Locations/FarmFields.png");
        
        newWorld.AddLocation(-1, -1, "Farmer's House",
            "This is the house of your neighbour, Farmer Ted.",
            "/Engine;component/Images/Locations/FarmHouse.png");

        newWorld.AddLocation(0,-1,"Home",
            "This is your home.", 
            "/Engine;component/Images/Locations/Home.png");

        newWorld.AddLocation(-1, 0, "Trading Shop",
            "The shop of Jeremiah, the trader.",
            "/Engine;component/Images/Locations/Trader.png");
        
        newWorld.AddLocation(0, 0, "Town Square",
            "You see a fountain here.",
            "/Engine;component/Images/Locations/TownSquare.png");
        
        newWorld.AddLocation(1, 0, "Town Gate",
            "There's a large gate, it probably protects the town from spiders.",
            "/Engine;component/Images/Locations/TownGate.png");
        
        newWorld.AddLocation(2, 0, "Spider Forest",
            "It's all covered in spider webs, every tree. Damn.",
            "/Engine;component/Images/Locations/SpiderForest.png");
        
        newWorld.AddLocation(0, 1, "Herbalist's Hut",
            "You see a tiny hut surrounded by potted herbs and wildflowers drying from the roof.",
            "/Engine;component/Images/Locations/HerbalistsHut.png");
        
        newWorld.AddLocation(0, 2, "Herbalist's Garden",
            "There's so many plants here, I hope there aren't any snakes.",
            "/Engine;component/Images/Locations/HerbalistsGarden.png");
        
        return newWorld;
    }
}