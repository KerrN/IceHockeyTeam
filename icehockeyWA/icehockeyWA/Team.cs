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
using System.Collections.ObjectModel;

namespace icehockeyWA
{
    public class Team
    {
        private int teamID;
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }
        private int goalCounter;
        private int shotCounter;
        private int penaltyCounter;
        //private Player[] players;
        private int managerID;
        private string managerName;
        private bool managerSignedOff;
        //private Goalie currentGoalie;
        
        //constructor specifying the required details
        public Team(int teamID, string teamName, int managerID, string managerName)
        {
            //initialise the given values
            this.teamID = teamID;
            this.name = teamName;
            this.managerID = managerID;
            this.managerName = managerName;
            //this.players = new Player[];

            //set some defaults
            goalCounter = 0;
            shotCounter = 0;
            penaltyCounter = 0;
            managerSignedOff = false;
        }

        public int getTeamID()
        {
            return teamID;
        }

        public string getTeamName()
        {
            return name;
        }

        public int getGoalCounter()
        {
            return goalCounter;
        }

        public int getPenaltyCounter()
        {
            return penaltyCounter;
        }

        public int getShotCounter()
        {
            return shotCounter;
        }

        public int getManagerID()
        {
            return managerID;
        }

        public string getManagerName()
        {
            return managerName;
        }

        public bool isManagerSignedOff()
        {
            return managerSignedOff;
        }

        //public Goalie getCurrentGoalie()
        //{
        //    return currentGoalie;
        //}

        //public Player getPlayerAt(int index)
        //{
        //    return players[index];
        //}

        //public PlayerNumber getPlayerByName(string name)
        //{
        //    Player foundPlayer = null;

        //    for (int i = 0; i < players.count; i++)
        //    {
        //        if (players[i].getName() == name)
        //        {
        //            foundPlayer = players[i];
        //        }
        //    }
        //    return foundPlayer;
        //}

        //public PlayerNumber getPlayerByNumber(int number)
        //{
        //    Player foundPlayer = null;

        //    for (int i = 0; i < players.count; i++)
        //    {
        //        if (players[i].getNumber() == number)
        //        {
        //            foundPlayer = players[i];
        //        }
        //    }
        //    return foundPlayer;
        //}

    }
}
