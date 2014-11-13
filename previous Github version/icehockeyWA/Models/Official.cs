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
    public class Official
    {
        private int officialID;
        private string name;
        private bool signedOff;
        //private Uri signature;
        private string type;

        public Official(int officialID, string name, string type)
        {
            this.officialID = officialID;
            this.name = name;
            this.type = type;

            signedOff = false;
            //signature = new Uri();
        }

        public int getOfficialID()
        {
            return officialID;
        }

        public string getName()
        {
            return name;
        }

        public bool getSignedOff()
        {
            return signedOff;
        }

        /*public Uri getSignature()
        {
            return signature;
        }*/

        public string getType()
        {
            return type;
        }


    }
}
