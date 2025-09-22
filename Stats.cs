namespace Stats;

using Functions;

public class StatsClass
{
    public static Dictionary<string, int> PlayerStats { get; set; } = new Dictionary<string, int>()  // Player stats in a dictionary 
    {
        {"strength", 0 },
        {"attunement", 0},
        {"dexterity", 0},
        {"vigor", 0},
        {"defence", 0},
        {"resolve", 0}
    };

    public static List<int> StatPoints { get; set; } = new List<int>() // Stores the amonunt of stat points a player has to spend.  
    {
        0
    };


    public static void ViewPlayerStats()  // method to view players stats from dictionary
    {
        FunctionsClass.WriteStory("=========================================", 25, 300);
        FunctionsClass.WriteStory("\nCurrently your stats look like this:", 40, 500);
        FunctionsClass.CreateSpace(1, 50);
        foreach (var item in StatsClass.PlayerStats)
        {
            Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }
        FunctionsClass.WriteStory("=========================================", 25, 300);
    }

    public static void EditPlayerStatsAdmin(string statName, int changeInStat)  // allows player stats to be direcly edited instead of the dialogue for user
    {
        StatsClass.PlayerStats[statName.Trim().ToLower()] = StatsClass.PlayerStats[statName.Trim().ToLower()] + changeInStat;
    }

    public static void EditPlayerStats()  // Method for user to edit their stats
    {
        string statName = "";
        bool exitBool = false;        //declared some variable to setup the if else cascade
        bool restartBool = false;
        
        FunctionsClass.WriteStory("=========================================", 25, 300);
        FunctionsClass.WriteStory("Stat Selection Menu", 40, 300);
        FunctionsClass.CreateSpace(1, 200);
        if (StatPoints[0] > 0)      // If the player doesnt have 0 stat points available the following runs
        {
            while ((string.IsNullOrEmpty(statName) && !exitBool) || restartBool != false)  // Runs true at start becaus statName AND !exitBool are empty and true valued. 
            {                                                                              // restartBool != evaluates to false here but doesnt matter cause its an || operator
                int changeInStat = 0;  // declare changeInStat 
                restartBool = false;                                // restartBool is declared false here if it was set true later in the cascade

                FunctionsClass.WriteStory("What stat would you like to increase?\nEnter: ", 40, 250);

                statName = Console.ReadLine().Trim().ToLower();                       // Prompt the user to enter the stat they want

                if (StatsClass.PlayerStats.ContainsKey(statName))         // Evaluates true if the player enters a stat that is in the key of playerstats dictionary
                {
                    while ((StatPoints[0] != 0 && !exitBool) ^ restartBool)   // evaluates to false if stat points run out, or if the player chose to exit, restartBool allows to 
                    {                                                         // escape this while loop if player chooses to allocate more points
                        FunctionsClass.CreateSpace(1, 100);
                        FunctionsClass.WriteStory("How many points would you like to allocate?\n", 40, 400);
                        Console.WriteLine("You currently have {0} points.", StatPoints[0]);
                        FunctionsClass.WriteStory("Enter: ", 40, 300);
                        try
                        {
                            changeInStat = Int32.Parse(Console.ReadLine().Trim().ToLower());  // prompt user for amount of points parse to int32 from string
                            if (changeInStat > StatPoints[0])  // If player enters an amount higher than points they have, error message
                            {
                                FunctionsClass.WriteStory("The amount you entered was too high, please try again.", 40, 300);
                                changeInStat = 0;
                            }
                            else
                            {
                                StatsClass.PlayerStats[statName.Trim().ToLower()] = StatsClass.PlayerStats[statName.Trim().ToLower()] + changeInStat;  // changes the dictionary key value with name equal to users input by the amount they entered
                                StatPoints[0] = StatPoints[0] - changeInStat;
                                FunctionsClass.WriteStory("Stat point(s) allocated. Your new stats are shown below.", 40, 400);
                                ViewPlayerStats();

                                if (StatPoints[0] != 0)   // runs if player has points left to allocate
                                {
                                    FunctionsClass.WriteStory("Would you like to allocate more points? You currently have ", 40, 0);
                                    Console.Write("{0} points.", StatPoints[0]);
                                    FunctionsClass.WriteStory("Enter: ", 40, 300);
                                    string assignMorePoints = "";                   // declare assignMorePoints for use in next user prompt
                                    while (string.IsNullOrEmpty(assignMorePoints))
                                    {
                                        assignMorePoints = Console.ReadLine().Trim().ToLower();  // Player inputs their choice yes restarts the method, no exits the method
                                        if (assignMorePoints.Contains("yes"))
                                        {
                                            restartBool = true;
                                        }
                                        else if (assignMorePoints.Contains("no"))
                                        {
                                            exitBool = true;
                                        }
                                        else
                                        {
                                            FunctionsClass.WriteStory("Please enter \"Yes\" or \"No\".\nEnter: ", 40, 400);
                                            assignMorePoints = "";  // set to empty so the while loop is not broken as just assigned "assignMorePoints" an invalid or null value
                                        }
                                    }
                                }
                                else
                                {
                                    FunctionsClass.WriteStory("Sorry, you dont have enough/any more points.\n", 40, 500); // not enough points so exit instead of restart
                                    exitBool = true;
                                }

                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Please only enter a number.");
                        }
                    }

                }
                else
                {
                    FunctionsClass.WriteStory("Please enter one of the following: \"Strength\", \"Attunement\", \"Dexterity\", \"Vigor\", \"Defence\", \"Resolve\"", 40, 400);
                    statName = "";  // reset statName because just assigned it a null or invalid value
                }
            }
        }
        else
        {
            FunctionsClass.WriteStory("Sorry, you currently have 0 points.", 40, 500);
        }

    }

}