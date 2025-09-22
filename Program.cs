
using Player;
using Story;

using Stats;
using BattleSequence;
using Rest;
using EnemyCreation;
using Leaderboard;
using System.Security.Cryptography.X509Certificates;
using Functions;

namespace Program
{
    class Program
    {
        static PlayerClass player1 = new PlayerClass();
        static void Main(string[] args)
        {

            StoryClass.IntroStory(); // Plays the intro dialogue

            StoryClass.GraveScene(player1); // Plays name choosing scene

            StoryClass.RoleSelectionScene(player1); // Plays role selection scene

            StoryClass.StatSelectionScene(player1); //Play stat selection scene  GOES UNTIL PLAYER LEAVES THIS FIRST ROOM

            player1.ChangePlayerMaxHealth(StatsClass.PlayerStats["vigor"]);  // Assigns player max health based on stats and displays in console the number

            player1.SetPlayerHealth();


            while (LeaderboardClass.finishCounterReturn() < EnemyCreationClass.allGameEnemies.Count())
            {
                StoryClass.OpenDoor();

                BattleSequenceClass.BattleStart(LeaderboardClass.finishCounterReturn(), player1);

                StatsClass.EditPlayerStats();

                RestClass.Rest(player1);

                StoryClass.PickADoor();

                LeaderboardClass.increaseFinishCounter();

                Console.WriteLine("finishcounter is :{0}", LeaderboardClass.finishCounterReturn());

            }

            LeaderboardClass.GameWonLeaderboard(player1);

            FunctionsClass.WriteStory("The door opens to reveal a vast field under the moonlit sky\n\nYou have escaped.", 40, 500);

            FunctionsClass.CreateSpace(10, 300);

            FunctionsClass.WriteStory("Game Over.", 40, 500);

            FunctionsClass.CreateSpace(5, 250);

            FunctionsClass.WriteStory("Please replay and try a different build :)", 40, 500);
        }   
    }
}