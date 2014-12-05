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
using icehockeyWA.Models;

namespace icehockeyWA.Views
{
    public partial class AssistView : PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;
        Team team;
        string player = "";
        string assist = "";
        string assist2 = "";

        public AssistView()
        {
            InitializeComponent();
            loadGame();
            addButtons();
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

                    if (phoneAppService.State.ContainsKey("player"))
                    {
                        if (phoneAppService.State.TryGetValue("player", out temp))
                        {
                            player = temp.ToString();
                        }
                    }

                    if (phoneAppService.State.ContainsKey("assist"))
                    {
                        if (phoneAppService.State.TryGetValue("assist", out temp))
                        {
                            assist = temp.ToString();
                        }
                    }
                }
            }
        }

		//adds one button to the screen (in a grid) for each player (showing their player
		//number), and one for 'no assist'. The scoring player will not be added. R.P.
        private void addButtons()
        {
            int row = 0;
            int col = 1;
            int w = 0;
            int x = 0;
            int y = 0;
            int z = 0;

            for (int i = 0; i <= team.countPlayers(); i++)
            {
                    //for every third button, increase the row and reset the columns
                    if (i % 3 == 0)
                    {
                        row++;
                        col = 0;
                    }
                    col++;

                    //set some values based on the row
                    x = 110 * (row - 1);
                    z = 220 - (110 * (row - 1));

                    //set the other values based on column
                    if (col == 1)
                    {
                        w = -360;
                        y = 105;
                    }
                    else if (col == 2)
                    {
                        w = 231;
                        y = 239;
                    }
                    else if (col == 3)
                    {
                        w = 462;
                        y = 8;
                    }

                    Button myButton = new Button();

                    if (i == 0)
                    {
                        myButton.Content = "No Assist";
                    }
                    else
                    {
                        myButton.Content = team.getNumberForPlayer(i - 1);
                        if (myButton.Content.ToString().Equals(player) || myButton.Content.ToString().Equals(assist))
                        {
                            myButton.IsEnabled = false;
                        }
                    }

                    
                    myButton.Height = 105;
                    myButton.Width = 225;

                    Thickness myMargin = myButton.Margin;
                    myMargin.Left = w;
                    myMargin.Top = x;
                    myMargin.Right = y;
                    myMargin.Bottom = z;

                    myButton.Margin = myMargin;

                    ContentPanel.Children.Add(myButton);
                    myButton.Click += new RoutedEventHandler(this.playernumber_Click);


                }

        }

		//when a player is selected
		//checks whether this is the first or second assist, and whether a second assist
		//is necessary R.P.
        private void playernumber_Click(object sender, RoutedEventArgs e)
        {
            //if the assist2 has not yet been set

            if (assist.Equals("") && ((Button)e.OriginalSource).Content.ToString().Equals("No Assist"))
            {
                phoneAppService.State["sender"] = "goalScored";
                phoneAppService.State["assist"] = "";
                phoneAppService.State["assist2"] = "";
                assist2 = ((Button)e.OriginalSource).Content.ToString();
                createGoal();
                NavigationService.RemoveBackEntry();
                NavigationService.GoBack();
            }
            else if (assist.Equals(""))
            {
                phoneAppService.State["assist"] = ((Button)e.OriginalSource).Content.ToString();
                NavigationService.Navigate(new Uri("/Views/AssistView.xaml?ID=2", UriKind.Relative));
            }
            else
            {
                phoneAppService.State["sender"] = "goalScored";
                phoneAppService.State["assist"] = "";
                phoneAppService.State["assist2"] = "";
                assist2 = ((Button)e.OriginalSource).Content.ToString();
                createGoal();
                NavigationService.RemoveBackEntry();
                NavigationService.RemoveBackEntry();
                NavigationService.GoBack();
            }
        }
        
		//creates a goal object for the game, and adds the required details. R.P.
        private void createGoal()
        {

            if (assist.Equals("No Assist") || assist.Equals(""))
            {
                assist = "-1";
            }

            if (assist2.Equals("No Assist") || assist2.Equals(""))
            {
                assist2 = "-1";
            }

            myGame.addEvent(new Goal(
                team.getTeamID(),
                myGame.currentPeriod,
                int.Parse(player),
                int.Parse(assist),
                int.Parse(assist2),
                false));

            team.addGoal(int.Parse(player),
                int.Parse(assist),
                int.Parse(assist2));

            //if the current team is the home team, increment the counter against the awayTeam goalie
            if (myGame.homeTeam.Equals(team))
            {
                myGame.awayTeam.incrementGoalieCounter();
            }
            else
            {
                //otherwise, we assume this team is the awayTeam, and increment for the homeTeam
                myGame.homeTeam.incrementGoalieCounter();
            }
        }


        /* By Jinho
         * Navigation service update
         * */
        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            NavigationService.GoBack();			
        }

    }
}