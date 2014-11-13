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
            this.listBox1.Items.Add("1");
            this.listBox1.Items.Add("2");
            this.listBox1.Items.Add("3");
            this.listBox1.Items.Add("4");
            this.listBox1.Items.Add("5");
            this.listBox1.Items.Add("6");
            this.listBox1.Items.Add("7");
            this.listBox1.Items.Add("8");
            this.listBox1.Items.Add("9");
            this.listBox1.Items.Add("10");
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