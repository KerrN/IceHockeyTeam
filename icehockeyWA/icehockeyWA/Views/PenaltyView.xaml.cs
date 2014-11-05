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
using icehockeyWA.ViewModels;

namespace icehockeyWA.Views
{
    public partial class PenaltyView : PhoneApplicationPage
    {
        public PenaltyView()
        {
            InitializeComponent();
            DataContext = new PenaltyViewModel();
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/GameView.xaml", UriKind.Relative));
        }
    }
}