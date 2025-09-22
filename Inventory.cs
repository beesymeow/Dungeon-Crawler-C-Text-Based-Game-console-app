namespace Inventory;

using System.Linq;
using Item;
using Player;
using ItemCreation;
using System.Security.Cryptography.X509Certificates;
using Ammo;

public class InventoryClass
{
    public static List<ItemClass> PlayerInventory { get; set; } = [];

    public static void AddItem(int itemId)   // Gives item to player inventory from allGameItems List
    {
        ItemClass copiedItem = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (copiedItem != null)
        {
            PlayerInventory.Add(copiedItem.Clone());
        }
    }

    public static int ReturnItemAmount(int itemId)
    {

        return InventoryClass.PlayerInventory.Count(x => x.ItemId == itemId);
    }

}