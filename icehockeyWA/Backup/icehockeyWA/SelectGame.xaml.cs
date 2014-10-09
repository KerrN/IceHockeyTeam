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
    public partial class SelectGame : PhoneApplicationPage
    {
        public SelectGame()
        {
            InitializeComponent();
            listBox1.Items.Add("Junior A");
            listBox1.Items.Add("Junior B");
            listBox1.Items.Add("Senior A");
            listBox1.Items.Add("Senior B");


            int counter = 1;
            while (counter < 32)
            {
                listBoxdd.Items.Add(counter);
                counter++;
            }

            counter = 1;
            while (counter < 13)
            {
                listBoxmm.Items.Add(counter);
                counter++;
            }

            int current_year = int.Parse(DateTime.Now.ToString("yyyy"));
            counter = 1;
            while (counter < 3)
            {
                listBoxyy.Items.Add(current_year);
                counter++;
                current_year++;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
        }
    }
}