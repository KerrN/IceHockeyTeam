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
        bool betweenPeriods = false;

        public Game currentGame;

        // Constructor
        public GameView()
        {
            InitializeComponent();
            initialiseTimer();

            loadGame("ConfirmGameView");
            createGame();
        }

        private void initialiseTimer()
        {
            //Initialize timer
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(TimerTick);

            //Initialize time
            time = new TimeSpan(0, 20, 0);
            second = new TimeSpan(0, 0, 1);
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

            if ((time.Minutes + ":" + time.Seconds).ToString().Equals("0:0") )
            {
                betweenPeriods = true;
                timer.Stop();
                TimerBtn.Content = "Next Period";
                TimerBtn.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void LeftShotBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //the home team took a shot
            myGame.homeTeam.addShot();

            //the away team made a save
            myGame.awayTeam.addSave();
            makeToast("Shot recorded");
        }
		
        //NK Added for Toast
        public static void makeToast(string toastText)
            {
            //Make a new toast with content "text"
            ShellToast toast = new ShellToast();
            toast.Title = "Shot ";
            toast.Content = toastText;
            //toast.NavigationUri = new Uri();
            toast.Show();
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
            //the home team took a shot
            myGame.awayTeam.addShot();

            //the away team made a save
            myGame.homeTeam.addSave();
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
            saveGame();
			NavigationService.Navigate(new Uri("/Views/OtherSettingsView.xaml", UriKind.Relative));
        }

        /* By Jinho
         * Timer button event
         * */
        string temp = "20:00";
        private void TimerBtn_Click(object sender, RoutedEventArgs e)
        {
            //if the game is running
            if (timer.IsEnabled == true && !betweenPeriods)
            {
                timer.Stop();
                temp = TimerBtn.Content.ToString();
                TimerBtn.Content = "Paused";
                TimerBtn.Foreground = new SolidColorBrush(Colors.Red);
            }
            //if the game is paused
            else if (!betweenPeriods)
            {
                timer.Start();
                TimerBtn.Content = temp;
                TimerBtn.Foreground = new SolidColorBrush(Colors.Green);
            }
            //if we are between periods
            else if (!myGame.currentPeriod.Equals("Period 3"))
            {
                betweenPeriods = false;
                myGame.nextPeriod();
                initialiseTimer();
                timer.Start();
                TimerBtn.Foreground = new SolidColorBrush(Colors.Green);
            }
            //if the game has ended
            else
            {
                saveGame();
                MessageBox.Show("The game has now ended. You will be redirected to the post-game screen.", "Game Over", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/Views/PostGameView.xaml", UriKind.Relative));
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

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            myGame.CurrentScore = "";
        }
    }
}