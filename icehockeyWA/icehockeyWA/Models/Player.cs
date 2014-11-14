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

namespace icehockeyWA.Models
{
    public class Player
    {
        public int playerID;
        public string name;
        public int number;
        public int goals;
        public int assists;

        public Player(int id, string name, int num)
        {
            this.playerID = id;
            this.name = name;
            this.number = num;

            goals = 0;
            assists = 0;
        }

        public void addGoalAgainst()
        {
            //this is a stub
        }

        public void addShotAgainst()
        {
            //this is a stub
        }

        public void addGoal()
        {
            goals++;
        }

        public void addAssist()
        {
            assists++;
        }

        public override string ToString()
        {
            return name + " (" + number + ")";
        }
    }
}
