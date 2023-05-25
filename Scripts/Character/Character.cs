using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string Name { get; }
    public string Description { get; }
    public string Type { get; }
    public char Rank { get; }
    public int ID { get; }

    public int Level { get; private set; }
    public int MaxLevel { get; }
    public int Power { get; private set; }
    public int Health { get; private set; }
    public int Defense { get; private set; }
    public int Attack { get; private set; }
    public int Speed { get; private set; }
    public int RequiredCoins { get; private set; }
    public int RequiredScrolls { get; private set; }

    private List<Equipament> equippedItems;

    public Character(string name, string description,string type, char rank, int id)
    {
        Name = name;
        Description = description;
        Type = type;
        Rank = rank;
        ID = id;
        equippedItems = new List<Equipament>();
    }

    public Character(int id, string name, int maxLevel, int power, string description, char rank)
    {
        ID = id;
        Name = name;
        Level = 1;
        MaxLevel = maxLevel;
        Power = power;
        Description = description;
        Rank = rank;
        CalculateLevelUpStats();
        equippedItems = new List<Equipament>();
    }
    public Character(int id, string name, int maxLevel, int power, string description, char rank, int health, int attack, int defense, int speed)
    {
        ID = id;
        Name = name;
        Level = 1;
        MaxLevel = maxLevel;
        Power = power;
        Attack = attack;
        Health = health;
        Defense = defense;
        Speed = speed;
        Description = description;
        Rank = rank;
        CalculateLevelUpStats();
        equippedItems = new List<Equipament>();
    }

    private void CalculateLevelUpStats()
    {
        RequiredCoins = CalculateRequiredCoins();
        RequiredScrolls = CalculateRequiredScrolls();
    }

    private int CalculateRequiredCoins()
    {
        int rankValue = GetRankValue(Rank);
        return Level * rankValue * 100;
    }

    private int CalculateRequiredScrolls()
    {
        int rankValue = GetRankValue(Rank);
        return Level * rankValue * 5;
    }

    private int CalculatePowerIncrease()
    {
        int rankValue = GetRankValue(Rank);
        return Level * rankValue * 10;
    }

    private int GetRankValue(char rank)
    {
        switch (rank)
        {
            case 'D': return 1;
            case 'C': return 2;
            case 'B': return 3;
            case 'A': return 4;
            case 'S': return 5;
            case 'T': return 6;
            case 'U': return 7;
            default: return 1;
        }
    }

    public bool CanLevelUp(Player player)
    {
        return Level < MaxLevel && player.Coins >= RequiredCoins && player.Scrolls >= RequiredScrolls;
    }

    public void LevelUp(Player player)
    {
        if (CanLevelUp(player))
        {
            Level++;
            Power += CalculatePowerIncrease();
            player.Coins -= RequiredCoins;
            player.Scrolls -= RequiredScrolls;
            CalculateLevelUpStats();
            Debug.Log("¡El personaje " + Name + " ha subido de nivel!");
        }
    }

    public void EquipItem(Equipament item)
    {
        equippedItems.Add(item);
        UpdateStats();
    }

    public void UnequipItem(Equipament item)
    {
        equippedItems.Remove(item);
        UpdateStats();
    }

    private void UpdateStats()
    {
        Power = 0;
        Defense = 0;
        Attack = 0;
        Health = 0;
        Speed = 0;

        foreach (var item in equippedItems)
        {
            Power += item.Power;
            Defense += item.Defense;
            Attack += item.Attack;
            Health += item.Health;
            Speed += item.Speed;
        }
    }
}

/*
 * 
 * En esta clase Character, se utilizan propiedades para representar las diferentes características del personaje, como su nombre (Name), 
 * descripción (Description), rango (Rank), y probabilidad (Probability). Puedes agregar más propiedades y estadísticas según las necesidades de tu juego.

El constructor Character se encarga de asignar los valores iniciales a las propiedades del personaje cuando se crea una nueva instancia.

Recuerda personalizar esta clase y agregar cualquier otra funcionalidad necesaria para tus personajes, como métodos para acceder y 
modificar las propiedades, calcular estadísticas, manejar habilidades, etc.
 * */
