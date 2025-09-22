using System.Runtime.CompilerServices;

namespace Leaderboard;

using BattleSequence;
using Enemy;
using Player;

public class LeaderboardClass
{

    public static string getFilePath()
    {
        string fileBasePath = Directory.GetCurrentDirectory(); // Gets following dir: G:\RGU Coding Work\Software Design and Development\RESIT\cm1113-resit-coursework-resit-team-1\CM1113-Coursework\bin\Debug\net8.0

        fileBasePath = Directory.GetParent(fileBasePath).FullName; // now stops at Debug
        fileBasePath = Directory.GetParent(fileBasePath).FullName; // now stops at bin
        fileBasePath = Directory.GetParent(fileBasePath).FullName; // now stops at CM1113-Coursework


        string filePath = Path.Combine(fileBasePath, "txtLeaderboard.txt"); // makes filepath to the txt file storing leaderboard data

        return filePath;
    }
   

    public static List<string> leaderboardList = [];


    //leaderboardList = File.ReadAllLines(filePath).ToList();

    public static void GameWonLeaderboard(PlayerClass player1)
    {
        leaderboardList.Add("Dungeon Crawler:");
        leaderboardList.Add(player1.Name.ToString());
        leaderboardList.Add(" Defeated: ");
        leaderboardList.Add(MonstersDefeated().ToString());
        leaderboardList.Add(" Monsters.\nAnd escaped with ");
        leaderboardList.Add(player1.PlayerHealth.ToString());
        leaderboardList.Add(" Health.");

        File.WriteAllLines(getFilePath(), leaderboardList);

    }

    public static void GameLostLeaderboard(PlayerClass player1)
    {
        leaderboardList.Add("Dungeon Crawler:");
        leaderboardList.Add(player1.Name.ToString());
        leaderboardList.Add("Defeated: ");
        leaderboardList.Add(MonstersDefeated().ToString());
        leaderboardList.Add(" Monsters.\nAnd died fighting ");
        leaderboardList.Add(EnemyClass.getEnemyName(finishCounterReturn()));

        File.WriteAllLines(getFilePath(), leaderboardList);

    }

    public static void GameQuitLeaderboard(PlayerClass player1)
    {
        leaderboardList.Add("Dungeon Crawler:");
        leaderboardList.Add(player1.Name.ToString());
        leaderboardList.Add(" Defeated: ");
        leaderboardList.Add(MonstersDefeated().ToString());
        leaderboardList.Add(" Monsters. And died after fighting ");
        leaderboardList.Add(EnemyClass.getEnemyName(finishCounterReturn()));

        File.WriteAllLines(getFilePath(), leaderboardList);

    }

    public static void ShowLeaderboard()
    {
        leaderboardList = File.ReadAllLines(getFilePath()).ToList();

        foreach (string line in leaderboardList)
        {
            Console.WriteLine(line);
        }

    }

    public static int finishCounter = 0;
    public static int finishCounterReturn()
    {
        return finishCounter;
    }

    public static void increaseFinishCounter()
    {
        finishCounter =+ 1;
    }






    public static int MonstersDefeated()
    {
        return finishCounterReturn() + 1;     // Return int of monsters defeated.
    }

    public static string MonsterDiedTo()
    {
        return EnemyClass.getEnemyName(finishCounterReturn());  // Return monster died to
    }
}