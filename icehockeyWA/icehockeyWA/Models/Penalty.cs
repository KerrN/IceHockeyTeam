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
    public class Penalty : Event
    {
        public static int nextPenaltyID = 0;

        public static int getNextPenaltyID()
        {
            nextPenaltyID++;
            return nextPenaltyID;
        }

        public int penaltyID;
        public int playerID;
        public int minutes;
        public string offence;
        public bool penaltyShootout;

        public Penalty(int team, string period, int playerID, int minutes, string offence, bool penalty)
            : base(team, period)
        {
            penaltyID = getNextPenaltyID();
            this.playerID = playerID;
            this.minutes = minutes;
            this.offence = offence;
            penaltyShootout = penalty;
        }

        public override string ToString()
        {
            int delta = 0;
            string s = period +
                ": Player (ID ";
           s+=playerID + ") from team (ID " + teamID + ") was penalised!";
           s += "\r\n\t\t\tThe penalty was for " + minutes + " minutes, for " + offence + ".";

            return s;
        }
    }
}
