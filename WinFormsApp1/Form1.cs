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
            DateTime[] scheduleDays = {
                new DateTime(2024, 1, 2),
                new DateTime(2024, 1, 3),
                new DateTime(2024, 1, 4),
                new DateTime(2024, 1, 5),
                new DateTime(2024, 1, 6),
                new DateTime(2024, 1, 7),
                new DateTime(2024, 1, 8),
                new DateTime(2024, 1, 9),
                new DateTime(2024, 1, 10),
                new DateTime(2024, 1, 11),
                new DateTime(2024, 1, 12),
                new DateTime(2024, 1, 13),
                new DateTime(2024, 1, 14),
                new DateTime(2024, 1, 15),
                new DateTime(2024, 1, 16),
                new DateTime(2024, 1, 17),
                new DateTime(2024, 1, 18),
                new DateTime(2024, 1, 19),
                new DateTime(2024, 1, 20),
                new DateTime(2024, 1, 21)
            }; // Example: Tuesday and Wednesday
            Schedule validFinalSchedule = new Schedule();
            Schedule tempFinalSchedule = new Schedule();
            bool isOptimalScheduleFound = false;
            int minDaysNeeded = 0;
            int amountOfConflicts = 0;
            int optimalMaxGamesPerDay = 0;
            int validGamesFoundPerDay = 0; //used to track how many games are counted each day when optimizing schedule
            int optimalDaysFound = 0; //amount of optimal days collected so far until we hit our goal number
            
            if (!chkIsConflict.Checked) //IF THERE IS NO CONFLICT IN THE GAMES
            {
                //finds optimal amount of GamesPerDay
                if (teamsToSchedule.Count % 2 == 0)
                {
                    optimalMaxGamesPerDay = teamsToSchedule.Count / 2;
                    minDaysNeeded = teamsToSchedule.Count - 1;
                }
                if (teamsToSchedule.Count % 2 != 0 && btnAddBye.Checked)
                {
                    optimalMaxGamesPerDay = (teamsToSchedule.Count / 2) + 1;
                    minDaysNeeded = (teamsToSchedule.Count + 1) - 1;
                    teamsToSchedule.Add(new Team("BYE", "BYE", new List<string> { "BYE", "BYE", "BYE", "BYE" }));
                }
                //returns every possible game that can be paired up
                for (int i = 0; i < minDaysNeeded; i++)
                {
                    for (int j = i + 1; j < minDaysNeeded + 1; j++)
                    {
                        validGames.Add(new Game(teamsToSchedule[i], teamsToSchedule[j], DateTime.MaxValue));
                    }
                }
                //cycle through every game variation that we collected above
                while (isOptimalScheduleFound == false)
                {
                    validGames = RandomizeGames(validGames);
                    validFinalSchedule.Games.Clear();
                    optimalDaysFound = 0;
                    //cycling through every day, track if optimal day found
                    for (int j = 0; j < minDaysNeeded; j++)
                    {
                        bool optimalDayScheduleFound = false;
                        validGamesFoundPerDay = 0;
                        tempListOfValidGamesFound.Clear();
                        tempFinalSchedule.Games.Clear();
                        foreach (Game game in validFinalSchedule.Games)
                        {
                            tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, game.ScheduledTime));
                        }                     
                        foreach (Game game in validGames)
                        {
                            if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, tempFinalSchedule, scheduleDays[j]))
                            {
                                tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                                tempListOfValidGamesFound.Add(game);
                                validGamesFoundPerDay += 1;
                            }
                            if (validGamesFoundPerDay == optimalMaxGamesPerDay)
                            {
                                optimalDayScheduleFound = true;
                                optimalDaysFound += 1;

                                foreach (Game tempGame in tempListOfValidGamesFound)
                                {
                                    validFinalSchedule.AddGame(new Game(tempGame.HomeTeam, tempGame.AwayTeam, scheduleDays[j]));
                                }
                                break;
                            }
                        }
                        if (optimalDayScheduleFound == false)
                        {
                            break;
                        }
                    }
                    if (validFinalSchedule.Games.Count == validGames.Count)
                    {
                        isOptimalScheduleFound = true;
                    }
                }
                validGames.Clear();
                return validFinalSchedule;
            }
            else //IF THERE IS A CONFLICT IN THE GAMES
            {        
                //find min days needed, optimmal games per day like above here
                minDaysNeeded = 8;
                optimalMaxGamesPerDay = 2;
                //find all possible permutations while removing games that have player conflicts
                for (int i = 0; i < teamsToSchedule.Count - 1; i++)
                {
                    for (int j = i + 1; j < teamsToSchedule.Count; j++)
                    {
                        if (PlayerConflictBetweenTeams(teamsToSchedule[i], teamsToSchedule[j]))
                        {
                            amountOfConflicts += 1;
                            break;
                        }
                        validGames.Add(new Game(teamsToSchedule[i], teamsToSchedule[j], DateTime.MaxValue));
                    }
                }
                //algorithm to determine and then generate most optimal schedule
                while (isOptimalScheduleFound == false)
                {
                    validGames = RandomizeGames(validGames);
                    validFinalSchedule.Games.Clear();
                    optimalDaysFound = 0;
                    //cycling through every day track if optimal or not
                    for (int j = 0; j < minDaysNeeded; j++)
                    {
                        bool optimalDayScheduleFound = false;
                        validGamesFoundPerDay = 0;
                        tempListOfValidGamesFound.Clear();
                        tempFinalSchedule.Games.Clear();
                        //add all the games assigned to the schedule so far into our temp schedule
                        foreach (Game game in validFinalSchedule.Games)
                        {
                            tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, game.ScheduledTime));
                        }
                        //cycle through every game in our list of valid games generated above
                        //check to make sure each game fits into the time slot properly on the schedule
                        foreach (Game game in validGames)
                        {
                            if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, tempFinalSchedule, scheduleDays[j]) &&
                                !TeamsPlayMoreThanOncePerDay(game.HomeTeam, scheduleDays[j], tempFinalSchedule) &&
                                !TeamsPlayMoreThanOncePerDay(game.AwayTeam, scheduleDays[j], tempFinalSchedule) &&
                                !HasPlayerConflicts(game.HomeTeam, game.AwayTeam, tempFinalSchedule, scheduleDays[j]))
                            {
                                tempFinalSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                                tempListOfValidGamesFound.Add(game);
                                validGamesFoundPerDay += 1;
                            }
                            //check to make sure the day has an optimal count of games that are still possible
                            if (((validGamesFoundPerDay == optimalMaxGamesPerDay) && j < 6 ) || ((validGamesFoundPerDay == optimalMaxGamesPerDay - 1) && j >= 6))
                            {
                                optimalDayScheduleFound = true;
                                optimalDaysFound += 1;
                                foreach (Game tempGame in tempListOfValidGamesFound)
                                {
                                    validFinalSchedule.AddGame(new Game(tempGame.HomeTeam, tempGame.AwayTeam, scheduleDays[j]));
                                }
                                break;
                            }
                        }
                        //if sorting through the games per the day resulted in non-optimal day, start over with new permutation
                        if (!optimalDayScheduleFound)
                        {
                            break;
                        }
                    }
                    if (validFinalSchedule.Games.Count == validGames.Count)
                    {
                        isOptimalScheduleFound = true;
                    }
                }
                validGames.Clear();
                return validFinalSchedule;
            }
        }

        // Helper functions to check if a team plays more than once on a specific day
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
            foreach (string player in team1.Players)
            {
                if (team2.Players.Contains(player) || schedule.HasPlayerConflict(player, day))
                {
                    return true;
                }
            }
            foreach (string player in team2.Players)
            {
                if (team1.Players.Contains(player) || schedule.HasPlayerConflict(player, day))
                {
                    return true;
                }
            }
            return false;
        }
        static bool PlayerConflictBetweenTeams(Team team1, Team team2)
        {
            foreach (string player in team1.Players)
            {
                if (team2.Players.Contains(player))
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
            tempTeams.Add(new Team("Team A", "ABC", new List<string> { "Player11", "Player12", "Player13", "Player14" })); //shares Player1 with C
            tempTeams.Add(new Team("Team B", "ABC", new List<string> { "Player21", "Player22", "Player23", "Player24" }));
            tempTeams.Add(new Team("Team C", "ABC", new List<string> { "Player31", "Player32", "Player33", "Player34" })); //shares Player1 with A
            tempTeams.Add(new Team("Team D", "ABC", new List<string> { "Player41", "Player42", "Player43", "Player44" }));
            tempTeams.Add(new Team("Team E", "ABC", new List<string> { "Player51", "Player52", "Player53", "Player54" }));
            tempTeams.Add(new Team("Team F", "ABC", new List<string> { "Player61", "Player62", "Player63", "Player64" }));
            //teams.Add(new Team("Team G", "ABC", new List<string> { "Player991", "Player955", "Player916", "Player925" }));
            ////
            //display added teams in DGV
            foreach (Team team in tempTeams)
            {
                teams.Add(team);
                string[] players = team.Players.ToArray();
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
            tempTeams.Add(new Team("Test1", "Devs", new List<string> { "Dev11", "Dev12", "Dev13", "Dev14" })); //shares Player1 with C
            tempTeams.Add(new Team("Test2", "Devs", new List<string> { "Dev21", "Dev22", "Dev23", "Dev24" }));
            tempTeams.Add(new Team("Test3", "Devs", new List<string> { "Dev31", "Dev32", "Dev33", "Dev34" })); //shares Player1 with A
            tempTeams.Add(new Team("Test4", "Devs", new List<string> { "Dev41", "Dev42", "Dev43", "Dev44" }));
            tempTeams.Add(new Team("Test5", "Devs", new List<string> { "SameDev", "Dev52", "Dev53", "Dev54" }));
            tempTeams.Add(new Team("Test6", "Devs", new List<string> { "SameDev", "Dev62", "Dev63", "Dev64" }));
            //teams.Add(new Team("Team G", "ABC", new List<string> { "Player991", "Player955", "Player916", "Player925" }));
            ////
            //display added teams in DGV
            foreach (Team team in tempTeams)
            {
                teams.Add(team);
                string[] players = team.Players.ToArray();
                dgvTeams.Rows.Add(team.name, team.league, players[0], players[1], players[2], players[3]);
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


            teams.Add(new Team(teamName, teamLeague, new List<string> { teamPlayer1, teamPlayer2, teamPlayer3, teamPlayer4 }));
            dgvTeams.Rows.Add(teamName, teamLeague, teamPlayer1, teamPlayer2, teamPlayer3, teamPlayer4);
        }
    }
}
