namespace Weapon;

using Item;
using ItemCreation;

public class WeaponClass : ItemClass
{
    private int MinimumDamage { get; set; }
    private int MaximumDamage { get; set; }

    public WeaponClass(string name, int itemId, int minimumDamage, int maximumDamage)
        : base(name, itemId)
    {
        MinimumDamage = minimumDamage;
        MaximumDamage = maximumDamage;
    }
 
    public static int getMinimumDamage(int itemId)         // Gets the min damage from a weapon, returns 0 is not a weapon
    {
        ItemClass findWeapon = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findWeapon is WeaponClass weapon)
        {
            return weapon.MinimumDamage;
        }
        else
        {
            return 0;
        }
    }

    public static int getMaximumDamage(int itemId)   // Get maximum dmg from weapon, return 0 if not weapon
    {
        ItemClass findWeapon = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findWeapon is WeaponClass weapon)
        {
            return weapon.MaximumDamage;
        }
        else
        {
            return 0;
        }
    }

}