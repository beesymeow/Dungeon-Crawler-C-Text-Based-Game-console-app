using Item;
using Weapon;
using ItemCreation;

namespace Sword;

public class SwordClass : WeaponClass
{
    private int StrengthMultiplier { get; set; }
    public SwordClass(string name, int itemId, int minimumDamage, int maximumDamage, int strengthMultiplier)
        : base(name, itemId, minimumDamage, maximumDamage)
    {
        StrengthMultiplier = strengthMultiplier;
    }

    public static int getStrengthMultiplier(int itemId)   // Get maximum dmg from weapon, return 0 if not weapon
    {
        ItemClass findWeapon = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findWeapon is SwordClass weapon)
        {
            return weapon.StrengthMultiplier;
        }
        else
        {
            return 0;
        }
    }

   
}
