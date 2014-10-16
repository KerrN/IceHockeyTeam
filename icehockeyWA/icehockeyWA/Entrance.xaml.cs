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

namespace icehockeyWA
{
    public partial class Entrance : PhoneApplicationPage
    {
        // Constructor
        public Entrance()
        {
            InitializeComponent();
        }

        private void SetupGameBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/SelectGame.xaml", UriKind.Relative));
        }

        private void ReviewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            NavigationService.Navigate(new Uri("/ReviewGame.xaml", UriKind.Relative));
        }
    }
}