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
using icehockeyWA.IceIceBaby;
using System.Globalization;
using System.Threading;
using Microsoft.Phone.Shell;

namespace icehockeyWA.Views
{
    public partial class SelectGameView : PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        private bool isLoaded = false;
        List<TempGame> gameList = new List<TempGame>();

        public SelectGameView()
        {
            InitializeComponent();
            listBox1.Items.Add("Loading...");
            listBox2.Items.Add("Loading...");

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

            //set the date to the current date
            listBoxdd.SelectedIndex = DateTime.Today.Day - 1;
            listBoxmm.SelectedIndex = DateTime.Today.Month - 1;
            listBoxyy.SelectedItem = DateTime.Today.Year;

            getDivisions();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (listBox2.SelectedItems.Count == 1)
            {
                phoneAppService.State["selectedGame"] = gameList[listBox2.SelectedIndex];
                phoneAppService.State["selectedDivision"] = gameList[listBox1.SelectedIndex];
                phoneAppService.State["sender"] = "SelectGameView";
                NavigationService.Navigate(new Uri("/Views/ConfirmPlayersView.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("You must select a game to load.", "Select Game", MessageBoxButton.OK);
            }
        }

        private void getDivisions()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.getDivisionsCompleted += new EventHandler<getDivisionsCompletedEventArgs>(iceService_getDivisionsCompleted);

            //call the service
            iceService.getDivisionsAsync();
        }

        private void iceService_getDivisionsCompleted(object sender, getDivisionsCompletedEventArgs e)
        {
            //remove the loading item
            listBox1.Items.RemoveAt(0);

            //set the source of the listbox to the returned list
            listBox1.ItemsSource = e.Result;

            //select the first item
            listBox1.SelectedIndex = 0;

            //load the games
            isLoaded = true;
            getGames();
        }

        private void getGames()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.returnScheduleCompleted += new EventHandler<returnScheduleCompletedEventArgs>(iceService_returnScheduleCompletedCompleted);

            //setup the parmeters from the listboxes
            DateTime myDate = Convert.ToDateTime(listBoxyy.SelectedValue.ToString() + "-" + listBoxmm.SelectedValue.ToString() + "-" + listBoxdd.SelectedValue.ToString());
            string myDivision = listBox1.SelectedValue.ToString();

            //call the service
            iceService.returnScheduleAsync(myDate, myDivision);
        }

        private void iceService_returnScheduleCompletedCompleted(object sender, returnScheduleCompletedEventArgs e)
        {
            //empty the listbox
            for (int i = 0; i < listBox2.Items.Count(); i++)
            {
                listBox2.Items.RemoveAt(i);
            }

            //add each result to the gameList
            for (int i = 0; i < e.Result.Count(); i++)
            {
                gameList.Add(e.Result[i]);
            }

            //add the results to the listbox
            for (int index = 0; index < e.Result.Count(); index++)
            {
                listBox2.Items.Add(gameList[index]._s);
            }

            //if there is a result, select the first result
            if (listBox2.Items.Count() > 0)
            {
                listBox2.SelectedIndex = 0;
            }
            else
            {
                listBox2.Items.Add("There are no results...");
            }
        }

        private void listBoxdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                getGames();
            }
        }

        private void listBoxmm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                getGames();
            }
        }

        private void listBoxyy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                getGames();
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                getGames();
            }
        }
    }
}