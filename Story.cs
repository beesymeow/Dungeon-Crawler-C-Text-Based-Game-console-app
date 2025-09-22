namespace Story;

using Functions;
using Inventory;
using Player;
using Program;
using System;
using System.Security.Cryptography.X509Certificates;
using Stats;
using Leaderboard;

public class StoryClass
{

    public static void IntroStory() // Writes out the introduction to story
    {
        FunctionsClass.CreateSpace(150, 1);  // Creates blank space in console for game experience

        FunctionsClass.WriteStory("Please expand your console to about half the screen for the best experience.", 40, 5000);

        FunctionsClass.CreateSpace(2, 1);

        FunctionsClass.WriteStory("Choose: Start or Leaderboard.\nEnter: ", 40, 500);

        string startChoice = "";
        bool startChoiceLoop = false;

        while (!startChoiceLoop)
        {
            startChoice = Console.ReadLine().Trim().ToLower();

            switch (startChoice)
            {
                case "start":
                    startChoiceLoop = true;
                    break;

                case "leaderboard":

                    FunctionsClass.CreateSpace(1, 10);
                    LeaderboardClass.ShowLeaderboard();

                    FunctionsClass.WriteStory("\nPress enter to continue.", 40, 500);
                    Console.ReadLine();

                    startChoiceLoop = true;

                    break;

                default:
                    FunctionsClass.WriteStory("Please choose \"Start\" or \"Leaderboard\"\nEnter: ", 40, 500);
                    break;
            }
        }

        

        FunctionsClass.WriteStory("Game Start!", 50, 100);

        FunctionsClass.CreateSpace(5, 1);

        FunctionsClass.WriteStory("You are running.", 100, 500);          // Story starts

        FunctionsClass.WriteStory("Branches and brush thwack into you limiting your view.", 40, 500);

        FunctionsClass.WriteStory("The taunting shouts of the bandit group follow you close behind.", 40, 500);

        FunctionsClass.WriteStory("You endure the fatigue, hoping to escape with your life.", 40, 500);

        FunctionsClass.WriteStory("The thicket of the forest suddenly clears.", 40, 500);

        FunctionsClass.WriteStory("You no longer feel the ground below you.", 40, 500);

        FunctionsClass.WriteStory("until...", 40, 500);

        FunctionsClass.WriteStory("*thud*.", 40, 500);

        FunctionsClass.WriteStory("*thud* \n*thud* \n*thud*", 40, 500);

        FunctionsClass.WriteStory("rocks fall next to you as you hurl down the cliff side.", 40, 500);

        FunctionsClass.WriteStory("You struggle to take control of the situation.", 40, 500);

        FunctionsClass.WriteStory("You lose consciousness.", 40, 500);

        FunctionsClass.CreateSpace(2, 1500);

        FunctionsClass.CreateSpace(3, 1100);

        FunctionsClass.CreateSpace(4, 720);

        FunctionsClass.WriteAsciiTitle();   // Title screen

        FunctionsClass.CreateSpace(4, 500);

        FunctionsClass.WriteStory("Your name, you think but struggle to remember.", 40, 500);



    }

    public static void GraveScene(PlayerClass player1)
    {
        string playerName = "";

        while (string.IsNullOrEmpty(playerName))
        {
            FunctionsClass.WriteStory("What was it again... \nEnter Name: ", 40, 300);
            playerName = Console.ReadLine();

            if (string.IsNullOrEmpty(playerName))
            {
                FunctionsClass.WriteStory("Input cannot be empty, please try again.", 40, 200);
            }
        }

        player1.Name = playerName;

        FunctionsClass.WriteStory(player1.Name + "... Yes, yes. That must have been it.\n", 40, 500);

        FunctionsClass.WriteStory("In front of you are three graves with an assortment of items spread out.", 40, 500);

        FunctionsClass.WriteStory("Left to right the graves read: Unnamed Soldier, Unnamed Mage, Unnamed Archer", 40, 250);

        FunctionsClass.CreateSpace(1, 0);

        FunctionsClass.WriteStory("The Soldier's grave is littered with a rusting sword, three health potions, \nheavy looking armour and a small journal detailing a soldiers combat techniques.", 40, 1000);

        FunctionsClass.CreateSpace(1, 0);

        FunctionsClass.WriteStory("The Mage's grave has a staff, one health potion, two mana potions, a tome \ncontaining basic magic spells and some robes, laid out neatly.", 40, 1000);

        FunctionsClass.CreateSpace(1, 0);

        FunctionsClass.WriteStory("The Archer's grave holds a bow, a quiver of arrows, 2 health potions, a hunting knife, a set \nof light looking armour, as well as a book detailing some findings about monsters.", 40, 1000);

        FunctionsClass.CreateSpace(1, 0);

    }

