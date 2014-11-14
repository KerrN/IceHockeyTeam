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
    public partial class NotesView : PhoneApplicationPage
    {
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
        Game myGame;
        
        public NotesView()
        {
            InitializeComponent();

            loadGame();
            textBox2.Text = myGame.notes;
        }

        private void Add_but_Click(object sender, RoutedEventArgs e)
        {
            myGame.notes += "\n" + textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = myGame.notes;
        }

        public void loadGame()
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            NavigationService.GoBack();
        }
    }
}