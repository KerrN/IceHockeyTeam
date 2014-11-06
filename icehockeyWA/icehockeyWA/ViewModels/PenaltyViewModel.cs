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
using System.ComponentModel;
using System.Collections.ObjectModel;
using icehockeyWA.Models;
using System.Collections.Generic;
using Penalty;

// made by jinho, fixed by josh

namespace icehockeyWA.ViewModels
{
    public class PenaltyViewModel : ViewModelBase
    {
        private ObservableCollection<PenaltyModel> _penaltyCollection;
        private PlayerDataSource _playerList;
        private PlayerDataSource _minuteList;
        private PlayerDataSource _offenceList;

        private bool _penaltyShootout;
        private string _homeAwayTextBlock;

        private RelayCommand _addHomePenalty;
        private RelayCommand _addAwayPenalty;

        public PenaltyViewModel()
        {
            _addHomePenalty = new RelayCommand(AddHomePenaltyEvent);
            _addAwayPenalty = new RelayCommand(AddAwayPenaltyEvent);
            AddHomePenalty.IsEnabled = true;
            AddAwayPenalty.IsEnabled = true;
            _penaltyCollection = new ObservableCollection<PenaltyModel>();

            //Test List for looping data source
            List<string> tempList = new List<string> { "1", "2", "3", "4", "5", "6" };
            List<string> tempOffenceList = new List<string> { "Abuse of officials", "Boarding", "Charging", 
                "Checking from behind", "Delay of game", "Elbowing", "Fighting", "High-sticking" };

            _playerList = new PlayerDataSource(tempList);
            _offenceList = new PlayerDataSource(tempOffenceList);
            _minuteList = new PlayerDataSource(tempList);
        }

        public ObservableCollection<PenaltyModel> PenaltyCollection
        {
            get { return _penaltyCollection; }
            set
            {
                _penaltyCollection = value;
            }
        }

        public bool IsPenaltyShootout
        {
            get { return _penaltyShootout; }
            set
            {
                _penaltyShootout = value;
            }
        }

        public RelayCommand AddHomePenalty
        {
            get { return _addHomePenalty; }
        }

        public RelayCommand AddAwayPenalty
        {
            get { return _addAwayPenalty; }
        }

        public void AddHomePenaltyEvent()
        {
            //Test Penalty Model
            PenaltyCollection.Add(new PenaltyModel(1, DateTime.Now, "Period 1",
                int.Parse(PlayerList.SelectedItem.ToString()), OffenceList.SelectedItem.ToString(),
                int.Parse(MinuteList.SelectedItem.ToString()), IsPenaltyShootout));
            _homeAwayTextBlock = "Home";
        }

        public void AddAwayPenaltyEvent()
        {
            //Test Penalty Model
            PenaltyCollection.Add(new PenaltyModel(2, DateTime.Now, "Period 1",
                int.Parse(PlayerList.SelectedItem.ToString()), OffenceList.SelectedItem.ToString(),
                int.Parse(MinuteList.SelectedItem.ToString()), IsPenaltyShootout));
            _homeAwayTextBlock = "Away";
        }

        public string HomeAwayTextBlock
        {
            get { return _homeAwayTextBlock; }
        }

        public void CanAddHomePenalty()
        {
            if (PlayerList.SelectedItem != null)
            {
                AddHomePenalty.IsEnabled = true;
            }
        }

        public PlayerDataSource PlayerList
        {
            get { return _playerList; }
        }

        public PlayerDataSource MinuteList
        {
            get { return _minuteList; }
        }

        public PlayerDataSource OffenceList
        {
            get { return _offenceList; }
        }
    }
}
