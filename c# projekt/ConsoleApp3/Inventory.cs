using System;

public class Inventory
{
    private string[] items;
    private int[] itemLevels;
    private int gold;

    public Inventory()
    {
        items = new string[5];
        itemLevels = new int[5];

        items[0] = "Miecz +5 ataku";
        itemLevels[0] = 1;

        items[1] = "Zbroja +3 obrony";
        itemLevels[1] = 1;

        items[2] = "Laska +10 many";
        itemLevels[2] = 1;

        items[3] = "Księga zaklęć";
        itemLevels[3] = 1;

        items[4] = "Hełm +2 obrony";
        itemLevels[4] = 1;

        gold = 0;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Twój ekwipunek:");
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + items[i] + " (Poziom: " + itemLevels[i] + ")");
        }
    }

    public void OpenInventory()
    {
        DisplayInventory();
    }

    public void AddItem(string itemName, int level)
    {
        // Dodajemy przedmiot do pierwszej wolnej pozycji w ekwipunku
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemName;
                itemLevels[i] = level;
                Console.WriteLine("Dodano przedmiot: " + itemName + " (Poziom: " + level + ")");
                return;
            }
        }
        Console.WriteLine("Ekwipunek jest pełny, nie można dodać przedmiotu.");
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Length && items[index] != null)
        {
            Console.WriteLine("Usunięto przedmiot: " + items[index]);
            items[index] = null;
            itemLevels[index] = 0;
        }
        else
        {
            Console.WriteLine("Nieprawidłowy indeks przedmiotu.");
        }
    }

    public void UpgradeItem(int index)
    {
        if (index >= 0 && index < items.Length && items[index] != null)
        {
            itemLevels[index]++;
            Console.WriteLine("Ulepszono przedmiot: " + items[index] + " (Nowy poziom: " + itemLevels[index] + ")");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy indeks przedmiotu.");
        }
    }

    public void SortInventory()
    {
        Array.Sort(items, itemLevels);
        Console.WriteLine("Ekwipunek został posortowany.");
    }

    public void MoveItem(int fromIndex, int toIndex)
    {
        if (fromIndex >= 0 && fromIndex < items.Length && items[fromIndex] != null &&
            toIndex >= 0 && toIndex < items.Length && items[toIndex] == null)
        {
            items[toIndex] = items[fromIndex];
            itemLevels[toIndex] = itemLevels[fromIndex];
            items[fromIndex] = null;
            itemLevels[fromIndex] = 0;
            Console.WriteLine("Przedmiot przeniesiony z pozycji " + (fromIndex + 1) + " na pozycję " + (toIndex + 1) + ".");
        }
        else
        {
            Console.WriteLine("Nieprawidłowe indeksy przedmiotów lub pozycje są zajęte.");
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Console.WriteLine("Dodano " + amount + " sztuk złota.");
    }
}
