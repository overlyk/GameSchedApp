using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Team
    {
        //string teamName;
        //string teamLeague;
        //string teamPlayer1;
        //string teamPlayer2;
        //string teamPlayer3;
        //string teamPlayer4;

        //public Team(string teamName, string teamLeague, string teamPlayer1, string teamPlayer2, string teamPlayer3, string teamPlayer4)
        //{
        //    this.teamName = teamName;
        //    this.teamLeague = teamLeague;
        //    this.teamPlayer1 = teamPlayer1;
        //    this.teamPlayer2 = teamPlayer2;
        //    this.teamPlayer3 = teamPlayer3;
        //    this.teamPlayer4 = teamPlayer4;
        //}


        public string name { get; }
        public string league { get; }
        public List<string> Players { get; }


        public Team(string name, string league, List<string> players)
        {
            this.name = name;
            this.Players= players;
            this.league = league;
        }
    }
}
