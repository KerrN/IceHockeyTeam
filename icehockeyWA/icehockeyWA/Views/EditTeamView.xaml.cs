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
using Microsoft.Phone.Shell;
using icehockeyWA.IceIceBaby;

namespace icehockeyWA.Views
{
    public partial class EditTeamView : PhoneApplicationPage
    {
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        List<TempPlayer> playerList = new List<TempPlayer>();
        List<TempPlayer> foundList = new List<TempPlayer>();

        // Constructor
        public EditTeamView ()
        {
            InitializeComponent();

            object temp;

            //read in the game from the previous screen
            if (phoneAppService.State.ContainsKey("selectedTeam"))
            {
                if (phoneAppService.State.TryGetValue("selectedTeam", out temp))
                {
                    playerList = (List<TempPlayer>)temp;
                }
            }

            updatePlayerList();
        }

		//function to update the list box to display the current players on the team R.P.
        public void updatePlayerList()
        {
            //empty the listbox
            listBox1.Items.Clear();
            
            //add each player in the list
            for (int i = 0; i < playerList.Count(); i++)
            {
                listBox1.Items.Add(playerList[i]._playerName);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                for (int i = 0; i < playerList.Count(); i++)
                {
                    if (playerList[i]._playerName == listBox1.SelectedValue.ToString())
                    {
                        playerList.RemoveAt(i);
                    }
                }
                updatePlayerList();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchPlayers();
        }

		//Connect to the service to retrieve players matching the search criteria R.P.
        private void searchPlayers()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.searchPlayersCompleted += new EventHandler<searchPlayersCompletedEventArgs>(iceService_searchPlayersCompleted);

            //call the service
            iceService.searchPlayersAsync(textBox1.Text);
            //clear all items
            listBox3.Items.Clear();
        } 

		//function called on return of search results R.P.
        private void iceService_searchPlayersCompleted(object sender, searchPlayersCompletedEventArgs e)
        {

            //add each result to the playerList
            for (int i = 0; i < e.Result.Count(); i++)
            {
                foundList.Add(e.Result[i]);
                listBox3.Items.Add(foundList[i]._playerName);
            }
        }
        
        //if the user attempts to add a player
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool playerAlreadyAdded = false;
            
            //check there is a player selected
            if (listBox3.SelectedItems.Count == 1)
            {
                //search the list for that player
                for (int i = 0; i < foundList.Count(); i++)
                {
                    //when you find that player
                    if (foundList[i]._playerName == listBox3.SelectedValue.ToString())
                    {
                        for (int j = 0; j < listBox1.Items.Count; j++)
                        {
                            if (listBox1.Items[j].ToString().Equals(foundList[i]._playerName))
                            {
                                playerAlreadyAdded = true;
                                MessageBox.Show("That player has already been added to this team");
                            }
                        }

                        if (!playerAlreadyAdded)
                        {
                            //add it to the playerList
                            playerList.Add(foundList[i]);
                        }
                    }
                }
                updatePlayerList();
            }
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            //CHECK THAT EVERYTHING IS VALID FIRST

            phoneAppService.State["selectedTeam"] = playerList;
            //the sender should remain the same from when this page was called

            NavigationService.Navigate(new Uri("/Views/ConfirmPlayersView.xaml", UriKind.Relative));
        }

    }
}