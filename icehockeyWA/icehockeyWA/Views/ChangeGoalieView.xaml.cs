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
    public partial class ChangeGoalieView : PhoneApplicationPage
    {
        public ChangeGoalieView()
        {
            InitializeComponent();
            this.lstBoxGoalies.Items.Add("1");
            this.lstBoxGoalies.Items.Add("2");
            this.lstBoxGoalies.Items.Add("3");
            this.lstBoxGoalies.Items.Add("4");
            this.lstBoxGoalies.Items.Add("5");
            this.lstBoxGoalies.Items.Add("6");
            this.lstBoxGoalies.Items.Add("7");
            this.lstBoxGoalies.Items.Add("8");
            this.lstBoxGoalies.Items.Add("9");
            this.lstBoxGoalies.Items.Add("10");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/GameView.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}