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

namespace icehockeyWA
{
    public partial class Game : PhoneApplicationPage
    {
        static DispatcherTimer timer;
        // Constructor
        public Game()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            //timer.Tick += new EventHandler(timer_Tick);

            timer.Start();            
        }

        

        private void LeftShotBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
		
		 private void LeftGoalBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/PlayerNumber.xaml", UriKind.Relative));
        }
		
		private void LeftPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Penalty.xaml", UriKind.Relative));
        }
		
        private void RightShotBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void RightGoalBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/PlayerNumber.xaml", UriKind.Relative));
        }

        private void RIghtPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Penalty.xaml", UriKind.Relative));
        }
		
		private void OthersBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/OtherSettings.xaml", UriKind.Relative));
        }
    }
}