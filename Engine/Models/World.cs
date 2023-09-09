namespace Engine.Models;

public class World
{
    private List<Location> _locations = new();


    internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName) {
        Location loc = new Location();
        loc.XCoordinate = xCoordinate;
        loc.YCoordinate = yCoordinate;
        loc.Name = name;
        loc.Description = description;
        loc.ImageName = imageName;

        _locations.Add(loc);
    }

    public Location? LocationAt(int xCoordinate, int yCoordinate) {
        return _locations.FirstOrDefault(loc => loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate);
    }
}