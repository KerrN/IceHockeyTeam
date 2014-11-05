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
    public class EventModel
    {
        private static int EVENT_ID = 1;

        private int _eventID = 0;
        private int _teamID;
        private DateTime _eventTime;
        private string _period;

        public EventModel(int teamID, DateTime eventTime, string period)
        {
            _eventID = EVENT_ID++;
            _teamID = teamID;
            _eventTime = eventTime;
            _period = period;
        }
    }
}
