using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Game
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public DateTime ScheduledTime { get; set; }

        public Game(Team homeTeam, Team awayTeam, DateTime scheduledTime)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            ScheduledTime = scheduledTime;
        }
    }
}
