using Engine.Factories;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels;

public class GameSession
{
    public Player CurrentPlayer { get; set; }
    public Location CurrentLocation { get; set; }
    public World CurrentWorld { get; set; }
    
    public GameSession() {
        CurrentPlayer = new Player {
            Name = "Alice",
            Gold = 1000000,
            CharacterClass = "Fighter",
            Level = 1,
            Life = 80,
            Experience = 0
        };

        WorldFactory factory = new WorldFactory();
        CurrentWorld = factory.CreateWorld();

        CurrentLocation = CurrentWorld.LocationAt(0, -1);
    }
}