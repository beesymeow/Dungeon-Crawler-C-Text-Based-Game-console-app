namespace Ammo;

using Item;

public class AmmoClass : ItemClass
{
    private double DamageModifier { get; set; }


    public AmmoClass(string name, int itemId, double damageModifier)
        : base(name, itemId)
    {
        DamageModifier = damageModifier;
    
    }
}