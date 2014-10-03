using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.Generic;


namespace icehockeyWA
{
    public class Game
    {
        private int gameID;
        public Team homeTeam;
        public Team awayTeam;
        private DateTime gameTime;
        private String venue;
        private String division;
        private List<Official> officials;
        private String notes;
//      private Event[] events;
        private String currentPeriod;

        public Game(int ID, DateTime time, String venue, String division)
        {
            this.gameID = ID;
            this.gameTime = time;
            this.venue = venue;
            this.division = division;

            this.notes = "";
            this.currentPeriod = "Period 0";
            this.officials = new List<Official>();
        }

        public void setHomeTeam(int teamID, string teamName, int managerID, string managerName)
        {
            homeTeam = new Team(teamID, teamName, managerID, managerName);
        }

        public void setAwayTeam(int teamID, string teamName, int managerID, string managerName)
        {
           awayTeam = new Team(teamID, teamName, managerID, managerName);
        }

        public void addOfficial(int officialID, string name, string type)
        {
            officials.Add(new Official(officialID, name, type));
        }
    }


}
