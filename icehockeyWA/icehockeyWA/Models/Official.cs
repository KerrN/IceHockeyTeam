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
        public int officialID;
        public string name { get; set; }
        public bool signedOff;
        //private Uri signature;
        public string type;

        public Official(string name, string type)
        {
            //this.officialID = officialID;
            this.name = name;
            this.type = type;

            signedOff = false;
            //signature = new Uri();
        }

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
