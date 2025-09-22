namespace Armour;

using Item;
using ItemCreation;

public class ArmourClass : ItemClass
{
    private int ArmourRating { get; set; }

    public ArmourClass(string name, int itemId, int armourRating)
        : base(name, itemId)
    {
        ArmourRating = armourRating;
    }
    
    public static int getArmourRating(int itemId)   // Get maximum dmg from weapon, return 0 if not weapon
    {
        ItemClass findArmour = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findArmour is ArmourClass armour)
        {
            return armour.ArmourRating;
        }
        else
        {
            return 0;
        }
    }
}