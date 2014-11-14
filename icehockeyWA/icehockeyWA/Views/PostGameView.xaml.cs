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
    public partial class PostGameView : PhoneApplicationPage
    {

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;

        public PostGameView()
        {
            InitializeComponent();
            loadGame();

            for (int i = 0; i < myGame.events.Count; i++)
            {
                listBox1.Items.Add(myGame.events[i].ToString());
            }
        }

        private void loadGame()
        {
            object temp;

            if (phoneAppService.State.ContainsKey("myGame"))
            {
                if (phoneAppService.State.TryGetValue("myGame", out temp))
                {
                    myGame = (Game)temp;
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        //continue button
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have successfully completed the game. At this point, your game WOULD upload to the DataBase, if anyone had programmed it to...", "Success!", MessageBoxButton.OK);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}