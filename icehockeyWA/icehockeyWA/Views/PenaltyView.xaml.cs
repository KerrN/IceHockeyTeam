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
    public partial class PenaltyView : PhoneApplicationPage
    {
        public PenaltyView()
        {
            InitializeComponent();
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/GameView.xaml", UriKind.Relative));
        }

        private void AddHomePenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			// TODO: Add event handler implementation here.
			// Jinho... fixed by Josh
			// call method
			AddPenalty("Home");
        }

        private void AddAwayPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			// Jinho
			// call method
			AddPenalty("Away");
        }
		
		/** Created by Jinho **/        	
		private void AddPenalty(string arg){
			var lbi = new ListBoxItem();
			string contentStr = arg + " ";
			
			contentStr += PlayerLoopingSelector.DataSource.SelectedItem.ToString() + " ";
			contentStr += PenaltyLoopingSelector.DataSource.SelectedItem.ToString() + " ";
			contentStr += TimeLoopingSelector.DataSource.SelectedItem.ToString();
			
			lbi.Content = contentStr;
			lbi.FontSize = 30;
			lbi.IsEnabled = false;
			
			PenaltiesListBox.Items.Add(lbi);
		}
       	/***********************/
    }
}