namespace Engine.Models;

public class Weapon : GameItem
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage) 
        : base(itemTypeID, name, price) {
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }
    
    public override Weapon Clone() {
        return new Weapon(ItemTypeID, Name, Price, MinDamage, MaxDamage);
    }
}