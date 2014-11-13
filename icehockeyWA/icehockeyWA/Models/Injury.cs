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
    public class Injury : Event
    {
        public static int nextInjuryID = 0;

        public static int getNextInjuryID()
        {
            nextInjuryID++;
            return nextInjuryID;
        }

        public int injuryID;
        public int playerID;
        public string injuryDescription;

        public Injury(int team, string period, int playerID, string desc)
            : base(team, period)
        {
            injuryID = getNextInjuryID();
            this.playerID = playerID;
            injuryDescription = desc;
        }
    }
}
