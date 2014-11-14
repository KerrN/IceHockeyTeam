using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using icehockeyWA.Models;
using Microsoft.Phone.Shell;

namespace icehockeyWA.Views
{
    public partial class ChangeGoalieView : PhoneApplicationPage
    {
        private SolidColorBrush white = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        private SolidColorBrush black = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;
        Team team;

        public ChangeGoalieView()
        {
            InitializeComponent();

            loadGame();
            loadDefaultView();
        }

        private void loadDefaultView()
        {
            btnHome.Background = white;
            btnAway.Background = black;

            btnHome.Foreground = black;
            btnAway.Foreground = white;

            team = myGame.homeTeam;
            loadPlayerOptions();
        }

        public void loadGame()
        {
            object temp;

            if (phoneAppService.State.ContainsKey("myGame"))
            {
                if (phoneAppService.State.TryGetValue("myGame", out temp))
                {
                    myGame = (Game)temp;
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.GoBack();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            btnHome.Background = white;
            btnAway.Background = black;

            btnHome.Foreground = black;
            btnAway.Foreground = white;
            team = myGame.homeTeam;

            loadPlayerOptions();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            btnHome.Background = black;
            btnAway.Background = white;

            btnHome.Foreground = white;
            btnAway.Foreground = black;
            team = myGame.awayTeam;

            loadPlayerOptions();
        }

        private void loadPlayerOptions()
        {
            lstBoxGoalies.Items.Clear();

            for (int i = 0; i < team.players.Count; i++)
            {
                lstBoxGoalies.Items.Add(team.players[i].ToString());

                //if that player is a goalie
                if (team.players[i].Equals(team.currentGoalie))
                {
                    //select this player as the current goalie
                    lstBoxGoalies.SelectedIndex = i;
                }
            }
        }

        private void createNewGoalie()
        {
            Player myPlayer = null;

            for (int i = 0; i < team.players.Count; i++)
            {
                if(lstBoxGoalies.SelectedItem.ToString().Equals(team.players[i].ToString()))
                {
                    myPlayer = team.players[i];
                }
            }

            team.addGoalieFromPlayer(myPlayer);
            MessageBox.Show("The goalie was successfully changed to " + myPlayer.ToString());
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            if (lstBoxGoalies.SelectedItems.Count == 1)
            {
                createNewGoalie();
            }
        }
    }
}