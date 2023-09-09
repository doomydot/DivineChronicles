using Engine.Models;

namespace Engine.ViewModels;

public class GameSession
{
    public Player CurrentPlayer { get; set; }
    
    public GameSession() {
        CurrentPlayer = new Player {
            Name = "Alice",
            Gold = 1000000,
            CharacterClass = "Fighter",
            Level = 1,
            Life = 80,
            Experience = 0
        };
    }
}