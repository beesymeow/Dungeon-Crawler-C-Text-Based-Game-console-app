using Item;
using Weapon;
using ItemCreation;

namespace Staff;

public class StaffClass : WeaponClass
{

    private int AttunementMultiplier { get; set; }
    public StaffClass(string name, int itemId, int minimumDamage, int maximumDamage, int attunementMultiplier)
        : base(name, itemId, minimumDamage, maximumDamage)
    {
        AttunementMultiplier = attunementMultiplier;
    }

    public static int getAttunementMultiplier(int itemId)   // Get maximum dmg from weapon, return 0 if not weapon
    {
        ItemClass findWeapon = ItemCreationClass.allGameItems.Find(x => x.ItemId == itemId);

        if (findWeapon is StaffClass weapon)
        {
            return weapon.AttunementMultiplier;
        }
        else
        {
            return 0;
        }
    }
}