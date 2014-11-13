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
    public partial class ConfirmGameView: PhoneApplicationPage
    {
        public ConfirmGameView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_sig1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Signature.xaml", UriKind.Relative));
        }

        private void btn_sig2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Signature.xaml", UriKind.Relative));
        }
    }
}