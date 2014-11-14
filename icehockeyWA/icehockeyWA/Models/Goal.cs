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
    public class Goal : Event
    {
        public static int nextGoalID = 0;

        public static int getNextGoalID()
        {
            nextGoalID++;
            return nextGoalID;
        }

        public int goalID;
        public int playerID;
        public int assist1Player;
        public int assist2Player;
        public bool penaltyShootout;

        public Goal(int team, string period, int playerID, int assist1Player, int assist2Player, bool penalty)
            : base(team, period)
        {
            goalID = getNextGoalID();
            this.playerID = playerID;
            this.assist1Player = assist1Player;
            this.assist2Player = assist2Player;
            penaltyShootout = penalty;
        }

        public override string ToString()
        {
            string s = period + ": Player (ID " + playerID + ") from team (ID " + teamID + ") scored a goal!";

            if (assist1Player != -1 && assist2Player != -1)
            {
                s += "\r\n\t\t\tPlayers (ID " + assist1Player + ") and (ID " + assist2Player + ") assisted!";
            }
            else if (assist1Player != -1)
            {
                s += "\r\n\t\t\tPlayer (ID " + assist1Player + ") assisted!";
            }

            return s;
        }
    }
}
