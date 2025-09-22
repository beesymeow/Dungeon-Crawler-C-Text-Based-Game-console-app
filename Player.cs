
namespace Player;

using Item;
using Inventory;
using Functions;
using Sword;
using Weapon;
using Stats;
using Bow;
using Staff;
using HealthPotion;
using Program;
using Leaderboard;

public class PlayerClass
{
    public string Name { get; set; }
    public string PlayerRole { get; set; }

    public int PlayerHealth { get; set; }

    public int PlayerMaxHealth { get; set; }

    public PlayerClass() { }

    public PlayerClass(string name, string playerRole)
    {
        Name = name;
        PlayerRole = playerRole;
    }

    public void SetPlayerHealth()
    {
        PlayerHealth = PlayerMaxHealth;
    }
    public void ChangePlayerMaxHealth(int vigorScaling)  // Method determines players max health with amount of vigor points have
    {
        PlayerMaxHealth = 300 + (25 * vigorScaling);

        Console.WriteLine("Your max health is now {0}", PlayerMaxHealth);   // PLAYER MAX HEALTH THEN PLAYER HEAL THEN ENEMIES LOOP THEN LEADERBOARD
    }

    public static void PlayerChangeHealth(PlayerClass player1, int damageTaken)
    {
        Random rnd = new Random();
        player1.PlayerHealth = player1.PlayerHealth - damageTaken;
        if (player1.PlayerHealth < 0)
        {
            switch (player1.PlayerRole)
            {
                case "soldier":
                    if ((rnd.Next(1, 50) * StatsClass.PlayerStats["resolve"]) / 2 > 75)
                    {
                        player1.PlayerHealth = 1;
                        FunctionsClass.WriteStory("You took lethal damage but your resolve keeps you alive.", 40, 500);
                    }
                    else
                    {
                        player1.PlayerHealth = 0;
                        FunctionsClass.WriteStory("You took lethal damage.\n\nYou are dead.", 40, 1000);
                        FunctionsClass.CreateSpace(5, 1000);

                        LeaderboardClass.GameLostLeaderboard(player1);

                        Environment.Exit(0);
                    }
                    break;

                default:
                    player1.PlayerHealth = 0;
                    FunctionsClass.WriteStory("You took lethal damage.\n\nYou are dead.", 40, 1000);
                    FunctionsClass.CreateSpace(5, 1000);

                    LeaderboardClass.GameLostLeaderboard(player1);

                    Environment.Exit(0);
                    break;
            }
        }
        FunctionsClass.WriteStory("Your health is now ", 40, 150);
        Console.Write("{0}", player1.PlayerHealth);
        
    }

    public void PlayerHeal()
    {
        ItemClass findHealthPotion = InventoryClass.PlayerInventory.FirstOrDefault(x => x.ItemId is 004);  // finds the first health pot in player inventory 

        if (findHealthPotion != null)         // Check have potion
        {
            PlayerHealth = PlayerHealth + HealthPotionClass.getHitPointsRestored(004);  // change player health

            InventoryClass.PlayerInventory.Remove(findHealthPotion);

            FunctionsClass.WriteStory("You now have ", 40, 200);
            Console.Write("{0} potions.", InventoryClass.ReturnItemAmount(004));
            
            FunctionsClass.WriteStory("You restored ", 40, 200);
            Console.Write("{0} health.", HealthPotionClass.getHitPointsRestored(004));

            if (PlayerHealth > PlayerMaxHealth)
            {
                PlayerHealth = PlayerMaxHealth;

                FunctionsClass.WriteStory("\nYou have full health.", 40, 500);
            }
            else
            {


                FunctionsClass.WriteStory("Your health is now ", 40, 200);
                Console.Write("{0}", PlayerHealth);
            }
        }
        else
        {
            FunctionsClass.WriteStory("You have no health potions.", 40, 500);
        }


       
    }

    public static int PlayerDamageReduction(int damageTaken, int armourRating, int defence)
    {
        int finalDamageTaken = damageTaken - (armourRating + defence);
        return finalDamageTaken;
    }

    

