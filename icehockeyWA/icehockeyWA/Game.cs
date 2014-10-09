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
using System.ComponentModel;


namespace icehockeyWA
{
    public class Game : INotifyPropertyChanged
    {
        private int gameID;
        public Team homeTeam;
        public Team awayTeam;
        private DateTime gameTime;
        private string venue;
        private string division;
        private List<Official> officials;
        private string notes;
//      private Event[] events;
        private string currentPeriod;
        public string CurrentPeriod
        {
            get
            {
                return currentPeriod;
            }
        }


        public Game(int ID, DateTime time, String venue, string division)
        {
            this.gameID = ID;
            this.gameTime = time;
            this.venue = venue;
            this.division = division;

            this.notes = "";
            this.currentPeriod = "Period 0";
            this.officials = new List<Official>();
        }

        public void beginGame()
        {
            if (currentPeriod == "Period 0")
                currentPeriod = "Period 1";

            PropChanged("CurrentPeriod");
        }

        public void nextPeriod()
        {
            if(currentPeriod == "Period 1")
                currentPeriod = "Period 2";
            else if (currentPeriod == "Period 2")
                currentPeriod = "Period 3";

            PropChanged("CurrentPeriod");
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


        public event PropertyChangedEventHandler PropertyChanged;
        private void PropChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }


}
