using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<ScheduledTime> scheduledTimes = new List<ScheduledTime>();
        List<Team> teams = new List<Team>();
        static List<List<Game>> validGameLists = new List<List<Game>>();
        static List<Game> validGames = new List<Game>();
        static List<Game> currentGameList = new List<Game>();
        static List<List<Team>> teamPermutations = new List<List<Team>>();
        static bool isConflict = false;
        private static Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        static Schedule GenerateSchedule(List<Team> teamsInput)
        {
            List<Team> remainingTeams = new List<Team>(teamsInput);
            Schedule maxSchedule = new Schedule(); //max schedule that had highest number of games
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
                new DateTime(2024, 1, 11)
            }; // Example: Tuesday and Wednesday
            Schedule schedule = new Schedule();

            //if no conflicts:
            //todo 1/11
            //add if conflicts allowed check
            if (isConflict == false)
            {
                //returns every possible game that can be paired up
                for (int i = 0; i < teamsInput.Count - 1; i++)
                {
                    for (int j = i + 1; j < teamsInput.Count; j++)
                    {
                        validGames.Add(new Game(remainingTeams[i], remainingTeams[j], DateTime.MaxValue));
                    }
                }
                //TODO
                //make these variables automatic based on teams/schedule
                int gameDays = 5;
                int gamesPerDay = 3;
                int countGames = 0; //used to track how many games are counted each day when optimizing schedule
                bool isOptimal = false;
                int optimalDays = 0; //amount of optimal days collected so far until we hit our goal number
                List<Game> tempList = new List<Game>();
                Schedule tempSchedule = new Schedule();
                bool validSchedule = false;
              
                //cycle through every game variation that we collected above
                while (validSchedule == false)
                {
                    validGameLists.Clear();
                    GenerateGamePermutations(validGames, 0);
                    currentGameList = validGameLists[0];
                    currentGameList = RandomGames(currentGameList);
                    optimalDays = 0;
                    schedule.Games.Clear();
                    tempList.Clear();

                    //cycling through every day
                    //track if day is optimal or not
                    for (int j = 0; j < gameDays; j++)
                    {
                        tempList.Clear();
                        tempSchedule.Games.Clear();

                        foreach (Game game in schedule.Games)
                        {
                            tempSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, game.ScheduledTime));
                        }
                        isOptimal = false;
                        countGames = 0;
                        foreach (Game game in currentGameList)
                        {
                            if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, tempSchedule, scheduleDays[j]))
                            {
                                tempSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                                tempList.Add(game);
                                countGames += 1;
                            }
                            if (countGames == gamesPerDay)
                            {
                                isOptimal = true;
                                optimalDays += 1;
                                break;
                            }
                        }
                        if (countGames <= gamesPerDay - 1)
                        {
                            isOptimal = false;
                            break;
                        }
                        if (isOptimal == true)
                        {
                            foreach (Game game in tempList)
                            {
                                schedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                            }
                        }
                    }

                    //if the schedule is still optimal after all time slots filled
                    if (isOptimal == true)
                    {
                        validSchedule = true;
                    }
                }
                return schedule;
            }
            else
            {
                ////is this needed anymore?? 1/11
                ////GenerateTeamPermutations(teamsInput, 0);
                ////starting team


                ////todo 1/11
                ///NOTE: this code is likely deprecated
                ////finish this half of the implementation for basic conflict solutions
                ////sort through every permutation
                //bool validSchedule = false;
                //while (validSchedule == false)
                //{
                //    schedule.Games.Clear();
                //    remainingTeams = new List<Team>(teamPermutations[0]);

                //    for (int i = teamsInput.Count - 1; i >= 0; i--)
                //    {
                //        Team currentTeam = remainingTeams[i];
                //        remainingTeams.RemoveAt(i);
                //        //check each day in the schedule
                //        for (int j = 0; j < scheduleDays.Length; j++)
                //        {
                //            //cycle through each possible opponent for current team
                //            //if valid opponent, add it to schedule
                //            foreach (Team opponent in remainingTeams)
                //            {
                //                if (!HasPlayerConflicts(currentTeam, opponent, schedule, scheduleDays[j]) &&
                //                    !TeamsPlayMoreThanOncePerDay(currentTeam, scheduleDays[j], schedule) &&
                //                    !TeamsPlayMoreThanOncePerDay(opponent, scheduleDays[j], schedule) &&
                //                    !TeamsAlreadyPlayed(currentTeam, opponent, schedule, scheduleDays[j]))
                //                {
                //                    // Schedule the game
                //                    schedule.AddGame(new Game(currentTeam, opponent, scheduleDays[j]));
                //                }
                //            }
                //        }
                //    }

                //    List<Game> validGames = new List<Game>();

                //    foreach (Game game in schedule.Games)
                //    {
                //        validGames.Add(game);
                //    }
                //    int gameSlotsCount = 0; //count amount of slots that have a game scheduled and if amount of slots used was optimal
                //    for (int i = 0; i < scheduleDays.Length; i++)
                //    {
                //        //if any game is in that time slot at all, increase slot count by 1 and go to next possible slot
                //        foreach (Game game in schedule.Games)
                //        {
                //            if (game.ScheduledTime == scheduleDays[i])
                //            {
                //                gameSlotsCount += 1;
                //                break;
                //            }
                //        }
                //    }
                //    //determine if the current schedule exists in a set of most optimal games
                //    if ((schedule.Games.Count > maxSchedule.Games.Count) && (gameSlotsCount <= 9))
                //    {
                //        maxSchedule = schedule;
                //        validSchedule = true;
                //    }
                //}
                //return maxSchedule;

                //begin here my experiment merigng the two
                for (int i = 0; i < teamsInput.Count - 1; i++)
                {
                    for (int j = i + 1; j < teamsInput.Count; j++)
                    {
                        if (remainingTeams[i].name.Equals("Test5") || remainingTeams[i].name.Equals("Test6"))
                        {
                            if (remainingTeams[j].name.Equals("Test5") || remainingTeams[j].name.Equals("Test6"))
                            {
                                break;
                            }
                        }
                        validGames.Add(new Game(remainingTeams[i], remainingTeams[j], DateTime.MaxValue));
                    }
                }

                int gameDays = 8;
                int gamesPerDay = 2;
                int countGames = 0; //used to track how many games are counted each day when optimizing schedule
                bool isOptimal = false;
                int optimalDays = 0; //amount of optimal days collected so far until we hit our goal number
                List<Game> tempList = new List<Game>();
                Schedule tempSchedule = new Schedule();
                bool validSchedule = false;

                while (validSchedule == false)
                {
                    validGameLists.Clear();
                    GenerateGamePermutations(validGames, 0);
                    currentGameList = validGameLists[0];
                    currentGameList = RandomGames(currentGameList);
                    optimalDays = 0;
                    schedule.Games.Clear();
                    tempList.Clear();

                    //cycling through every day
                    //track if day is optimal or not
                    for (int j = 0; j < gameDays; j++)
                    {
                        tempList.Clear();
                        tempSchedule.Games.Clear();

                        foreach (Game game in schedule.Games)
                        {
                            tempSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, game.ScheduledTime));
                        }
                        isOptimal = false;
                        countGames = 0;
                        foreach (Game game in currentGameList)
                        {
                            //(!HasPlayerConflicts(currentTeam, opponent, schedule, scheduleDays[j]) &&
                            //!TeamsPlayMoreThanOncePerDay(currentTeam, scheduleDays[j], schedule) &&
                            //!TeamsPlayMoreThanOncePerDay(opponent, scheduleDays[j], schedule) &&
                            //!TeamsAlreadyPlayed(currentTeam, opponent, schedule, scheduleDays[j]))

                            if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, tempSchedule, scheduleDays[j]) &&
                                !TeamsPlayMoreThanOncePerDay(game.HomeTeam, scheduleDays[j], tempSchedule) &&
                                !TeamsPlayMoreThanOncePerDay(game.AwayTeam, scheduleDays[j], tempSchedule) &&
                                !HasPlayerConflicts(game.HomeTeam, game.AwayTeam, tempSchedule, scheduleDays[j]))
                            {
                                tempSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                                tempList.Add(game);
                                countGames += 1;
                            }
                            if ((countGames == gamesPerDay) && j < 6)
                            {
                                isOptimal = true;
                                optimalDays += 1;
                                break;
                            }
                            else if ((countGames == gamesPerDay - 1) && j >= 6)
                            {
                                isOptimal = true;
                                optimalDays += 1;
                                break;
                            }
                        }
                        if ((countGames <= gamesPerDay - 1) && j < 6)
                        {
                            isOptimal = false;
                            break;
                        }
                        if (isOptimal == true)
                        {
                            foreach (Game game in tempList)
                            {
                                schedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[j]));
                            }
                        }
                    }
                    //if the schedule is still optimal after all time slots filled
                    if (isOptimal == true)
                    {
                        validSchedule = true;
                    }
                }
                return schedule;
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
        static List<Game> RandomGames(List<Game> games)
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

            scheduledTimes.Add(new ScheduledTime(league, date, startTime, endTime));
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
        private void chkIsConflict_CheckedChanged(object sender, EventArgs e)
        {
            isConflict = !isConflict;
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
    }
}
