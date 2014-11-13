using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace icehockeyWA.Models
{
    public class Goalie : Player
    {

        public int shots;
        public int saves;

        public Goalie(int id, string name, int num) :base(id, name, num)
        {
            shots = 0;
            saves = 0;
        }
    }
}
