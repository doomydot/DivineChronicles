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
            Level = 3,
            HP = 80,
            XP = 200
        };
    }
}