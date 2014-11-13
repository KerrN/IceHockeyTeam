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
    public class Event
    {

        public static int nextID = 0;

        public static int getNextID()
        {
            nextID++;
            return nextID;
        }

        public int eventID;
        public int teamID;
        public DateTime eventTime;
        public string period;

        public Event(int team, string period)
        {
            eventID = getNextID();
            teamID = team;
            eventTime = DateTime.Now;
            this.period = period;
        }
    }
}
