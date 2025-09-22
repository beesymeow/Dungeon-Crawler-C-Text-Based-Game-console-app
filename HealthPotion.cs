using System.Runtime;
using Item;
using ItemCreation;

namespace HealthPotion;

public class HealthPotionClass : ItemClass
{
    private int HitPointsRestored { get; set; }

    public HealthPotionClass(string name, int itemId, int hitPointsRestored)
        : base(name, itemId)
    {
        HitPointsRestored = hitPointsRestored;
    }

    public static int getHitPointsRestored(int itemId)   // Get maximum dmg from weapon, return 0 if not weapon
    {
        ItemClass findPotion = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findPotion is HealthPotionClass HealthPotion)
        {
            return HealthPotion.HitPointsRestored;
        }
        else
        {
            return 0;
        }
    }

}