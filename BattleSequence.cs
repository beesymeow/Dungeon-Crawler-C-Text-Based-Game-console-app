using Functions;
using Enemy;
using Player;
using EnemyCreation;
using Armour;
using Stats;

namespace BattleSequence;

public class BattleSequenceClass
{
    public static List<EnemyClass> EngagedEnemiesList { get; set; } = []; // Holds list of engaged enemies corresponding to what encounter are on


    public static void AddEnemy(int enemyId)   // Gives enemy to engaged enemy list so can know what enemy dealing with
    {
        EnemyClass copiedEnemy = EnemyCreationClass.allGameEnemies.Find(x => x.EnemyId == enemyId);

        if (copiedEnemy != null)
        {
            EngagedEnemiesList.Add(copiedEnemy.Clone());
        }
    }

    public static void BattleStart(int totalBattleCount, PlayerClass player1)
    {
        AddEnemy(totalBattleCount);

        int currentEnemyHealth = EngagedEnemiesList[totalBattleCount].Health;          // Variables of enemy health id and player damage to be used later
        int currentEnemyId = EngagedEnemiesList[totalBattleCount].EnemyId;
        int playerDamageRecieved = 0;

        FunctionsClass.WriteStory("You are engaged in combat with: ", 40, 100);
        Console.Write("{0}", EnemyClass.getEnemyName(currentEnemyId));              // Shows player who they are fighting

        while (currentEnemyHealth > 0 && player1.PlayerHealth > 0)
        {




            switch (player1.PlayerRole)        // Depending class will have different armour, so this switch changes damage recieved with PlayerDamageReduction method from playerclass
            {
                case "soldier":
                    playerDamageRecieved = PlayerClass.PlayerDamageReduction(EngagedEnemiesList[totalBattleCount].Attack(), ArmourClass.getArmourRating(005), StatsClass.PlayerStats["defence"]);
                    break;

                case "archer":
                    playerDamageRecieved = PlayerClass.PlayerDamageReduction(EngagedEnemiesList[totalBattleCount].Attack(), ArmourClass.getArmourRating(006), StatsClass.PlayerStats["defence"]);
                    break;

                case "mage":
                    playerDamageRecieved = PlayerClass.PlayerDamageReduction(EngagedEnemiesList[totalBattleCount].Attack(), ArmourClass.getArmourRating(007), StatsClass.PlayerStats["defence"]);
                    
                    break;
            }

            FunctionsClass.WriteStory("\nThe ", 40, 100);
            Console.Write("{0}", EnemyClass.getEnemyName(currentEnemyId));  // Display how much damage was received adn new player health
            FunctionsClass.WriteStory("attacked you for ", 40, 200);
            Console.Write("{0}\n", playerDamageRecieved);

            PlayerClass.PlayerChangeHealth(player1, playerDamageRecieved);

            PlayerClass.Attack(player1);

            currentEnemyHealth = currentEnemyHealth - PlayerClass.damageOutput;        // Player attacks and display new enemy health

            
            FunctionsClass.WriteStory("\nThe ", 40, 200);
            Console.Write("{0}", EnemyClass.getEnemyName(currentEnemyId));   
            FunctionsClass.WriteStory("now has ", 40, 250);

            if (currentEnemyHealth <= 0)
            {
                Console.Write("0 health");
            }
            else
            {
                Console.Write("{0} health.", currentEnemyHealth);
            }
            

        }

        if (currentEnemyHealth <= 0)
        {
            FunctionsClass.WriteStory("The ", 40, 100);
            Console.Write("{0}", EnemyClass.getEnemyName(currentEnemyId));   // Display enemy has been defeated // If enemy died end the loop, go next
            FunctionsClass.WriteStory("has been defeated.", 40, 500);

            FunctionsClass.WriteStory("---------------\nYou recieved 2 skill points\n---------------", 20, 300);
            StatsClass.StatPoints[0] += 2;
        }
        
    }
}