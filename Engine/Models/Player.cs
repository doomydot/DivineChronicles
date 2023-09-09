using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Engine.Models;


public class Player : INotifyPropertyChanged
{
    private string _name;
    private string _characterClass;
    private int _life;
    private int _experience;
    private int _level;
    private int _gold;

    public string Name {
        get => _name;
        set {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string CharacterClass {
        get => _characterClass;
        set {
            _characterClass = value;
            OnPropertyChanged(nameof(CharacterClass));
        }
    }

    public int Life {
        get => _life;
        set {
            _life = value;
            OnPropertyChanged(nameof(Life));
        }
    }

    public int Experience {
        get => _experience;
        set {
            _experience = value;
            OnPropertyChanged(nameof(Experience));
        } 
    }

    public int Level {
        get => _level;
        set {
            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

    public int Gold {
        get => _gold;
        set {
            _gold = value;
            OnPropertyChanged(nameof(Gold));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}