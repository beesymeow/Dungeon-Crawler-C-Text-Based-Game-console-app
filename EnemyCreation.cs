namespace EnemyCreation;

using Enemy;

public class EnemyCreationClass
{
    public static List<EnemyClass> allGameEnemies = new List<EnemyClass>()
    {
        new EnemyClass("Giant Rat", 0, 125, 5, 20),
        new EnemyClass("Starving Wolf", 1, 175, 8, 35),
        new EnemyClass("Bloated Slug", 2, 205, 12, 42),
        new EnemyClass("Group of Toads", 3, 250, 15, 49),
        new EnemyClass("Trio Of Goblins", 4, 300, 25, 55),
        new EnemyClass("Grotesque Ogre", 5, 325, 30, 90),
        new EnemyClass("Pete", 6, 500, 33, 120)
    };
}