using Item;
using Weapon;
using ItemCreation;

namespace Bow;

public class BowClass : WeaponClass
{
    private int DexterityMultiplier { get; set; }
    public BowClass(string name, int itemId, int minimumDamage, int maximumDamage, int dexterityMultiplier)
        : base(name, itemId, minimumDamage, maximumDamage)
    {
        DexterityMultiplier = dexterityMultiplier;
    }

    public static int getDexterityMultiplier(int itemId)   // Get maximum dmg from weapon, return 0 if not weapon
    {
        ItemClass findWeapon = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findWeapon is BowClass weapon)
        {
            return weapon.DexterityMultiplier;
        }
        else
        {
            return 0;
        }
    }
}