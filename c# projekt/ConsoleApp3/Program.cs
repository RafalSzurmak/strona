using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj nazwę swojej postaci:");
        string playerName = Console.ReadLine();

        Character player = new Character(playerName, 100, 10, 5, 50);
        int defeatedMonsters = 0;

        Console.WriteLine("Witaj, " + player.Name + "! Rozpoczynamy grę!");

        Random random = new Random();

        // Inicjalizacja ekwipunku

        Inventory inventory = new Inventory();

        while (player.Health > 0)
        {
            Monster[] monsters = new Monster[]
            {
                new Monster(50, 5, 2),   // Potwór 1

                new Monster(75, 8, 3),   // Potwór 2

                new Monster(90, 10, 4)   // Potwór 3
            };

            int monsterIndex = random.Next(0, monsters.Length);
            Monster currentMonster = monsters[monsterIndex];

            Console.WriteLine();
            Console.WriteLine("Pokonaj potwora nr " + (defeatedMonsters + 1) + "!");
            player.PrintStats();
            currentMonster.PrintStats();

            while (player.Health > 0 && currentMonster.Health > 0)
            {
                Console.WriteLine();

                Console.WriteLine("Wybierz akcję: ");

                Console.WriteLine("1. Słaby atak");

                Console.WriteLine("2. Silny atak (20 many)");

                Console.WriteLine("3. Otwórz ekwipunek");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int damageToMonster = player.Attack - currentMonster.Defense;
                        currentMonster.Health -= Math.Max(damageToMonster, 0);
                        Console.WriteLine("Atakujesz potwora i zadajesz " + damageToMonster + " obrażeń.");
                        break;

                    case "2":
                        if (player.Mana >= 20)
                        {
                            int damage = player.Attack * 2 - currentMonster.Defense;
                            currentMonster.Health -= Math.Max(damage, 0);
                            player.Mana -= 20;
                            Console.WriteLine("Atakujesz potwora ze zdwojoną siłą i zadajesz " + damage + " obrażeń.");
                        }
                        else
                        {
                            Console.WriteLine("Nie masz wystarczającej many do wykonania silnego ataku!");
                        }
                        break;

                    case "3":
                        inventory.DisplayInventory();
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }

                if (currentMonster.Health <= 0)
                {
                    Console.WriteLine("Pokonałeś potwora nr " + (defeatedMonsters + 1) + "!");
                    defeatedMonsters++;

                    // Zdobycie złota po pokonaniu potwora
                    int goldEarned = random.Next(10, 21); // Losowanie ilości zdobytego złota (od 10 do 20)
                    inventory.AddGold(goldEarned); // Dodanie zdobytego złota do ekwipunku
                    Console.WriteLine("Zdobyłeś " + goldEarned + " sztuk złota.");

                    break;
                }

                int damageToPlayer = currentMonster.Attack - player.Defense;
                player.Health -= Math.Max(damageToPlayer, 0);

                Console.WriteLine("Potwór atakuje i zadaje ci " + damageToPlayer + " obrażeń.");

                if (player.Health <= 0)
                {
                    Console.WriteLine("Zostałeś pokonany przez potwora...");
                    break;
                }

                player.PrintStats();
                currentMonster.PrintStats();
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Gra się skończyła. Zginąłeś w walce...");
                break;
            }
        }

        Console.WriteLine("Pokonałeś " + defeatedMonsters + " potworów! Koniec gry.");

        Console.ReadLine();
    }
}
