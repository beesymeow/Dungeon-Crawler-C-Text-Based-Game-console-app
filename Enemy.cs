namespace Enemy;

using EnemyCreation;
public class EnemyClass
{
    private string Name;
    public int EnemyId;

    public int Health { get; set; }

    public  int MinimumDamage { get; set; }
    public  int MaximumDamage { get; set; }



    public EnemyClass(string name, int enemyId, int health, int minimumDamage, int maximumDamage)
    {
        Name = name;
        EnemyId = enemyId;
        Health = health;
        MinimumDamage = minimumDamage;
        MaximumDamage = maximumDamage;
    }

    public virtual EnemyClass Clone()    // Creates new instance of item from the allGameItems List
    {
        return new EnemyClass(this.Name, this.EnemyId, this.Health, this.MinimumDamage, this.MaximumDamage);
    }

    public static string getEnemyName(int enemyId)
    {
        EnemyClass namedEnemy = EnemyCreationClass.allGameEnemies.Find(x => x.EnemyId == enemyId);

        if (namedEnemy is EnemyClass enemy)
        {
            return enemy.Name;
        }
        else
        {
            return "Enemy Name Unknown";
        }
    }

    public int Attack()
    {
        Random rnd = new Random();

        int damageOutputEnemy = rnd.Next(MinimumDamage, MaximumDamage + 1);

        return damageOutputEnemy;

    }
}