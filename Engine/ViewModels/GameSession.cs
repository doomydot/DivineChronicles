using System.ComponentModel;
using Engine.Factories;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels;

public class GameSession : BaseNotificationClass
{
    private Location _currentLocation;
    private Monster? _currentMonster;
    
    public Player CurrentPlayer { get; set; }

    public World CurrentWorld { get; set; }

    public Location CurrentLocation {
        get => _currentLocation;
        set {
            _currentLocation = value;
            OnPropertyChanged(nameof(CurrentLocation));
            
            OnPropertyChanged(nameof(HasLocationToNorth));
            OnPropertyChanged(nameof(HasLocationToSouth));
            OnPropertyChanged(nameof(HasLocationToEast));
            OnPropertyChanged(nameof(HasLocationToWest));

            GivePlayerQuestsAtLocation();
            GetMonsterAtLocation();
        }
    }

    public Monster? CurrentMonster {

        get => _currentMonster;
        set {
            _currentMonster = value;

            OnPropertyChanged(nameof(CurrentMonster));
            OnPropertyChanged(nameof(HasMonster));
        }
    }

    public bool HasMonster => CurrentMonster != null;
    
    public bool HasLocationToNorth => 
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;

    public bool HasLocationToSouth =>
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;

    public bool HasLocationToEast =>
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;

    public bool HasLocationToWest =>
        CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;

    public GameSession() {
        CurrentPlayer = new Player {
            Name = "Alice",
            Gold = 1000000,
            CharacterClass = "Fighter",
            Level = 1,
            Life = 80,
            Experience = 0
        };

        
        CurrentWorld = WorldFactory.CreateWorld();

        CurrentLocation = CurrentWorld.LocationAt(0, -1);
    }

    
    // Nullable warning suppressed in all the Move methods as the if-statement prevents it from setting a null value
    public void MoveNorth() {
        if (HasLocationToNorth) {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }
    }

    public void MoveSouth() {
        if (HasLocationToSouth) {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }
    }

    public void MoveEast() {
        if (HasLocationToEast) {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }
    }

    public void MoveWest() {
        if (HasLocationToWest) {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }
    }

    private void GivePlayerQuestsAtLocation() {
        foreach (var quest in CurrentLocation.QuestsAvailableHere) {
            // Checks Players Quests for Current Locations quest.ID, adds it if not found
            if (CurrentPlayer.Quests.All(q => q.PlayerQuest.ID != quest.ID)) {
                CurrentPlayer.Quests.Add(new QuestStatus(quest));
            }
        }
    }

    private void GetMonsterAtLocation() {
        CurrentMonster = CurrentLocation.GetMonster();
    }
}