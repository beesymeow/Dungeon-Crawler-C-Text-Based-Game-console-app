namespace Functions;

using Inventory;

public static class FunctionsClass // Public Methods
{
    public static void WriteStory(string sentence, int characterTiming, int waitTillNext) // WriteStory method to write text to console letter by letter.
    {
        Console.WriteLine("");
        foreach (char c in sentence)
        {
            Console.Write(c);
            Thread.Sleep(characterTiming);
        }
        Thread.Sleep(waitTillNext);
    }

    public static void CreateSpace(int spaceLength, int timeBetweenSpaces) // CreateSpace loops to create a gap in console 
    {
        for (int i = 0; i < spaceLength; i++)
        {
            Console.WriteLine(" ");
            Thread.Sleep(timeBetweenSpaces);
        }
    }

    public static void WriteAsciiTitle()
    {
        string asciiTitle = @" .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--. 
/ .. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \
\ \/\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ \/ /
 \/ /`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'\/ / 
 / /\                                                    / /\ 
/ /\ \  ██▄     ▄      ▄     ▄▀  ▄███▄   ████▄    ▄     / /\ \
\ \/ /  █  █     █      █  ▄▀    █▀   ▀  █   █     █    \ \/ /
 \/ /   █   █ █   █ ██   █ █ ▀▄  ██▄▄    █   █ ██   █    \/ / 
 / /\   █  █  █   █ █ █  █ █   █ █▄   ▄▀ ▀████ █ █  █    / /\ 
/ /\ \  ███▀  █▄ ▄█ █  █ █  ███  ▀███▀         █  █ █   / /\ \
\ \/ /         ▀▀▀  █   ██                     █   ██   \ \/ /
 \/ /                                                    \/ / 
 / /\   ▄█▄    █▄▄▄▄ ██     ▄ ▄   █     ▄███▄   █▄▄▄▄    / /\ 
/ /\ \  █▀ ▀▄  █  ▄▀ █ █   █   █  █     █▀   ▀  █  ▄▀   / /\ \
\ \/ /  █   ▀  █▀▀▌  █▄▄█ █ ▄   █ █     ██▄▄    █▀▀▌    \ \/ /
 \/ /   █▄  ▄▀ █  █  █  █ █  █  █ ███▄  █▄   ▄▀ █  █     \/ / 
 / /\   ▀███▀    █      █  █ █ █      ▀ ▀███▀     █      / /\ 
/ /\ \          ▀      █    ▀ ▀                  ▀      / /\ \
\ \/ /                ▀                                 \ \/ /
 \/ /                                                    \/ / 
 / /\.--..--..--..--..--..--..--..--..--..--..--..--..--./ /\ 
/ /\ \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \/\ \
\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `' /
 `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--' ";
        WriteStory(asciiTitle, 0, 1000);
    }

    public static void ItemExists(int itemId)
    {
        Console.WriteLine("\nExists: Item with Id={0}: {1}",          // Check if item exists in the player inventory
        itemId, InventoryClass.PlayerInventory.Exists(x => x.ItemId == itemId));
    }

    public static void ItemAmount(int itemId)
    {
        Console.WriteLine("The amount of Item with Id={0}: {1}",
        itemId,
        InventoryClass.PlayerInventory.Count(x => x.ItemId == itemId));
    }
    


}
