using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Schedule
    {
        public List<Game> Games { get; }

        //should schedule consist of a list of time slots?
        //then optimize the games into those timeslots and assign a day

        public Schedule()
        {
            Games = new List<Game>();
        }
        public void AddGame(Game game)
        {
            Games.Add(game);
        }
        public bool HasPlayerConflict(string player, DateTime day)
        {
            foreach (Game game in Games)
            {
                if ((game.HomeTeam.PlayerSet.Contains(player) || game.AwayTeam.PlayerSet.Contains(player)) && (game.ScheduledTime == day))
                {
                    return true;
                }
            }
            return false;
        }
        public int AmountOfGamesOnADay(DateTime day)
        {
            int count = 0;
            foreach (Game game in Games)
            {
                if (game.ScheduledTime == day)
                {
                    count++;
                }
            }
            return count;
        }
        // Method to remove the last game added to the schedule
        public void RemoveLastGame()
        {
            if (Games.Count > 0)
            {
                Games.RemoveAt(Games.Count - 1);
            }
        }
    }
}
