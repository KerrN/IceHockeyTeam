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
    public partial class OtherSettings : PhoneApplicationPage
    {
        public OtherSettings()
        {
            InitializeComponent();
        }

        private void NotesBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Notes.xaml", UriKind.Relative));
        }

        private void LogBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Log.xaml", UriKind.Relative));
        }

        private void CancelGameBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			/* By Jinho
			* Cancel game button event
			* */
			MessageBoxResult mbr = MessageBox.Show("Are you sure?", "Cancel Game", MessageBoxButton.OKCancel);
			
			if (mbr == MessageBoxResult.OK) 
			{
				while(NavigationService.CanGoBack == true)
				{
					NavigationService.RemoveBackEntry();
				}
				NavigationService.Navigate(new Uri("/Entrance.xaml", UriKind.Relative));
			}			
        }
        
    }
}