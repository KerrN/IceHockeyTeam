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

//made by jinho, fixed by josh

namespace icehockeyWA.Models
{
    public class PenaltyModel : EventModel
    {
        private int _playerNumber;
        private string _offence;
        private int _minutes;
        private bool _penaltyShootout;

        public PenaltyModel(int teamID, DateTime eventTime, string period,
            int playerNumber, string offence, int minutes, bool penaltyShootout)
            : base(teamID, eventTime, period)
        {
            _playerNumber = playerNumber;
            _offence = offence;
            _minutes = minutes;
            _penaltyShootout = penaltyShootout;
        }
        public int PlayerNumber
        {
            get { return _playerNumber; }
            set { _playerNumber = value; }
        }

        public string Offence
        {
            get { return _offence; }
            set { _offence = value; }
        }

        public int Minutes
        {
            get { return _minutes; }
            set { _minutes = value; }

        }
    }
}
