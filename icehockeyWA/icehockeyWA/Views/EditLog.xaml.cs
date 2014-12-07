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

// JL unfinished

namespace icehockeyWA.Views
{
    public partial class EditLog : PhoneApplicationPage
    {
        public EditLog()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //get selected details
            //populate time dropdown // actual is selected
            //populate type dropdown // actual is selected

        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            // write back to relevant event.. or change type/time or delete
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}