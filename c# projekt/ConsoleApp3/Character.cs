using System;

public class Character
{
    public string Name { get; }
    public int Health { get; set; }
    public int Attack { get; }
    public int Defense { get; }
    public int Mana { get; set; }
    public Inventory Inventory { get; }
    public int Gold { get; set; }

    public Character(string name, int health, int attack, int defense, int mana)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Mana = mana;
        Inventory = new Inventory();
        Gold = 0;
    }

    public void PrintStats()
    {
        Console.WriteLine("Statystyki postaci:");
        Console.WriteLine("Nazwa postaci: " + Name);
        Console.WriteLine("Zdrowie: " + Health);
        Console.WriteLine("Atak: " + Attack);
        Console.WriteLine("Obrona: " + Defense);
        Console.WriteLine("Mana: " + Mana);
        Console.WriteLine("Złoto: " + Gold);
    }
}
