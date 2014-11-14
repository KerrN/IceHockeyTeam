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
using icehockeyWA.Models;
using Microsoft.Phone.Shell;
using icehockeyWA.IceIceBaby;

namespace icehockeyWA.Views
{
    public partial class PenaltyView : PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;
        Team team;
        bool allowChange = false;

        public PenaltyView()
        {
            InitializeComponent();
            loadGame();

            for (int i = 0; i < team.players.Count; i++)
            {
                listBox1.Items.Add(team.players[i].number.ToString());
            }

            listBox1.SelectedIndex = 0;

            listBox2.Items.Add("Loading...");
            listBox4.Items.Add("Loading...");
            loadPenaltyTypes();

        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            //if there is an item selected in each listbox
            if (listBox1.SelectedItems.Count.Equals(1) && listBox2.SelectedItems.Count.Equals(1) && listBox3.SelectedItems.Count.Equals(1) && listBox4.SelectedItems.Count.Equals(1))
            {
                phoneAppService.State["sender"] = "penaltyAdded";
                createPenalty();
                NavigationService.GoBack();
            }
        }

        private void createPenalty()
        {
            myGame.addEvent(new Models.Penalty(
                team.getTeamID(),
                myGame.CurrentPeriod,
                int.Parse(listBox1.SelectedItem.ToString()),
                int.Parse(listBox4.SelectedItem.ToString()),
                listBox3.SelectedItem.ToString(),
                false));

            team.addPenalty();
        }

        public void loadGame()
        {
            object temp;
            string myTeam = "";

            //check which screen the previous one was
            if (phoneAppService.State.ContainsKey("sender"))
            {
                if (phoneAppService.State.TryGetValue("sender", out temp))
                {

                    myTeam = temp.ToString();
                    if (phoneAppService.State.ContainsKey("myGame"))
                    {
                        if (phoneAppService.State.TryGetValue("myGame", out temp))
                        {
                            myGame = (Game)temp;

                            if (myTeam.Equals("home"))
                            {
                                team = myGame.homeTeam;
                            }
                            else
                            {
                                team = myGame.awayTeam;
                            }
                        }
                    }
                }
            }
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (allowChange)
            {
                loadPenaltyOptions();
                listBox4.SelectedIndex = listBox2.SelectedIndex;
            }
        }

        private void loadPenaltyTypes()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.getPenaltyTypesCompleted += new EventHandler<getPenaltyTypesCompletedEventArgs>(iceService_getPenaltyTypesCompleted);

            //call the service
            iceService.getPenaltyTypesAsync();
        }

        private void iceService_getPenaltyTypesCompleted(object sender, getPenaltyTypesCompletedEventArgs e)
        {
            //remove the loading item
            listBox2.Items.Clear();
            listBox4.Items.Clear();

            //set the source of the listbox to the returned list
            listBox2.ItemsSource = e.Result.Keys;
            listBox4.ItemsSource = e.Result.Values;

            //select the first item
            allowChange = true;
            listBox2.SelectedIndex = 0;
            
        }

        private void loadPenaltyOptions()
        {
            //remove the loading item
            listBox3.ItemsSource = null;

            listBox3.Items.Add("Loading...");

            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.getPenaltyOptionsCompleted += new EventHandler<getPenaltyOptionsCompletedEventArgs>(iceService_getPenaltyOptionsCompleted);

            //call the service
            iceService.getPenaltyOptionsAsync(listBox2.SelectedItem.ToString());
        }

        private void iceService_getPenaltyOptionsCompleted(object sender, getPenaltyOptionsCompletedEventArgs e)
        {
            //remove the loading item
            listBox3.Items.Clear();

            //set the source of the listbox to the returned list
            listBox3.ItemsSource = e.Result;

            //select the first item
            listBox3.SelectedIndex = 0;
        }

        private void listBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ensure the time is updated when the offence is changed
            listBox4.SelectedIndex = listBox2.SelectedIndex;
        }

        private void AddHomePenaltyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

       /* private void AddHomePenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			// TODO: Add event handler implementation here.
			// Jinho
			// call method
			AddPanalty("Home");
        }

        private void AddAwayPenaltyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			// Jinho
			// call method
			AddPanalty("Away");
        }
		
		// Created by Jinho      	
		private void AddPanalty(string arg){
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
        */
       	/***********************/
    }
}