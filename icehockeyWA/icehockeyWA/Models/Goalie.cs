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

        //this will be the number of shots that have been taken against the goalie
        //it includes shots that result in a goal
        public int shots;

        //this will be the number of saves made by the goalie (ie. the number of 'shots' on the scorecard)
        //the number of goals made against this goalie will be shots-saves
        public int saves;

        public Goalie(int id, string name, int num) :base(id, name, num)
        {
            shots = 0;
            saves = 0;
        }

        public void addGoalAgainst()
        {
            this.shots++;
        }

        public void addShotAgainst()
        {
            this.shots++;
            this.saves++;
        }

        public double GetSavePercentage()
        {
            double result = 0;

            if (shots != 0)
            {
                result = saves / shots;
            }

            return result;
        }
    }
}
