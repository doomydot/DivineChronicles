using System.Collections.ObjectModel;

namespace Engine.Models;

public class Monster : BaseNotificationClass
{
    private int _life;
    
    public string Name { get; private set; }
    public string ImageName { get; set; }
    public int MaximumLife { get; private set; }

    public int Life {
        get => _life;
        private set {
            _life = value;
            OnPropertyChanged(nameof(Life));
        }
    }
    
    public int RewardExperiencePoints { get; private set; }
    public int RewardGold { get; private set; }
    
    public ObservableCollection<ItemQuantity> Inventory { get; set; }

    public Monster(string name, string imageName,
        int maximumLife, int life,
        int rewardExperiencePoints, int rewardGold) {

        Name = name;
        ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
        MaximumLife = maximumLife;
        Life = life;
        RewardExperiencePoints = rewardExperiencePoints;
        RewardGold = rewardGold;

        Inventory = new ObservableCollection<ItemQuantity>();
    }
        
}