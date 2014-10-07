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
using System.ComponentModel;

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

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
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
            SetDataContext();
            Next.Click += Next_Click;
            
        }

    
        private void SetDataContext()
        {
            ContentPanel.DataContext = GeneratePerson();
            _currentPerson = (Person)ContentPanel.DataContext;

        }

        private Person GeneratePerson()
        {
            var newPerson = new Person
            {
                Beard = FlipCoin(),
                Favorite = FlipCoin(),
                Goatee = FlipCoin(),
                Height = randomPosition.NextDouble() + 1,
                Moustache = FlipCoin(),
                Name = names[randomPosition.Next(0, names.Count - 1)],
                BirthDate = DateTime.Now - TimeSpan.FromDays(randomPosition.Next(1, 365 * 20)),
            };
            return newPerson;
        }

        private bool FlipCoin()
        {
            return randomPosition.Next(1, 3) % 2 == 0;
        }

        private readonly List<string> names = new List<string>()
        {
            "Ally Katz",
            "Barb Dwyer",
            "Claire Voyant",
            "Lotta Noyes",
            "Polly Graf",
            "Bud Light",
            "Clay Potts",
            "Dusty Broome",
        };



        private void Next_Click(object sender, RoutedEventArgs e)
        {
            SetDataContext();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            _currentPerson.Name = "NICHOLA";
        }

        private void Favorite_Checked(object sender, RoutedEventArgs e)
        {
 
        }

        public object Convert(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }



    }

    
}
