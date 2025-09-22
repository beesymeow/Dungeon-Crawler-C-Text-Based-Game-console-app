namespace ItemCreation;

using Armour;
using Bow;
using HealthPotion;
using Item;
using Staff;
using Sword;
using Ammo;
using Weapon;

public class ItemCreationClass
{
    public static List<ItemClass> allGameItems = new List<ItemClass>()       // All game items cloned from this list
    {
        new SwordClass("Unnamed Soldier's Rusty Sword", 001, 10, 30, 10),
        new BowClass("Unnamed Archer's Weathered Bow", 002, 10, 40, 10),
        new StaffClass("Unnamed Mage's Rotting Staff", 003, 10, 50, 10),
        new HealthPotionClass("Health Potion", 004, 100),
        new ArmourClass("Soldier's Armour", 005, 3),
        new ArmourClass("Archer's Light Armour", 006, 2),
        new ArmourClass("Mage's Robes", 007, 1),
        new AmmoClass("Arrow", 008, 0.5),
        new AmmoClass("Rune", 009, 0.8),
        new SwordClass("Hunting Knife", 010, 8, 25, 10),
        new SwordClass("Ornamental Dagger", 011, 5, 20, 10)
    };

        


}   