    public static void RoleSelectionScene(PlayerClass player1) // player input determines the role they get
    {
        string classSelection = "";

        while (string.IsNullOrEmpty(classSelection) || !classSelection.Contains("soldier") ^ !classSelection.Contains("mage") ^ !classSelection.Contains("archer"))
        // while input is invalid repeat asking
        {
            FunctionsClass.WriteStory("Which set of items do you pick up?\nEnter: \"Soldier\", \"Mage\", \"Archer\".\n", 40, 500);
            classSelection = Console.ReadLine().Trim().ToLower();


            if (classSelection.Contains("soldier"))
            {
                FunctionsClass.WriteStory("You picked up the soldier's items", 40, 500);
                InventoryClass.AddItem(001);
                InventoryClass.AddItem(005);
                InventoryClass.AddItem(004);
                InventoryClass.AddItem(004);
                InventoryClass.AddItem(004);
                player1.PlayerRole = "soldier";
            }
            else if (classSelection.Contains("mage"))
            {
                FunctionsClass.WriteStory("You picked up the mage's items", 40, 500);
                InventoryClass.AddItem(003);
                InventoryClass.AddItem(007);
                InventoryClass.AddItem(009);
                InventoryClass.AddItem(009);
                InventoryClass.AddItem(009);
                InventoryClass.AddItem(004);

                player1.PlayerRole = "mage";
            }
            else if (classSelection.Contains("archer"))
            {
                FunctionsClass.WriteStory("You picked up the archer's items", 40, 500);
                InventoryClass.AddItem(002);
                InventoryClass.AddItem(006);
                InventoryClass.AddItem(008);
                InventoryClass.AddItem(008);
                InventoryClass.AddItem(008);
                InventoryClass.AddItem(004);
                InventoryClass.AddItem(004);

                player1.PlayerRole = "archer";
            }
            else if (string.IsNullOrEmpty(classSelection))
            {
                FunctionsClass.WriteStory("Please try again and choose from the graves in front of you.", 40, 500);
            }
        }
    }

    public static void StatExplanationScene()
    {
        FunctionsClass.CreateSpace(5, 250);

        FunctionsClass.WriteStory("-------------------------------", 40, 400);

        FunctionsClass.WriteStory("You are about to enter the character spec menu.", 40, 500);

        FunctionsClass.WriteStory("When this menu shows, you will have the oppurtunity to increase your stats.", 40, 500);
        FunctionsClass.WriteStory("Each stat affects the player differently, below is every stat and what it affects.", 40, 500);
        FunctionsClass.CreateSpace(2, 100);
        FunctionsClass.WriteStory("Strength: Modifies the amount of damage a melee weapon will deal.\nAttunement: Modifies the amount of damage a spell will deal.", 40, 0);
        FunctionsClass.WriteStory("Dexterity: Modifies the amount of damage a physical ranged weapon will deal.\nVigor: Increase the amount of hit points the player has.", 40, 0);
        FunctionsClass.WriteStory("Defence: Decrease the damage taken by the player from attacks.\nResolve: Unique effect depending on players role.\n", 40, 500);
        FunctionsClass.WriteStory("Soldier: Small chance to endure damage that would bring you below 1hp.\nMage: Small chance to cast divinely powerful magic and remove the current enemy from existance.", 40, 0);
        FunctionsClass.WriteStory("Archer: Small chance to dodge the current attack negating all damage that would have been taken.", 40, 500);


        StatsClass.ViewPlayerStats();

        FunctionsClass.CreateSpace(2, 250);
        FunctionsClass.WriteStory("You now have 4 points to increase your stats by, choose wisely.", 40, 500);
        FunctionsClass.CreateSpace(1, 250);
    }




