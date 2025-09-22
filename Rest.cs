namespace Rest;

using Functions;
using Item;
using Inventory;
using Player;
using Stats;
using Leaderboard;

public class RestClass
{
    public static void Rest(PlayerClass player1)
    {
        bool restChoiceMade = false;
        string userRestChoice = "";

        FunctionsClass.WriteStory("You take a rest before proceeding.\n\n", 40, 500);

        while (!restChoiceMade)
        {
            FunctionsClass.WriteStory("Proceed. Heal. View Stats. Quit.\n\nEnter: ", 40, 500);
            userRestChoice = Console.ReadLine().Trim().ToLower();

            switch (userRestChoice)
            {
                case "proceed":
                    restChoiceMade = true;
                    break;

                case "heal":
                    player1.PlayerHeal();
                    break;

                case "view stats":
                    StatsClass.ViewPlayerStats();
                    break;

                case "quit":
                    LeaderboardClass.GameQuitLeaderboard(player1);
                    Environment.Exit(0);
                    break;

                default:
                    FunctionsClass.WriteStory("Please try again.", 40, 500);
                    break;


            }

        }

        switch (player1.PlayerRole)
        {
            case "soldier":
                InventoryClass.AddItem(004);
                InventoryClass.AddItem(004);
                FunctionsClass.WriteStory("You picked up two health potions you found in the room.", 40, 500);
                break;

            case "mage":
                InventoryClass.AddItem(009);
                InventoryClass.AddItem(009);
                InventoryClass.AddItem(009);
                InventoryClass.AddItem(004);
                FunctionsClass.WriteStory("You picked up three runes and one health potion you found in the room.", 40, 500);
                break;

            case "archer":
                InventoryClass.AddItem(008);
                InventoryClass.AddItem(008);
                InventoryClass.AddItem(008);
                InventoryClass.AddItem(004);
                FunctionsClass.WriteStory("You picked up three arrows and one health potion you found in the room.\n", 40, 500);

                break; 
                
        }

    }
}