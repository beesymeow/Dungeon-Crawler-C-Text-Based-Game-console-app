namespace Soldier;

using Role;
using Inventory;

public class SoldierClass : RoleClass
{
    private int StrengthBonus { get; set; }
    private int DefenceBonus { get; set; }

    public SoldierClass(string name, List<int> stats, int strengthBonus, int defenceBonus)
        : base(name, stats)
    {
        StrengthBonus = strengthBonus;
        DefenceBonus = defenceBonus;
    }
}
