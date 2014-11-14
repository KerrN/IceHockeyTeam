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
using icehockeyWA.Models;

namespace icehockeyWA.Views
{

    public partial class ConfirmPlayersView : PhoneApplicationPage
    {
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        string myDivision;
        TempGame myTempGame;
        TempGameDetails gameDetails;
        List<TempPlayer> homePlayerList = new List<TempPlayer>();
        List<TempPlayer> awayPlayerList = new List<TempPlayer>();
        Game myGame;

        public ConfirmPlayersView()
        {
            InitializeComponent();
            object temp;

            //determine the previous screen
            if (phoneAppService.State.ContainsKey("sender"))
            {
                if (phoneAppService.State.TryGetValue("sender", out temp))
                {
                    if (temp.ToString().Equals("SelectGameView"))
                    {
                        loadGames();
                    }
                    else if (temp.ToString().Equals("home"))
                    {
                        loadAllDetails();

                        //read in the game from the previous screen
                        if (phoneAppService.State.ContainsKey("selectedTeam"))
                        {
                            if (phoneAppService.State.TryGetValue("selectedTeam", out temp))
                            {
                                homePlayerList = (List<TempPlayer>) temp;
                            }
                        }

                        updatePlayerLists();
                    }
                    else if (temp.ToString().Equals("away"))
                    {
                        loadAllDetails();

                        //read in the game from the previous screen
                        if (phoneAppService.State.ContainsKey("selectedTeam"))
                        {
                            if (phoneAppService.State.TryGetValue("selectedTeam", out temp))
                            {
                                awayPlayerList = (List<TempPlayer>)temp;
                            }
                        }

                        updatePlayerLists();
                    }
                }
            }

        }

        //check that the teams are valid
        private void savePlayers()
        {
            if (listBox2.SelectedItems.Count != 1 || listBox3.SelectedItems.Count != 1)
            {
                MessageBox.Show("You have not selected a goalie for each team!", "Invalid Goalie", MessageBoxButton.OK);
            }
            else if (listBox2.Items.Count < 5 || listBox3.Items.Count < 5)
            {
                MessageBox.Show("You do not have enough players for each team!", "Insufficient Players", MessageBoxButton.OK);
            }
            else
            {
                createPlayers();
            }
        }

        //this will create the player objects
        private void createPlayers()
        {
            //add each tempplayer to the player
            for (int i = 0; i < homePlayerList.Count(); i++)
            {
                //if the player is a goalie, create the goalie object
                if (listBox2.SelectedValue.ToString().Equals(homePlayerList[i]._playerName))
                {
                    myGame.homeTeam.addGoalie(homePlayerList[i]._playerID, homePlayerList[i]._playerName, homePlayerList[i]._playerNumber);
                }
                else
                {
                    myGame.homeTeam.addPlayer(homePlayerList[i]._playerID, homePlayerList[i]._playerName, homePlayerList[i]._playerNumber);
                }
            }

            for (int i = 0; i < awayPlayerList.Count(); i++)
            {
                //if the player is a goalie, create the goalie object
                if (listBox3.SelectedValue.ToString().Equals(awayPlayerList[i]._playerName))
                {
                    myGame.awayTeam.addGoalie(awayPlayerList[i]._playerID, awayPlayerList[i]._playerName, awayPlayerList[i]._playerNumber);
                }
                else
                {
                    myGame.awayTeam.addPlayer(awayPlayerList[i]._playerID, awayPlayerList[i]._playerName, awayPlayerList[i]._playerNumber);
                }
            }

            saveAllDetails();
            phoneAppService.State["sender"] = "ConfirmPlayersView";
            NavigationService.Navigate(new Uri("/Views/ConfirmGameView.xaml", UriKind.Relative));

        }

        private void updatePlayerLists()
        {
            listBox2.Items.Clear();

            //add each result to the playerList
            for (int i = 0; i < homePlayerList.Count(); i++)
            {
                listBox2.Items.Add(homePlayerList[i]._playerName);
            }

            listBox3.Items.Clear();

            //add each result to the playerList
            for (int i = 0; i < awayPlayerList.Count(); i++)
            {
                listBox3.Items.Add(awayPlayerList[i]._playerName);
            }
        }

        private void loadGames()
        {
            object temp;
            //read in the game from the previous screen
            if (phoneAppService.State.ContainsKey("selectedGame"))
            {
                if (phoneAppService.State.TryGetValue("selectedGame", out temp))
                {
                    myTempGame = (TempGame)temp;
                }
            }

            //read in the division from the previous screen
            if (phoneAppService.State.ContainsKey("selectedDivision"))
            {
                if (phoneAppService.State.TryGetValue("selectedDivision", out temp))
                {
                    myDivision = temp.ToString();
                }
            }

            myGame = new Game(myTempGame._gameID, myTempGame._time, myTempGame._venue, myDivision);
            getGameDetails();
        }

