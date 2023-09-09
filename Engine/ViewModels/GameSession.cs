using System.ComponentModel;
using Engine.Factories;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels;

public class GameSession : INotifyPropertyChanged
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

        WorldFactory factory = new WorldFactory();
        CurrentWorld = factory.CreateWorld();

        CurrentLocation = CurrentWorld.LocationAt(0, -1);
    }

    public void MoveNorth() {
        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
    }

    public void MoveSouth() {
        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);    }

    public void MoveEast() {
        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
    }

    public void MoveWest() {
        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}