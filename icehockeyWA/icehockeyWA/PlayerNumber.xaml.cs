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
    public partial class PlayerNumber : PhoneApplicationPage
    {
        public PlayerNumber()
        {
            InitializeComponent();
        }

        /* By Jinho
         * Navigation service update
         * */
        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.            
            if (NavigationService.CanGoForward == true)
            {                
                NavigationService.RemoveBackEntry();
                
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.GoBack();
            }			
        }

        private void NextBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Assist.xaml", UriKind.Relative));
        }
    }
}