    public static void StatSelectionScene(PlayerClass player1)           // Ask player if they approach lectern. Yes = 4 stat points and get to allocate, No = Get no stats 
    {
        FunctionsClass.WriteStory("You look around in search of where to go.", 40, 500);
        FunctionsClass.WriteStory("\nYou notice a stone lectern.\nDo you approach it?\nEnter: ", 40, 500);

        string createStatsChoice = "";

        while (string.IsNullOrEmpty(createStatsChoice))
        {
            createStatsChoice = Console.ReadLine().Trim().ToLower();
            if (player1.PlayerRole == "mage" && createStatsChoice.Contains("yes"))
            {
                FunctionsClass.WriteStory("As you approach the lectern, glyphs in the form of purple light appear.", 40, 500);
                FunctionsClass.WriteStory("The glyphs, although you dont recognise them, you can understand them in your mind.", 40, 500);
                FunctionsClass.WriteStory("*You learned the ancient innate ability of specing: Focusing ones power into different aspects.*", 40, 500);
                StatsClass.StatPoints[0] = StatsClass.StatPoints[0] + 4;
                StatExplanationScene();
                StatsClass.EditPlayerStats();                                          // Initiate player stat allocation
            }
            else if (createStatsChoice.Contains("yes") && (player1.PlayerRole == "soldier" ^ player1.PlayerRole == "archer"))
            {
                FunctionsClass.WriteStory("You approach the lectern and notice an ancient book.", 40, 500);
                FunctionsClass.WriteStory("You open the book and read of an ancient technique of focusing your power into different aspects.", 40, 500);
                StatsClass.StatPoints[0] = StatsClass.StatPoints[0] + 4;
                StatExplanationScene();
                StatsClass.EditPlayerStats();                                          // Initiate player stat allocation
            }
            else if (createStatsChoice.Contains("no"))
            {
                FunctionsClass.WriteStory("You ignore the lectern and walk towards a thick wooden door.", 40, 500);
                // Not spec scene
            }
            else if (string.IsNullOrEmpty(createStatsChoice) || (!createStatsChoice.Contains("yes") || !createStatsChoice.Contains("no")))
            {
                FunctionsClass.WriteStory("Please answer \"Yes\" or \"No\"\nEnter: ", 40, 500);
                createStatsChoice = "";
            }



        }
    }

    public static void OpenDoor()
    {
        bool doorOpened = false;
        string openDoorChoice = "";
        int openDoorAutomaticallyCounter = 0;
        FunctionsClass.WriteStory("How do you attempt to open the door?\nForce? Delicacy? Intelligence?\nEnter: ", 40, 500);

        while (!doorOpened)
        {
            openDoorChoice = Console.ReadLine().Trim().ToLower();

            if (openDoorChoice.Contains("force"))
            {
                if (StatsClass.PlayerStats["strength"] >= 2)
                {
                    FunctionsClass.WriteStory("You kicked the door, forcing it open.\n", 40, 500);
                    doorOpened = true;
                }
                else
                {
                    FunctionsClass.WriteStory("You kicked the door, it did not move.\nEnter: ", 40, 500);
                    openDoorAutomaticallyCounter += 1;
                }
            }
            else if (openDoorChoice.Contains("delicacy"))
            {
                if (StatsClass.PlayerStats["dexterity"] >= 2)
                {
                    FunctionsClass.WriteStory("You slide your knife under the latch an lift it up. You open the door.\n", 40, 500);
                    doorOpened = true;
                }
                else
                {
                    FunctionsClass.WriteStory("You try to slide your knife under the latch. It does not fit.\nEnter: ", 40, 500);
                    openDoorAutomaticallyCounter += 1;
                }
            }
            else if (openDoorChoice.Contains("intelligence"))
            {
                if (StatsClass.PlayerStats["attunement"] >= 2)
                {
                    FunctionsClass.WriteStory("The door's latch glows with a purple light briefly, and unlocks itself. The door opens.\n", 40, 500);
                    doorOpened = true;
                }
                else
                {
                    FunctionsClass.WriteStory("You stand in front of the door. You cannot think of a way to open it.\nEnter: ", 40, 500);
                    openDoorAutomaticallyCounter += 1;
                }
            }
            else if (string.IsNullOrEmpty(openDoorChoice))
            {
                FunctionsClass.WriteStory("Please enter: Force, Delicacy or Intelligence.\nEnter: ", 40, 500);

            }
            else if (openDoorAutomaticallyCounter >= 3)
            {
                FunctionsClass.WriteStory("You run into the door, smashing into it.\nIt barely breaks open, allowing you to squeeze through.\n", 40, 500);
                doorOpened = true;
            }
            else
            {
                FunctionsClass.WriteStory("You run into the door, smashing into it. Nothing happens.\nEnter: ", 40, 500);
                openDoorAutomaticallyCounter += 1;
            }
        }
    }

    public static void PickADoor()
    {

        string pickADoorChoice = "";
        bool pickADoorLoop = false;
        FunctionsClass.WriteStory("You see a door on the north, east and west wall of the room, what door do you attempt to enter?\nEnter: ", 40, 500);

        while (!pickADoorLoop)
        {
            pickADoorChoice = Console.ReadLine().Trim().ToLower();
            switch (pickADoorChoice)
            {
                case "north":
                    FunctionsClass.WriteStory("You walk toward the door to the north.\n", 40, 500);
                    pickADoorLoop = true;
                    break;

                case "east":
                    FunctionsClass.WriteStory("You walk toward the door to the east.\n", 40, 500);
                    pickADoorLoop = true;
                    break;

                case "west":
                    FunctionsClass.WriteStory("You walk toward the door to the west.\n", 40, 500);
                    pickADoorLoop = true;
                    break;

                default:
                    FunctionsClass.WriteStory("Please enter \"North\", \"East\" or \"West\"\nEnter: ", 40, 500);
                    break;
            }
        }
        
    }
}