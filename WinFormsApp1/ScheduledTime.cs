using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ScheduledTime
    {
        public DateTime date { get; }
        public DateTime startTime { get; }
        public DateTime endTime { get; }
        public string teamLeague { get; }

        public ScheduledTime(string league, DateTime dateDay, DateTime start, DateTime end)
        {
            this.date = dateDay;
            this.startTime = start;
            this.endTime = end;
            this.teamLeague = league;
        }

       public string ReturnString()
        {
            string returnString = "";
            returnString += "League: " + teamLeague + " Start: " + startTime + " End: " + endTime;
            return returnString;
        }
    }
}
