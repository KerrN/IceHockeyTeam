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
using System.ComponentModel;
using System.Collections.Generic;

namespace icehockeyWA.Models
{
    public class Team : INotifyPropertyChanged
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
        public int GoalCounter
        {
            get
            {
                return goalCounter;
            }
        }
        private int shotCounter;
        private int penaltyCounter;
        public List<Player> players;
        private int managerID;
        private string managerName;
        private bool managerSignedOff;
        public Goalie currentGoalie;
        
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
            players = new List<Player>();
        }

        public Team()
        {

        }

        public void addPlayer(int id, string name, int num)
        {
            players.Add(new Player(id, name, num));
        }

        public void addGoalie(int id, string name, int num)
        {
            Goalie myGoalie = new Goalie(id, name, num);
            players.Add(myGoalie);
            currentGoalie = myGoalie;
        }

        public void addGoalieFromPlayer(Player myPlayer)
        {
            Goalie myGoalie = null;
            
            //ensure the current player is removed from the list
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Equals(myPlayer))
                {
                    //if there is a player object matching the given player

                    //if that player is a goalie
                    if (players[i].GetType().ToString().Equals("icehockeyWA.Models.Goalie"))
                    {
                        //set the current goalie to that player
                        myGoalie = (Goalie)players[i];
                    }
                    else
                    {
                        players.RemoveAt(i);
                        //create a new goalie object in the list
                        myGoalie = new Goalie(myPlayer.playerID, myPlayer.name, myPlayer.number);
                        players.Add(myGoalie);
                    }
                }
            }

            currentGoalie = myGoalie;
        }

        public void addShot()
        {
            shotCounter++;
        }

        public int countPlayers()
        {
            return players.Count;
        }

        public int getNumberForPlayer(int index)
        {
            return players[index].number;
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

        public void addGoal(int playerNumber, int assist1, int assist2)
        {
            goalCounter += 1;
            
            PropChanged("GoalCounter");

            for(int i = 0; i < players.Count; i++)
            {
                if(players[i].number.Equals(playerNumber))
                {
                    players[i].addGoal();
                }
                else if (players[i].number.Equals(assist1) || players[i].number.Equals(assist2))
                {
                    players[i].addAssist();
                }
            }
        }

        public void addPenalty()
        {
            penaltyCounter++;
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

        public void incrementGoalieCounter()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if(players[i].Equals(currentGoalie))
                {
                    players[i].addGoalAgainst();
                }
            }
        }

        //this team saved a shot
        public void addSave()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Equals(currentGoalie))
                {
                    players[i].addShotAgainst();
                }
            }
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
