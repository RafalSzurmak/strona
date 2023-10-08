using System;

public class Monster
{
    public int Health { get; set; }

    public int Attack { get; }

    public int Defense { get; }

    public int GoldReward { get; }


    public Monster(int health, int attack, int defense)
    {
        Health = health;

        Attack = attack;

        Defense = defense;

        GoldReward = 10;  // Default gold reward for a monster
    }

    public void PrintStats()
    {
        Console.WriteLine("Statystyki potwora:");

        Console.WriteLine("Zdrowie: " + Health);

        Console.WriteLine("Atak: " + Attack);

        Console.WriteLine("Obrona: " + Defense);

        Console.WriteLine("Nagroda za pokonanie: " + GoldReward + " sztuk złota.");
    }
}
