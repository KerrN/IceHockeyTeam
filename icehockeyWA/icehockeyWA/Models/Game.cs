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


namespace icehockeyWA.Models
{
    public class Game : INotifyPropertyChanged
    {
        public int gameID;
        public Team homeTeam;
        public Team awayTeam;
        public DateTime gameTime;
        public string venue { get; set; }
        public string division;
        public List<Official> officials;
        public string notes;
        public List<Event> events;
        public string currentScore = "0 | 0";
        public string currentPeriod;
        public string CurrentPeriod
        {
            get
            {
                return currentPeriod;
            }
        }

        public string CurrentScore { get{
            return currentScore;
        }
            set {
                currentScore = homeTeam.getGoalCounter() + " | " + awayTeam.getGoalCounter(); ;
                PropChanged("CurrentScore");
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
            this.events = new List<Event>();
        }

        public void addEvent(Goal myGoal)
        {
            events.Add(myGoal);
        }

        public void addEvent(Penalty myPenalty)
        {
            events.Add(myPenalty);
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

        public void addOfficial(string name, string type)
        {
            officials.Add(new Official(name, type));
        }


        public List<Official> getOfficialsByType(string type)
        {
            List<Official> result = new List<Official>();

            for(int i = 0; i < officials.Count; i++)
            {
                if(officials[i].getType().Equals(type))
                {
                    result.Add(officials[i]);
                }
            }

            return result;
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
