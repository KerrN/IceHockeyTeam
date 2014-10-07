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

namespace DataBinding
{
    public partial class MainPage : PhoneApplicationPage
    {

        private Person _currentPerson;
        private Random randomPosition = new Random();
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
           
        }
        void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            _currentPerson = new Person
            {
                Beard = false,
                Favorite = true,
                Goatee = false,
                Height = 1.86,
                Moustache = true,
                Name = "Jesse",
                WhichSex = Person.Sex.Male
            };
            ContentPanel.DataContext = _currentPerson;
        }


    }
}