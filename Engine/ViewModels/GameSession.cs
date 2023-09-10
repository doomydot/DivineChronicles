using System.ComponentModel;
using Engine.Factories;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels;

public class GameSession : BaseNotificationClass
{
    private Location _currentLocation;
    
    public Player CurrentPlayer { get; set; }

    public Location CurrentLocation {
        get => _currentLocation;
        set {
            _currentLocation = value;
            OnPropertyChanged(nameof(CurrentLocation));
            
            OnPropertyChanged(nameof(HasLocationToNorth));
            OnPropertyChanged(nameof(HasLocationToSouth));
            OnPropertyChanged(nameof(HasLocationToEast));
            OnPropertyChanged(nameof(HasLocationToWest));
        }
    }
    public World CurrentWorld { get; set; }

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
}