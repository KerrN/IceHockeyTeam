﻿using System;
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
using System.Windows.Threading;
using icehockeyWA.Models;

namespace icehockeyWA.Views
{
    public partial class GameView : PhoneApplicationPage
    {
        /* By Jinho
         * */
        //Declare timer, time
        static DispatcherTimer timer;
        static TimeSpan time;
        static TimeSpan second;

        public Game currentGame;

        // Constructor
        public GameView()
        {
            InitializeComponent();

            //Initialize timer
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);            
            timer.Tick += new EventHandler(TimerTick);
            
            //Initialize time
            time = new TimeSpan(0, 20, 0);
            second = new TimeSpan(0, 0, 1);
            createGame();
        }

        /* By Jinho
         * Timer test
         * */
        //Timer event handler
        void TimerTick(object sender, EventArgs e)
        {
            time = time - second;        
            TimerBtn.Content = time.Minutes + ":" + time.Seconds;            
        }

        private void LeftShotBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
		
		 private void LeftGoalBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/PlayerNumberView.xaml", UriKind.Relative));
        }
		
		private void LeftPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/PenaltyView.xaml", UriKind.Relative));
        }
		
        private void RightShotBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void RightGoalBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/PlayerNumberView.xaml", UriKind.Relative));
        }

        private void RIghtPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/PenaltyView.xaml", UriKind.Relative));
        }
		
		private void OthersBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/OtherSettingsView.xaml", UriKind.Relative));
        }

        /* By Jinho
         * Timer button event
         * */
        private void TimerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled == true)
            {
                timer.Stop();
                TimerBtn.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                timer.Start();
                TimerBtn.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        public void createGame()
        {
            currentGame = new Game(123, System.DateTime.Today, "Location", "Super League");
            currentGame.setHomeTeam(185, "MyHome Team", 12, "MyManager Name");
            currentGame.setAwayTeam(456, "YourAway Team", 390, "YourManager Name");

            currentGame.beginGame();
            PeriodTb.DataContext = currentGame;
            ScoreTb.DataContext = currentGame;

            currentGame.homeTeam.addGoal();
            HomeTeamTb.DataContext = currentGame.homeTeam;
            AwayTeamTb.DataContext = currentGame.awayTeam;
        }
    }
}