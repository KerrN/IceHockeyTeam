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
    public partial class PlayerNumberView : PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;
        Team team;

        public PlayerNumberView()
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
                }
            }
        }
        //TK Fix gap between buttons, you can now see all buttons and buttons are srcollable
        // TODO: align buttons, buttons do not align.
        private void addButtons()
        {
            List<Button> btnList = new List<Button>();
            int row = 0;
            int col = 1;
            int w = 0;
            int x = 0;
            int y = 0;
            int z = 0;

            for (int i=0; i < team.countPlayers(); i++)
            {
                //for every third button, increase the row and reset the columns
                if (i % 3 == 0)
                {
                    row++;
                    col = 0;
                    foreach (var item in btnList)
                    {
                        myScrollStackPanel.Children.Add(item);
                    }
                    btnList.Clear(); 
                }
                col++;

                //set some values based on the row
               x = 0 + (row - 1);
               z = -60 - (row - 1); 

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
                myButton.Content = team.getNumberForPlayer(i);
               // MessageBox.Show(team.getNumberForPlayer(i).ToString());
                myButton.Height = 90;
                myButton.Width = 200;

                Thickness myMargin = myButton.Margin;
                myMargin.Left = w; 
                myMargin.Top = x;
                myMargin.Right = y;
                myMargin.Bottom = z;
                  
                myButton.Margin = myMargin;
                btnList.Add(myButton);
                //ContentPanel.Children.Add(myButton);
                //myScrollStackPanel.Children.Add(myButton);
                //myScrollGrid.Children.Add(myButton);
                myButton.Click += new RoutedEventHandler(this.playernumber_Click);


            }

                       
        }

        /* By Jinho
         * Navigation service update
         * */
        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Views/GameView.xaml", UriKind.Relative));

            /*
            // TODO: Add event handler implementation here.            
            if (NavigationService.CanGoForward == true)
            {                
                NavigationService.RemoveBackEntry();
                
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.GoBack();
            }		*/	
        }

        private void playernumber_Click(object sender, RoutedEventArgs e)
        {
             phoneAppService.State["player"] = ((Button)e.OriginalSource).Content.ToString();
             NavigationService.Navigate(new Uri("/Views/AssistView.xaml", UriKind.Relative));
        }


        private void NextBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			NavigationService.Navigate(new Uri("/Views/AssistView.xaml", UriKind.Relative));
        }
    }
}