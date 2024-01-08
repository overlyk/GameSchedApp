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
                if ((game.HomeTeam.Players.Contains(player) || game.AwayTeam.Players.Contains(player)) && (game.ScheduledTime == day))
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
    }
}