    public static int damageOutput = 0;
    public static void Attack(PlayerClass player1)
    {
        bool weaponChoiceComplete = false;
        Random rnd = new Random(); // Generate random number 
        damageOutput = 0; // Set damageOutput to 0 each time attack called.

        switch (player1.PlayerRole)  // Case for each class as theyhave different attacks
        {
            case "soldier":

                FunctionsClass.WriteStory("Do you attack with your sword?\nEnter: ", 40, 500);
                string attackWithSwordChoice = Console.ReadLine().Trim().ToLower();

                if (attackWithSwordChoice.Contains("yes"))
                {
                    FunctionsClass.WriteStory("You attack with your sword", 40, 500);
                    damageOutput = rnd.Next(WeaponClass.getMinimumDamage(001), WeaponClass.getMaximumDamage(001) + 1) + (StatsClass.PlayerStats["strength"] * SwordClass.getStrengthMultiplier(001));
                    FunctionsClass.WriteStory("You dealt ", 40, 100);
                    Console.Write("{0} damage.", damageOutput);
                }
                else if (attackWithSwordChoice.Contains("no"))
                {
                    FunctionsClass.WriteStory("You have no other options.\nYou missed your oppurtunity to attack.\n", 40, 500);
                }
                else
                {
                    FunctionsClass.WriteStory("Please enter \"Yes\" or \"No\"\nYou missed your oppurtunity to attack.\n", 40, 500);
                }

                break;

            case "archer":

                ItemClass findFirstArrow = InventoryClass.PlayerInventory.FirstOrDefault(x => x.ItemId is 008);  // finds the first arrow in player inventory 

                while (!weaponChoiceComplete)
                {
                    FunctionsClass.WriteStory("What weapon would you like to use.\nBow or Dagger?\nEnter: ", 40, 500);
                    string whatWeaponChoice = Console.ReadLine().Trim().ToLower();          // Player makes choice bow or dagger, if no arrows then option to use dagger
                    if (whatWeaponChoice.Contains("bow") && findFirstArrow != null)
                    {
                        if (rnd.Next(1, 50) * StatsClass.PlayerStats["resolve"] / 2 > 200)
                        {
                            damageOutput = 1000;
                            FunctionsClass.WriteStory("You hit the enemy in a vital spot severely injuring it.", 40, 500);
                        }
                        else
                        {
                            damageOutput = rnd.Next(WeaponClass.getMinimumDamage(002), WeaponClass.getMaximumDamage(002) + 1) + (StatsClass.PlayerStats["dexterity"] * BowClass.getDexterityMultiplier(002));  // Player attacks with arrow and removes 1 arrow from inventory
                        }
                        FunctionsClass.WriteStory("You dealt ", 40, 100);
                        Console.Write("{0} damage.", damageOutput);

                        InventoryClass.PlayerInventory.Remove(findFirstArrow);

                        weaponChoiceComplete = true;

                    }
                    else if (whatWeaponChoice.Contains("dagger"))
                    {
                        damageOutput = rnd.Next(WeaponClass.getMinimumDamage(010), WeaponClass.getMaximumDamage(010) + 1) + (StatsClass.PlayerStats["strength"] * SwordClass.getStrengthMultiplier(010));  //player attacs with dagger and ends turn
                        FunctionsClass.WriteStory("You dealt ", 40, 100);
                        Console.Write("{0} damage.", damageOutput);
                        weaponChoiceComplete = true;
                    }
                    else if (string.IsNullOrEmpty(whatWeaponChoice) || !(whatWeaponChoice.Contains("bow") ^ whatWeaponChoice.Contains("dagger")))
                    {
                        FunctionsClass.WriteStory("Please choose: Bow or Dagger.", 40, 400);
                    }
                    else
                    {
                        FunctionsClass.WriteStory("You have no arrows.\nYou can still use the dagger.", 40, 500);
                    }
                }
                break;

            case "mage":

                ItemClass findFirstRune = InventoryClass.PlayerInventory.FirstOrDefault(x => x.ItemId is 009);  // finds the first rune in player inventory

                while (!weaponChoiceComplete)
                {
                    FunctionsClass.WriteStory("What weapon would you like to use.\nStaff or Dagger?\nEnter: ", 40, 500);
                    string whatWeaponChoice = Console.ReadLine().Trim().ToLower();          // Player makes choice staff or dagger, if no runes then option to use dagger
                    if (whatWeaponChoice.Contains("staff") && findFirstRune != null)
                    {
                        if ((rnd.Next(1, 50) * StatsClass.PlayerStats["resolve"]) / 2 > 200)
                        {
                            damageOutput = 1000;
                            FunctionsClass.WriteStory("You channeled incredibly powerful magic. Removing your foe from existance.", 40, 500);
                        }
                        else
                        {
                            damageOutput = rnd.Next(WeaponClass.getMinimumDamage(003), WeaponClass.getMaximumDamage(003) + 1) + (StatsClass.PlayerStats["attunement"] * StaffClass.getAttunementMultiplier(003));  // Player attacks with arrow and removes 1 arrow from inventory
                        }
                        FunctionsClass.WriteStory("You dealt ", 40, 100);
                        Console.Write("{0} damage.", damageOutput);

                        InventoryClass.PlayerInventory.Remove(findFirstRune);

                        weaponChoiceComplete = true;

                    }
                    else if (whatWeaponChoice.Contains("dagger"))
                    {
                        damageOutput = rnd.Next(WeaponClass.getMinimumDamage(011), WeaponClass.getMaximumDamage(011) + 1) + (StatsClass.PlayerStats["strength"] * SwordClass.getStrengthMultiplier(011));  //player attacs with dagger and ends turn
                        FunctionsClass.WriteStory("You dealt ", 40, 100);
                        Console.Write("{0} damage.", damageOutput);
                        weaponChoiceComplete = true;
                    }
                    else if (string.IsNullOrEmpty(whatWeaponChoice) || !(whatWeaponChoice.Contains("staff") ^ whatWeaponChoice.Contains("dagger")))
                    {
                        FunctionsClass.WriteStory("Please choose: Staff or Dagger.", 40, 400);
                    }
                    else
                    {
                        FunctionsClass.WriteStory("You have no runes.\nYou can still use the dagger.", 40, 500);
                    }
                }
                break;
        }
    } 
}


