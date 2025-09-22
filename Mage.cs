namespace Mage;

using Role;
using Inventory;
using System.Reflection;

public class MageClass : RoleClass
{
    private int AttunementBonus { get; set; }
    private int VigorBonus { get; set; }

    public MageClass(string name, List<int> stats, int attunementBonus, int vigorBonus)
        : base(name, stats)
    {
        AttunementBonus = attunementBonus;
        VigorBonus = vigorBonus;
    }
}

