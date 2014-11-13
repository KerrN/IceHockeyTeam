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
using System.Windows.Threading;
using icehockeyWA.Models;
using Microsoft.Phone.Shell;

namespace icehockeyWA.Views
{
    public partial class GameView : PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;

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

            loadGame("ConfirmGameView");
            createGame();
        }

        private void loadGame(string s) {
            object temp;

            //check which screen the previous one was
            if (phoneAppService.State.ContainsKey("sender"))
            {
                if (phoneAppService.State.TryGetValue("sender", out temp))
                {

                    //if it was the correct screen, read in the game
                    if (temp.ToString().Equals(s))
                    {
                        if (phoneAppService.State.ContainsKey("myGame"))
                        {
                            if (phoneAppService.State.TryGetValue("myGame", out temp))
                            {
                                myGame = (Game)temp;
                            }
                        }
                    }
                }
            }
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
            myGame.homeTeam.addShot();
        }
		
		 private void LeftGoalBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            saveGame();
            phoneAppService.State["sender"] = "home";
			NavigationService.Navigate(new Uri("/Views/PlayerNumberView.xaml", UriKind.Relative));
        }
		
		private void LeftPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            saveGame();
            phoneAppService.State["sender"] = "home";
			NavigationService.Navigate(new Uri("/Views/PenaltyView.xaml", UriKind.Relative));
        }
		
        private void RightShotBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            myGame.awayTeam.addShot();
        }

        private void RightGoalBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            saveGame();
            phoneAppService.State["sender"] = "away";
			NavigationService.Navigate(new Uri("/Views/PlayerNumberView.xaml", UriKind.Relative));
        }

        private void RIghtPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            saveGame();
            phoneAppService.State["sender"] = "away"; 
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

        private void saveGame()
        {
            phoneAppService.State["myGame"] = myGame;
        }

        public void createGame()
        {
            myGame.beginGame();
            PeriodTb.DataContext = myGame;
            ScoreTb.DataContext = myGame;
            HomeTeamTb.DataContext = myGame.homeTeam;
            AwayTeamTb.DataContext = myGame.awayTeam;
        }
    }
}