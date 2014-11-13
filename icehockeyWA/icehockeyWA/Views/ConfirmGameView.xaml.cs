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

namespace icehockeyWA.Views
{
    public partial class ConfirmGameView: PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;


        public ConfirmGameView()
        {
            InitializeComponent();


            object temp;

            //check which screen the previous one was
            if (phoneAppService.State.ContainsKey("sender"))
            {
                if (phoneAppService.State.TryGetValue("sender", out temp))
                {

                    //if it was the correct screen, read in the game
                    if(temp.ToString().Equals("ConfirmPlayersView"))
                    {
                        if (phoneAppService.State.ContainsKey("myGame"))
                        {
                            if (phoneAppService.State.TryGetValue("myGame", out temp))
                            {
                                myGame = (Game)temp;
                                setDataContext();
                            }
                        }
                    }
                }
            }
        }

        private void setDataContext()
        {
            textBox1.DataContext = myGame.homeTeam;
            textBox2.DataContext = myGame.awayTeam;

            textBox3.DataContext = myGame.getOfficialsByType("Referee")[0];
            textBox4.DataContext = myGame.getOfficialsByType("Linesman")[0];
            textBox5.DataContext = myGame.getOfficialsByType("Linesman")[1];
            textBox6.DataContext = myGame;

            /*textBox3.Text = myGame.getOfficialsByType("Referee")[0].name;
            textBox4.Text = myGame.getOfficialsByType("Linesman")[0].name;
            textBox5.Text = myGame.getOfficialsByType("Linesman")[1].name;
            //textBox6.Text = myGame.venue;*/
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            phoneAppService.State["sender"] = "ConfirmGameView";
            phoneAppService.State["myGame"] = myGame;
            NavigationService.Navigate(new Uri("/Views/GameView.xaml", UriKind.Relative));
        }
    }
}