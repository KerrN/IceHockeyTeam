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

namespace icehockeyWA.Views
{
    public partial class OtherSettingsView : PhoneApplicationPage
    {
        public OtherSettingsView()
        {
            InitializeComponent();
        }

        private void NotesBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/NotesView.xaml", UriKind.Relative));
        }

        private void LogBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/LogView.xaml", UriKind.Relative));
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
				NavigationService.Navigate(new Uri("/Views/EntranceView.xaml", UriKind.Relative));
			}			
        }

        private void changeGoalieBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            NavigationService.Navigate(new Uri("/Views/ChangeGoalieView.xaml", UriKind.Relative));
        }

        //NK ADDED
        private void button1_Click(object sender, RoutedEventArgs e)
            {
                NavigationService.GoBack();
            }
        
    }
}