        private void saveAllDetails()
        {    
            //save all details to the service state, to access later
            phoneAppService.State["selectedDivision"] = myDivision;
            phoneAppService.State["tempGame"] = myTempGame;
            phoneAppService.State["gameDetails"] = gameDetails;
            phoneAppService.State["homeList"] = homePlayerList;
            phoneAppService.State["awayList"] = awayPlayerList;
            phoneAppService.State["myGame"] = myGame;
        }

        private void loadAllDetails()
        {
            object temp;
            //read in the game from the previous screen
            if (phoneAppService.State.ContainsKey("selectedDivision"))
            {
                if (phoneAppService.State.TryGetValue("selectedDivision", out temp))
                {
                    myDivision = temp.ToString();
                }
            }

            if (phoneAppService.State.ContainsKey("tempGame"))
            {
                if (phoneAppService.State.TryGetValue("tempGame", out temp))
                {
                    myTempGame = (TempGame)temp;
                }
            }

            if (phoneAppService.State.ContainsKey("gameDetails"))
            {
                if (phoneAppService.State.TryGetValue("gameDetails", out temp))
                {
                    gameDetails = (TempGameDetails)temp;
                }
            }

            if (phoneAppService.State.ContainsKey("homeList"))
            {
                if (phoneAppService.State.TryGetValue("homeList", out temp))
                {
                    homePlayerList = (List<TempPlayer>)temp;
                }
            }

            if (phoneAppService.State.ContainsKey("awayList"))
            {
                if (phoneAppService.State.TryGetValue("awayList", out temp))
                {
                    awayPlayerList = (List<TempPlayer>)temp;
                }
            }

            if (phoneAppService.State.ContainsKey("myGame"))
            {
                if (phoneAppService.State.TryGetValue("myGame", out temp))
                {
                    myGame = (Game)temp;
                }
            }

            textBox1.DataContext = myGame.homeTeam;
            textBox2.DataContext = myGame.awayTeam;
        }

        private void getGameDetails()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.returnGameDetailsCompleted += new EventHandler<returnGameDetailsCompletedEventArgs>(iceService_returnGameDetailsCompleted);

            //call the service
            iceService.returnGameDetailsAsync(myGame.gameID);
        }

        private void iceService_returnGameDetailsCompleted(object sender, returnGameDetailsCompletedEventArgs e)
        {
            //set the gameDetails to the result
            gameDetails = e.Result;
            createTeams();
            returnHomePlayers();
            returnAwayPlayers();
        }

        private void createTeams()
        {
            myGame.setHomeTeam(gameDetails._homeTeamID, myTempGame._homeTeam, gameDetails._homeManagerID, gameDetails._homeManagerName);
            myGame.setAwayTeam(gameDetails._awayTeamID, myTempGame._awayTeam, gameDetails._awayManagerID, gameDetails._awayManagerName);

            myGame.addOfficial(gameDetails._linesman1, "Linesman");
            myGame.addOfficial(gameDetails._linesman2, "Linesman");
            myGame.addOfficial(gameDetails._ringading, "Referee");

            textBox1.DataContext = myGame.homeTeam;
            textBox2.DataContext = myGame.awayTeam;
        }

        private void returnHomePlayers()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.returnPlayersCompleted += new EventHandler<returnPlayersCompletedEventArgs>(iceService_returnHomePlayersCompleted);

            //call the service
            iceService.returnPlayersAsync(gameDetails._homeTeamID);
        }

        private void returnAwayPlayers()
        {
            //sets up the service
            IceWAServiceClient iceService = new IceWAServiceClient();
            // sets up the event handler so we can do something with the result
            iceService.returnPlayersCompleted += new EventHandler<returnPlayersCompletedEventArgs>(iceService_returnAwayPlayersCompleted);

            //call the service
            iceService.returnPlayersAsync(gameDetails._awayTeamID);
        }

        private void iceService_returnHomePlayersCompleted(object sender, returnPlayersCompletedEventArgs e)
        {
            //add each result to the playerList
            for (int i = 0; i < e.Result.Count(); i++)
            {
                homePlayerList.Add(e.Result[i]);
                listBox2.Items.Add(homePlayerList[i]._playerName);
            }
        }

        private void iceService_returnAwayPlayersCompleted(object sender, returnPlayersCompletedEventArgs e)
        {
            //add each result to the playerList
            for (int i = 0; i < e.Result.Count(); i++)
            {
                awayPlayerList.Add(e.Result[i]);
                listBox3.Items.Add(awayPlayerList[i]._playerName);
            }
        }

        private void btnEditA_Click(object sender, RoutedEventArgs e)
        {
            saveAllDetails();
            phoneAppService.State["selectedTeam"] = homePlayerList;
            phoneAppService.State["sender"] = "home";
            NavigationService.Navigate(new Uri("/Views/EditTeamView.xaml", UriKind.Relative));
        }

        private void btnEditB_Click(object sender, RoutedEventArgs e)
        {
            saveAllDetails();
            phoneAppService.State["selectedTeam"] = awayPlayerList;
            phoneAppService.State["sender"] = "away";
            NavigationService.Navigate(new Uri("/Views/EditTeamView.xaml", UriKind.Relative));
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            savePlayers();
        }
    }
}