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
        static List<List<Team>> teamPermutations = new List<List<Team>>();

        public Form1()
        {
            InitializeComponent();
        }


        //example of valid possible combinations
        //A/B
        //C/D
        //E/F

        //A/D A/E A/F
        //B/C B/D B/D
        //    C/F C/E
        //should be using combinatorics?
        static Schedule GenerateSchedule(List<Team> teamsInput)
        {
            List<Team> remainingTeams = new List<Team>(teamsInput);
            Schedule maxSchedule = new Schedule(); //max schedule that had highest number of games

            // Define the days for scheduling
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


            //question is can we figure out a way to determine if a conflict is necessary before even sorting?
            //based on:
            //--amount of games played and
            //--amount of days played and
            //--limit of repeat games against same teams or
            //--if home vs away switching versus same team counts as different game
            //if conflict necessary:
            //  solve for most optimal but add conflicts and display them after
            //if not necessary:
            //  solve for most optimal combination for every day
            //  if run into non-optimal roadblock, backtrack and go again

            //say "Warning - given the amount of teams, days, and current settings (no repeat games, limit home/away games), there is forced to be conflicts in the schedule.
            //  "please either reduce the amount of necessary days, add repeat game days, add byes, or substitute conflicting players to complete schedule"

            //determine what the mathematically optimal variation combination amount is given a count of teams in a league
            //
            //e.g., 6 teams is 3 combinations
            //take into account teams with same players - must solve graph to check most optimal amount of games
            //if we find a most optimal game pattern, store it in an array to bring to next day
            //on next day, do same graph but making sure teams don't play same team as before, or if they do it's home/away mixed //(toggle option for amount of home/away games?//
            //

            //user options
            //choose timeframe
            //specific time frame - (month of june, 10 weeks, etc.)
            //as many days as necessary - x amount
            //  play once a day, x days per week (sun-sat choice bar) [treat this as 1 "time slot" for the whole day]
            //  play multiple times a day [x slots per day, same or manual entered]
            // each unique time slot (either full day or partial slot in a day) is one cycle of the schedule algorithm

            //round robin vs double round robin choice
            //force each team to play, even with conflicts [a/c share a player, but must play due to tournament rules]
            //don't force each team to play, due to conflicts [a/c share a player, and can be ignored in tournament]
            //don't allow any conflicts at all [if not possible to fill in schedule, warning should appear]

            //looking at layout of teams
            //1.    determine amount of conflicts (a / b share, b / c share, etc.)
            //2.    determine amount of combinations[games](formula - amount of conflicts)
            //
            // [max amount of games] where every team plays every other team (without conflicts) once
            // [max amount of games] where every combination plays twice (home and away)
            // based on options:
            //      if no conflicts in teams, or if forceeachteamplay = true
            //          then can solve most optimal for every set (max combinations per day)
            //      if force each team play == false & dontallowconflicts = true
            //          if (calender = limitedSlots)
            //              checkIfPOssible - if not, exit and inform not possible due to time constraint, unless dontallowconflicts = false
            //          if (calender = unlimitedSlots)
            //              determine amount of days necessary to complete schedule, given conflicts are limiting factor
            //      if forceeachteamplay == true & don'tllowconflicts = true
            //              give warning and say must allow conflicts if forcing all teams to play
            //      if forceeachteamplay =false & dontallowconflicts = false
            //              
            //
            // 
            //3. determine minimum amount of days must be played on, given conflicting players cant play at the same time
            //
            //4.    if playing one game a day, and min days > amount of days chosen
            //      //if allow conflicts = true, find most optimal combination and include x player conflicts as most optimal
            //if allow conflicts = false, bring warning and say conflicts necessary to provide schedule
            //5.    else, collect an array of every combination which results in an optimal combination every individual day
            //6.        step through each day, backtracking if necessary, until the most efficient array of games every day overall is chosen
            //
            //7.    if playing multiple games a day (different time slot), treat each timeslot like it's 1 day (same as above),
            //          but make sure if day = same, team status = same (home/away) for each and every game combination
            //8.        determine most optimal amount of games per day (max possible per day, most efficient)
            //9.         if playing x amount of games per day, for x days, make sure can fit every team in
            //      //if allow conflicts = true, find most optimal combination and include x player conflicts as most optimal
            //      if allow conflicts = false, bring warning and say conflicts necessary to provide schedule
            //5.        else, collect an array of every combination which results in an optimal combination every individual day
            //6.            step through each day, backtracking if necessary, until the most efficient array of games every day overall is chosen





            int teamsCount = teamsInput.Count;  //total teams playing, conflict or not
            int maxPairs = teamsCount / 2; //max per time slot without conflict
            int maxCombinations = 0; //max amount of combinations, including conflicts
            for (int i = teamsCount - 1; i > 0; i--)
            {
                maxCombinations += i;
            }

            //int numberOfConflicts = 0; //amount of conflicts with current teams
            //for each (Team opponent) in

            //int maxCombinationsWithoutConflict = 0;




            //starting team to cycle, counting down
            //cycle through every team and match them up against every opponent
            //if it's a valid game, add it to schedule

            //TODO 1/7
            //figure out how to re-sort this list in the case we end up with a non-optimal solution
            int amtOfPermutations = 1;
            for (int i = teamsCount; i > 0; i--)
            {
                amtOfPermutations = amtOfPermutations * i;
            }


            //list of lists of teams
            GeneratePermutations(teamsInput, 0);

            //if no conflicts:
            //returns every possible game that can be paired up
            for (int i = 0; i < teamsInput.Count - 1; i++)
            {
                for (int j = i + 1; j < teamsInput.Count; j++)
                {    
                    schedule.AddGame(new Game(remainingTeams[i], remainingTeams[j], DateTime.MaxValue));
                }
            }

            for (int i = 0; i < scheduleDays.Length; i++)
            {
                int count = schedule.AmountOfGamesOnADay(scheduleDays[i]);

                foreach (Game game in schedule.Games)
                {
                    if (count < 3)
                    {
                        if (game.ScheduledTime == DateTime.MaxValue)
                        {
                            if (!TeamsPlayMoreThanOncePerDay(game.HomeTeam, scheduleDays[i], schedule) &&
                                !TeamsPlayMoreThanOncePerDay(game.AwayTeam, scheduleDays[i], schedule))
                            {
                                game.ScheduledTime = scheduleDays[i];
                                count += 1;
                            }
                            //if (!TeamsAlreadyPlayed(game.HomeTeam, game.AwayTeam, schedule, scheduleDays[i]))
                            //{
                            //    game.ScheduledTime = scheduleDays[i];
                            //    // Schedule the game
                            //    //game.ScheduledTime = scheduleDays[i];
                            //    //maxSchedule.AddGame(new Game(game.HomeTeam, game.AwayTeam, scheduleDays[i]));
                            //    //schedule.Games.Remove(game);
                            //    count += 1;
                            //}
                        }
                    }

                }
            }

            return schedule;

            //foreach (DateTime day in scheduleDays)
            //{
            //    Console.WriteLine(day);
            //    PrintMatches(matches);
            //    RotateTeams(teams);
            //    Console.WriteLine();
            //}
            ////need to organize what it returns here to put 3 games per day
            //int dayCount = 0;
            //while (dayCount < 5)
            //{
            //    foreach (Game games in schedule.Games)
            //    {
            //        if (!TeamsAlreadyPlayed(games.HomeTeam, games.AwayTeam, schedule, scheduleDays[dayCount]))
            //        {
            //            maxSchedule.AddGame(new Game(games.HomeTeam, games.AwayTeam, scheduleDays[dayCount]));
            //            schedule.Games.Remove(games);
            //        }
            //    }
            //    dayCount += 1;
            //}
            //return maxSchedule;




            //sort through every permutation
            while (amtOfPermutations > 0)
            {
                schedule.Games.Clear();
                remainingTeams = new List<Team>(teamPermutations[amtOfPermutations - 1]);
                //starting team
                for (int i = teamsInput.Count - 1; i >= 0; i--)
                {
                    Team currentTeam = remainingTeams[i];
                    remainingTeams.RemoveAt(i);

                    //check each day in the schedule
                    for (int j = 0; j < scheduleDays.Length; j++)
                    {
                        //cycle through each possible opponent for current team
                        //if valid opponent, add it to schedule
                        foreach (Team opponent in remainingTeams)
                        {
                            if (!HasPlayerConflicts(currentTeam, opponent, schedule, scheduleDays[j]) &&
                                !TeamsPlayMoreThanOncePerDay(currentTeam, scheduleDays[j], schedule) &&
                                !TeamsPlayMoreThanOncePerDay(opponent, scheduleDays[j], schedule) &&
                                !TeamsAlreadyPlayed(currentTeam, opponent, schedule, scheduleDays[j]))
                            {
                                // Schedule the game
                                schedule.AddGame(new Game(currentTeam, opponent, scheduleDays[j]));
                            }
                        }


                        //int countGames = 0;
                        //foreach (Game game in schedule.Games)
                        //{
                        //    if (game.ScheduledTime == scheduleDays[j])
                        //    {
                        //        countGames += 1;
                        //    }
                        //}
                    }
                }
                int gameSlotsCount = 0; //count amount of slots that have a game scheduled
                //check if amount of slots used was optimal
                for (int i = 0; i < scheduleDays.Length; i++)
                {
                    //if any game is in that time slot at all, increase slot count by 1 and go to next possible slot
                    foreach (Game game in schedule.Games)
                    {
                        if (game.ScheduledTime == scheduleDays[i])
                        {
                            gameSlotsCount += 1;
                            break;
                        }
                    }
                }
                //determine if the current schedule exists in a set of most optimal games
                //
                if ((schedule.Games.Count > maxSchedule.Games.Count) && (gameSlotsCount <= 6))
                {
                    maxSchedule = schedule;
                }
                amtOfPermutations -= 1;
            }
            return maxSchedule;
        }
        // Helper function to check if a team plays more than once on a specific day
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
            teams.Add(new Team("Team A", "ABC", new List<string> { "Player1", "Player2", "Player11", "Player12" })); //shares Player1 with C
            teams.Add(new Team("Team B", "ABC", new List<string> { "Player3", "Player4","Player15", "Player23" }));
            teams.Add(new Team("Team C", "ABC", new List<string> { "Player19", "Player5", "Player16", "Player25" })); //shares Player1 with A
            teams.Add(new Team("Team D", "ABC", new List<string> { "Player31", "Player32", "Player311", "Player312" }));
            teams.Add(new Team("Team E", "ABC", new List<string> { "Player43", "Player44", "Player415", "Player423" }));
            teams.Add(new Team("Team F", "ABC", new List<string> { "Player51", "Player55", "Player516", "Player525" }));
            //teams.Add(new Team("Team G", "ABC", new List<string> { "Player991", "Player955", "Player916", "Player925" }));
            ////
            //display added teams in DGV
            foreach (Team team in teams)
            {
                string[] players = team.Players.ToArray();
                dgvTeams.Rows.Add(team.name, team.league, players[0], players[1], players[2], players[3]);
            }
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
        static void GeneratePermutations(List<Team> list, int currentIndex)
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
                GeneratePermutations(list, currentIndex + 1);
                Swap(list, currentIndex, i);
            }
        }
        //used for generatic every permutation
        static void Swap(List<Team> list, int index1, int index2)
        {
            Team temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

    }
}
