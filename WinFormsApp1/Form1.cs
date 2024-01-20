using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<Team> teams = new List<Team>(); //currently loaded teams in the gridview
        static List<List<Game>> validGameLists = new List<List<Game>>(); //probably deprecated but might use this functionality later
        static List<List<Team>> teamPermutations = new List<List<Team>>(); //probably deprecated but might use this functionality later
        private static Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        Schedule GenerateSchedule(List<Team> teamsInput)
        {
            List<Game> validGames = new List<Game>();
            List<Game> tempListOfValidGamesFound = new List<Game>();
            List<Team> teamsToSchedule = new List<Team>(teamsInput);
            //DateTime[] scheduleDays = {
            //    new DateTime(2024, 1, 2),
            //    new DateTime(2024, 1, 3),
            //    new DateTime(2024, 1, 4),
            //    new DateTime(2024, 1, 5),
            //    new DateTime(2024, 1, 6),
            //    //new DateTime(2024, 1, 7),
            //    //new DateTime(2024, 1, 8),
            //    //new DateTime(2024, 1, 9),
            //    //new DateTime(2024, 1, 10),
            //    //new DateTime(2024, 1, 11),
            //    //new DateTime(2024, 1, 12),
            //    //new DateTime(2024, 1, 13),
            //    //new DateTime(2024, 1, 14),
            //    //new DateTime(2024, 1, 15),
            //    //new DateTime(2024, 1, 16),
            //    //new DateTime(2024, 1, 17),
            //    //new DateTime(2024, 1, 18),
            //    //new DateTime(2024, 1, 19),
            //    //new DateTime(2024, 1, 20),
            //    //new DateTime(2024, 1, 21)
            //}; // Example: Tuesday and Wednesday
            Schedule validFinalSchedule = new Schedule();
            Schedule tempFinalSchedule = new Schedule();
            bool isOptimalScheduleFound = false;
            int amountOfConflicts = 0;
            //int optimalMaxGamesPerDay = 0;
            int minDaysNeededForValidSched = 0;

            Dictionary<string, List<string>> playerTeamsMap = new Dictionary<string, List<string>>();

            foreach (var team in teams)
            {
                foreach (var player in team.PlayerSet)
                {
                    if (!playerTeamsMap.ContainsKey(player))
                    {
                        playerTeamsMap[player] = new List<string>();
                    }
                    playerTeamsMap[player].Add(team.name);
                }
            }




            if (!chkIsConflict.Checked) //IF THERE IS NO CONFLICT IN THE GAMES
            {
                return validFinalSchedule ;
                //if (teamsToSchedule.Count % 2 != 0 && btnAddBye.Checked)
                //{
                //    teamsToSchedule.Add(new Team("BYE", "BYE", new List<string> { "BYE", "BYE", "BYE", "BYE" }));
                //}
                ////optimalMaxGamesPerDay = teamsToSchedule.Count / 2;
                //minDaysNeededForValidSched = teamsToSchedule.Count - 1;

                ////returns every possible game that can be paired up
                //for (int i = 0; i < minDaysNeededForValidSched; i++)
                //{
                //    for (int j = i + 1; j < minDaysNeededForValidSched + 1; j++)
                //    {
                //        validGames.Add(new Game(teamsToSchedule[i], teamsToSchedule[j], DateTime.MaxValue));
                //    }
                //}

                //while (isOptimalScheduleFound == false)
                //{
                //    validGames = RandomizeGames(validGames);
                //    validFinalSchedule.Games.Clear();
                //    //cycling through every day, track if optimal day found
                //    for (int j = 0; j < minDaysNeededForValidSched; j++)
                //    {
                //        bool isOptimalDayFound = false;
                //        tempListOfValidGamesFound.Clear();
                //        tempFinalSchedule.Games.Clear();
                //        foreach (Game game in validFinalSchedule.Games)
                //        {
                //            tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, game.ScheduledTime));
                //        }
                //        foreach (Game game in validGames)
                //        {
                //            if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, tempFinalSchedule, scheduleDays[j]))
                //            {
                //                tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                //                tempListOfValidGamesFound.Add(game);
                //            }
                //            if (tempListOfValidGamesFound.Count == optimalMaxGamesPerDay)
                //            {
                //                isOptimalDayFound = true;
                //                foreach (Game tempGame in tempListOfValidGamesFound)
                //                {
                //                    validFinalSchedule.AddGame(new Game(tempGame.HomeTeam, tempGame.AwayTeam, scheduleDays[j]));
                //                }
                //                break;
                //            }
                //        }
                //        if (isOptimalDayFound == false)
                //        {
                //            break;
                //        }
                //    }
                //    if (validFinalSchedule.Games.Count == validGames.Count)
                //    {
                //        isOptimalScheduleFound = true;
                //    }
                //}
                //validGames.Clear();
                //return validFinalSchedule;
            }
            else //IF THERE IS A CONFLICT IN THE GAMES AND NOT ALLOWED
            {        /*
                1. Find games without conflicts
                2. Find max amount of games that can be played in a time slot
                3. Find how many */
                //if conflicting teams is even (two teams) or odd (one team, three teams, etc.)
                //figure out
                //find min days needed, optimmal games per day like above here
                // minDaysNeededForValidSched = 8;
                // optimalMaxGamesPerDay = 2;
                // //find all possible valid games, ignoring games that have player conflicts
                // for (int i = 0; i < teamsToSchedule.Count - 1; i++)
                // {
                //     for (int j = i + 1; j < teamsToSchedule.Count; j++)
                //     {
                //         if (PlayerConflictBetweenTeams(teamsToSchedule[i], teamsToSchedule[j]))
                //         {
                //             amountOfConflicts += 1;
                //             break;
                //         }
                //         validGames.Add(new Game(teamsToSchedule[i], teamsToSchedule[j], DateTime.MaxValue));
                //     }
                // }

                // while (isOptimalScheduleFound == false)
                // {
                //     validGames = RandomizeGames(validGames);
                //     validFinalSchedule.Games.Clear();
                //     //cycling through every day, track if optimal or not
                //     for (int j = 0; j < minDaysNeededForValidSched; j++)
                //     {
                //         bool isOptimalDayFound = false;
                //         tempListOfValidGamesFound.Clear();
                //         tempFinalSchedule.Games.Clear();
                //         //add all the games assigned to the final schedule so far into our temp schedule
                //         foreach (Game game in validFinalSchedule.Games)
                //         {
                //             tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, game.ScheduledTime));
                //         }
                //         //cycle through every game in our list of valid games generated above
                //         //check to make sure each game fits into the time slot properly on the schedule
                //         foreach (Game game in validGames)
                //         {
                //             if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, tempFinalSchedule, scheduleDays[j]) &&
                //                 !TeamsPlayMoreThanOncePerDay(game.HomeTeam, scheduleDays[j], tempFinalSchedule) &&
                //                 !TeamsPlayMoreThanOncePerDay(game.AwayTeam, scheduleDays[j], tempFinalSchedule) &&
                //                 !HasPlayerConflicts(game.HomeTeam, game.AwayTeam, tempFinalSchedule, scheduleDays[j]))
                //             {
                //                 tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                //                 tempListOfValidGamesFound.Add(game);
                //             }
                //             //check to make sure the day has an optimal count of games that are still possible
                //             if (((tempListOfValidGamesFound.Count == optimalMaxGamesPerDay) && j < 6 ) || ((tempListOfValidGamesFound.Count == optimalMaxGamesPerDay - 1) && j >= 6))
                //             {
                //                 isOptimalDayFound = true;
                //                 foreach (Game tempGame in tempListOfValidGamesFound)
                //                 {
                //                     validFinalSchedule.AddGame(new Game(tempGame.HomeTeam, tempGame.AwayTeam, scheduleDays[j]));
                //                 }
                //                 break;
                //             }
                //         }
                //         //if sorting through the games per the day resulted in non-optimal day, start over with new permutation
                //         if (!isOptimalDayFound)
                //         {
                //             break;
                //         }
                //     }
                //     if (validFinalSchedule.Games.Count == validGames.Count)
                //     {
                //         isOptimalScheduleFound = true;
                //     }
                // }
                // validGames.Clear();
                // return validFinalSchedule;


                for (int i = 0; i < teamsToSchedule.Count - 1; i++)
                {
                    for (int j = i + 1; j < teamsToSchedule.Count; j++)
                    {
                        if (PlayerConflictBetweenTeams(teamsToSchedule[i], teamsToSchedule[j]))
                        {
                            amountOfConflicts += 1;
                            teamsToSchedule[i].numConflicts += 1;
                            teamsToSchedule[j].numConflicts += 1;
                            break;
                        }
                        validGames.Add(new Game(teamsToSchedule[i], teamsToSchedule[j], DateTime.MaxValue));
                    }
                }

                Schedule finalSchedule = new Schedule();
                int tournamentDays = 30;

                validGames.Sort((game1, game2) => CompareGameConstraints(game1, game2));
                //validGames.Sort();
                Console.WriteLine("hi");
                while (finalSchedule != null)
                {
                    // Dictionary to track player availability
                    Dictionary<string, HashSet<DateTime>> playerAvailability = new Dictionary<string, HashSet<DateTime>>();

                    // Initialize player availability based on shared players
                    foreach (var team in teamsInput)
                    {
                        foreach (var player in team.PlayerSet)
                        {
                            if (!playerAvailability.ContainsKey(player))
                            {
                                playerAvailability[player] = new HashSet<DateTime>();
                            }
                        }
                    }

                    // List to keep track of team availability
                    Dictionary<string, HashSet<DateTime>> teamAvailability = new Dictionary<string, HashSet<DateTime>>();
                    foreach (var team in teamsInput)
                    {
                        teamAvailability[team.name] = new HashSet<DateTime>();
                    }


                    DateTime[] scheduleDays = new DateTime[tournamentDays];

                    for (int i = 1; i <= tournamentDays; i++)
                    {
                        scheduleDays[i - 1] = new DateTime(2024, 1, i);
                    }

                    List<int> optimalMaxGamesPerDay = CalculateDynamicMaxGamesPerDay(teamsInput, scheduleDays, playerAvailability, teamAvailability);
                    bool isScheduleCompleted = BacktrackSchedule(0, validGames, finalSchedule, scheduleDays, optimalMaxGamesPerDay);

                    if (isScheduleCompleted)
                    {
                        return finalSchedule;
                    }
                    tournamentDays++;
                }



                return null;
            }
        }

        // Helper functions to check if a team plays more than once on a specific day


        //if we are given a schedule ahead of time
        List<int> CalculateDynamicMaxGamesPerDay(List<Team> teams, DateTime[] scheduleDays, Dictionary<string, HashSet<DateTime>> playerAvailability, Dictionary<string, HashSet<DateTime>> teamAvailability)
        {
            List<int> maxGamesPerDay = new List<int>();
            HashSet<Game> scheduledGames = new HashSet<Game>();

            foreach (var day in scheduleDays)
            {
                int gamesToday = 0;

                foreach (var team1 in teams)
                {
                    foreach (var team2 in teams)
                    {
                        if (team1 != team2 && 
                            !scheduledGames.Contains(new Game(team1, team2)) && 
                            //!(!scheduledGames.Contains(new Game(team2, team1)) && scheduledGames.Contains(new Game(team1, team2))) &&

                            CanScheduleGame(team1, team2, day, playerAvailability, teamAvailability))
                        {
                            scheduledGames.Add(new Game(team1, team2));
                            gamesToday++;
                            UpdateAvailability(team1, team2, day, playerAvailability, teamAvailability);
                        }
                    }
                }

                maxGamesPerDay.Add(gamesToday);
            }

            return maxGamesPerDay;
        }
        bool CanScheduleGame(Team team1, Team team2, DateTime day, Dictionary<string, HashSet<DateTime>> playerAvailability, Dictionary<string, HashSet<DateTime>> teamAvailability)
        {
            // Check if teams are available
            if (teamAvailability[team1.name].Contains(day) || teamAvailability[team2.name].Contains(day))
            {
                return false;
            }

            // Check for player conflicts
            foreach (var player in team1.PlayerSet)
            {
                if (team2.PlayerSet.Contains(player) || playerAvailability[player].Contains(day))
                {
                    return false;
                }
            }

            return true;
        }

        void UpdateAvailability(Team team1, Team team2, DateTime day, Dictionary<string, HashSet<DateTime>> playerAvailability, Dictionary<string, HashSet<DateTime>> teamAvailability)
        {
            teamAvailability[team1.name].Add(day);
            teamAvailability[team2.name].Add(day);

            foreach (var player in team1.PlayerSet)
            {
                playerAvailability[player].Add(day);
            }

            foreach (var player in team2.PlayerSet)
            {
                playerAvailability[player].Add(day);
            }
        }
        int CalculateOptimalMaxGamesPerDay(List<Team> teams, int tournamentDays, Dictionary<string, List<string>> playerTeamsMap)
        {
            // Start with the basic calculation
            int totalGames = (teams.Count * (teams.Count - 1)) / 2;
            int basicMaxGamesPerDay = (int)Math.Ceiling((double)totalGames / tournamentDays);

            // Adjust for shared players
            int adjustedMaxGamesPerDay = basicMaxGamesPerDay;

            foreach (var playerTeams in playerTeamsMap.Values)
            {
                if (playerTeams.Count > 1)
                {
                    // Example heuristic: reduce the number of games per day by 1 for each shared player
                    // This is a simple heuristic and may need adjustment based on your specific constraints
                    adjustedMaxGamesPerDay = Math.Max(1, adjustedMaxGamesPerDay - 1);
                }
            }

            return adjustedMaxGamesPerDay;
        }

        List<Game> GenerateAllPossibleGames(List<Team> teams)
        {
            var allGames = new List<Game>();

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    allGames.Add(new Game(teams[i], teams[j]));
                }
            }

            return allGames;
        }
        private bool BacktrackSchedule(int gameIndex, List<Game> games, Schedule schedule, DateTime[] scheduleDays, List<int> optimalMaxGamesPerDay)
        {
            if (gameIndex >= games.Count)
            {
                return true; // All games scheduled
            }

            for (int dayIndex = 0; dayIndex < scheduleDays.Length; dayIndex++)
            {
                DateTime currentDay = scheduleDays[dayIndex];
                Game currentGame = games[gameIndex];

                if (CanPlaceGame(currentGame, currentDay, schedule, optimalMaxGamesPerDay[dayIndex]))
                {
                    schedule.AddGame(new Game(currentGame.HomeTeam, currentGame.AwayTeam, currentDay));
                    if (BacktrackSchedule(gameIndex + 1, games, schedule, scheduleDays, optimalMaxGamesPerDay))
                    {
                        return true;
                    }
                    schedule.RemoveLastGame(); // Backtrack
                }
            }

            return false;
        }
        private int CompareGameConstraints(Game game1, Game game2)
        {
            // Example: Count of shared players could be a factor
            int constraintsGame1 = game1.HomeTeam.numConflicts + game1.AwayTeam.numConflicts;
            int constraintsGame2 = game2.HomeTeam.numConflicts + game2.AwayTeam.numConflicts;

            // More constraints should result in the game being scheduled earlier
            return constraintsGame2.CompareTo(constraintsGame1);
        }
        //private int CountSharedPlayers(Game game)
        //{
        //    var homeTeamPlayers = game.HomeTeam.numConflicts;
        //    var awayTeamPlayers = game.AwayTeam.numConflicts;

        //    return homeTeamPlayers.Intersect(awayTeamPlayers).Count();
        //}
        private bool CanPlaceGame(Game game, DateTime day, Schedule schedule, int maxGamesPerDay)
        {
            // Check if the day already has the maximum number of games scheduled
            if (schedule.AmountOfGamesOnADay(day) >= maxGamesPerDay)
            {
                return false;
            }

            // Check if either team is already playing on this day
            if (TeamsPlayMoreThanOncePerDay(game.HomeTeam, day, schedule) || 
                TeamsPlayMoreThanOncePerDay(game.AwayTeam, day, schedule))
            {
                return false;
            }

            // Check for player conflicts
            if (HasPlayerConflicts(game.HomeTeam, game.AwayTeam, schedule, day))
            {
                return false;
            }

            // Additional custom rules or constraints can be added here

            return true; // If none of the conditions above are met, the game can be scheduled on this day
        }
        static bool TeamsPlayMoreThanOncePerDay(Team team, DateTime day, Schedule schedule)
        {
            int count = schedule.Games.Count(g =>
                (g.HomeTeam == team || g.AwayTeam == team) && g.ScheduledTime.Date == day.Date);

            return count > 0;
        }
        static bool HasPlayerConflicts(Team team1, Team team2, Schedule schedule, DateTime day)
        {
            //if any players on this potential game are already playing in a conflicting game
            // Check if any player is common between the two teams
            foreach (string player in team1.PlayerSet)
            {
                if (team2.PlayerSet.Contains(player) || schedule.HasPlayerConflict(player, day))
                {
                    return true;
                }
            }
            foreach (string player in team2.PlayerSet)
            {
                if (team1.PlayerSet.Contains(player) || schedule.HasPlayerConflict(player, day))
                {
                    return true;
                }
            }
            return false;
        }
        static bool PlayerConflictBetweenTeams(Team team1, Team team2)
        {
            foreach (string player in team1.PlayerSet)
            {
                if (team2.PlayerSet.Contains(player))
                {
                    return true;
                }
            }
            return false;
        }
        static bool TeamsAlreadyPlayed(Team team1, Team team2, Schedule schedule, DateTime day)
        {
            int count = 0;
            foreach (Game games in schedule.Games)
            {
                //check if either team already played today in a different game
                if (games.ScheduledTime == day)
                {
                    if ((games.HomeTeam == team1 || games.AwayTeam == team1) || (games.HomeTeam == team2 || games.AwayTeam == team2))
                    // if ((games.HomeTeam == team1 || games.AwayTeam == team1) && (games.HomeTeam == team2 || games.AwayTeam == team2))
                    {
                        count += 1;
                    }
                }
                //check if either team already played vs each other on a different day
                if ((games.HomeTeam == team1 || games.AwayTeam == team1) && (games.HomeTeam == team2 || games.AwayTeam == team2))
                // if ((games.HomeTeam == team1 || games.AwayTeam == team1) && (games.HomeTeam == team2 || games.AwayTeam == team2))
                {
                    count += 1;
                }
            }
            //check if the team and opponent are the same for any reason
            if (team1 == team2)
            {
                count += 1;
            }
            return count > 0;
        }
        private void btnRandomize_Click(object sender, EventArgs e)
        {
            dgvSched.Rows.Clear();
            //generate schedule based on teams/times/leagues entered
            Schedule schedule = GenerateSchedule(teams);

            //for each game created in schedule, add it to grid view
            foreach (Game game in schedule.Games)
            {
                dgvSched.Rows.Add(game.HomeTeam.name, game.AwayTeam.name, game.ScheduledTime.Date.ToString("MM/dd"));
            }
        }
        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            // leagues.Add(txtLeague.Text);
            listBox1.Items.Add(txtLeague.Text);
            cmbScheduleLeague.Items.Add(txtLeague.Text);
            cmbTeamLeague.Items.Add(txtLeague.Text);
        }
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            //string teamName = txtTeamName.Text;
            //string teamLeague = cmbTeamLeague.Text;
            //string teamPlayer1 = txtPlayer1.Text;
            //string teamPlayer2 = txtPlayer2.Text;
            //string teamPlayer3 = txtPlayer3.Text;
            //string teamPlayer4 = txtPlayer4.Text;

            ////for dev testing
            List<Team> tempTeams = new List<Team>();
            tempTeams.Add(new Team("Team A", "ABC", new List<string> { "Player11", "Player12", "Player13", "Player14" }, 0)); //shares Player1 with C
            tempTeams.Add(new Team("Team B", "ABC", new List<string> { "Player21", "Player22", "Player23", "Player24" }, 0));
            tempTeams.Add(new Team("Team C", "ABC", new List<string> { "Player31", "Player32", "Player33", "Player34" }, 0)); //shares Player1 with A
            tempTeams.Add(new Team("Team D", "ABC", new List<string> { "Player41", "Player42", "Player43", "Player44" }, 0));
            tempTeams.Add(new Team("Team E", "ABC", new List<string> { "Player51", "Player52", "Player53", "Player54" }, 0));
            tempTeams.Add(new Team("Team F", "ABC", new List<string> { "Player61", "Player62", "Player63", "Player64" }, 0));
            //teams.Add(new Team("Team G", "ABC", new List<string> { "Player991", "Player955", "Player916", "Player925" }));
            ////
            //display added teams in DGV
            foreach (Team team in tempTeams)
            {
                teams.Add(team);
                string[] players = team.PlayerSet.ToArray();
                dgvTeams.Rows.Add(team.name, team.league, players[0], players[1], players[2], players[3]);
            }
        }
        static List<Game> RandomizeGames(List<Game> games)
        {
            int n = games.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Game value = games[k];
                games[k] = games[n];
                games[n] = value;
            }

            return games;
        }
        private void btnAddTime_Click(object sender, EventArgs e)
        {
            DateTime date = dtpDate.Value.Date;
            DateTime startTime = dtpStartTime.Value.Date + dtpStartTime.Value.TimeOfDay;
            DateTime endTime = dtpEndTime.Value.Date + dtpEndTime.Value.TimeOfDay;
            string league = cmbScheduleLeague.Text;

            //scheduledTimes.Add(new ScheduledTime(league, date, startTime, endTime)); deprecated, replace
            dgvTime.Rows.Add(league, date.ToString("dd-MM-yyyy"), startTime.ToString("hh:mm"), endTime.ToString("hh:mm"));
        }
        //used for generating every permutation
        static void GenerateTeamPermutations(List<Team> list, int currentIndex)
        {
            if (currentIndex == list.Count - 1)
            {
                List<Team> newList = list;
                teamPermutations.Add(newList);
                return;
            }

            for (int i = currentIndex; i < list.Count; i++)
            {
                Swap(list, currentIndex, i);
                GenerateTeamPermutations(list, currentIndex + 1);
                Swap(list, currentIndex, i);
            }
        }
        static void GenerateGamePermutations(List<Game> list, int currentIndex)
        {
            if (currentIndex == list.Count - 1)
            {
                List<Game> newList = list;
                validGameLists.Add(newList);
                return;
            }
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Game value = list[k];
                list[k] = list[n];
                list[n] = value;
            }


            for (int i = currentIndex; i < list.Count; i++)
            {
                if (validGameLists.Count > 1000000)
                {
                    return;
                }
                SwapGame(list, currentIndex, i);
                GenerateGamePermutations(list, currentIndex + 1);
                SwapGame(list, currentIndex, i);
            }

        }
        //used for generatic every permutation
        static void Swap(List<Team> list, int index1, int index2)
        {
            Team temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
        static void SwapGame(List<Game> list, int index1, int index2)
        {
            Game temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
        private void btnAddTeam2_Click(object sender, EventArgs e)
        {
            ////for dev testing
            List<Team> tempTeams = new List<Team>();
            tempTeams.Add(new Team("Test1", "Devs", new List<string> { "Dev11", "Dev12", "Dev13", "Dev14" }, 0)); //shares Player1 with C
            tempTeams.Add(new Team("Test2", "Devs", new List<string> { "Dev21", "Dev22", "Dev23", "Dev24" }, 0));
            tempTeams.Add(new Team("Test3", "Devs", new List<string> { "Dev31", "Dev32", "Dev33", "Dev34" }, 0)); //shares Player1 with A
            tempTeams.Add(new Team("Test4", "Devs", new List<string> { "Dev41", "Dev42", "Dev43", "Dev44" }, 0));
            tempTeams.Add(new Team("Test5", "Devs", new List<string> { "SameDev", "Dev52", "Dev53", "Dev54" }, 0));
            tempTeams.Add(new Team("Test6", "Devs", new List<string> { "SameDev", "Dev62", "Dev63", "Dev64" }, 0));
            tempTeams.Add(new Team("Test7", "Devs", new List<string> { "Guy", "Dev72", "Dev73", "Dev74" }, 0)); //shares Player1 with A
            tempTeams.Add(new Team("Test8", "Devs", new List<string> { "Guy", "Dev82", "Dev83", "Dev84" }, 0));
            tempTeams.Add(new Team("Team G", "ABC", new List<string> { "Player991", "Player955", "Player916", "Player925" }, 0));
            ////
            //display added teams in DGV
            foreach (Team team in tempTeams)
            {
                teams.Add(team);
                dgvTeams.Rows.Add(team.name, team.league, team.PlayerSet.ElementAt(0), team.PlayerSet.ElementAt(1), team.PlayerSet.ElementAt(2), team.PlayerSet.ElementAt(3));
            }
        }
        private void btnClearTeams_Click(object sender, EventArgs e)
        {
            teams.Clear();
            dgvTeams.Rows.Clear();
        }
        private void btnAddNewTeam_Click(object sender, EventArgs e)
        {
            string teamName = txtTeamName.Text;
            string teamLeague = cmbTeamLeague.Text;
            string teamPlayer1 = txtPlayer1.Text;
            string teamPlayer2 = txtPlayer2.Text;
            string teamPlayer3 = txtPlayer3.Text;
            string teamPlayer4 = txtPlayer4.Text;


            teams.Add(new Team(teamName, teamLeague, new List<string> { teamPlayer1, teamPlayer2, teamPlayer3, teamPlayer4 }, 0));
            dgvTeams.Rows.Add(teamName, teamLeague, teamPlayer1, teamPlayer2, teamPlayer3, teamPlayer4);
        }
    }
}
