namespace Archer;

using Role;
using Inventory;

public class ArcherClass : RoleClass
{
    private int DexterityBonus { get; set; }
    private int StrengthBonus { get; set; }

    public ArcherClass(string name, List<int> stats, int dexterityBonus, int strengthBonus)
        : base(name, stats)
    {
        DexterityBonus = dexterityBonus;
        StrengthBonus = strengthBonus;
    }
}