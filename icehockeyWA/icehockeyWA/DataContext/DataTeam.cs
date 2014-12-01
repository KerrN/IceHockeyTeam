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
using System.Data.Linq.Mapping;
using System.Data.Linq;
//TK
namespace icehockeyWA.DataContext
{
    [Table]
    public class DataTeam
    {
        private Nullable<int> GameID;
        private EntityRef<DataGame> gameRef = new EntityRef<DataGame>();

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int Player_TeamID
        {
            get;
            set;
        }


        [Column(CanBeNull = false)]
        public string name
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string manager_ID
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string manager_ID2
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string division
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string Coach_ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string Coach_ID2
        {
            get;
            set;
        }
        [Association(Name = "New_Game ", Storage = "GameRef", ThisKey = "Game_ID", OtherKey = "ID", IsForeignKey = true)]
        public DataGame NewGame
        {
            get
            {
                return this.gameRef.Entity;
            }
        }
    
    }
}
