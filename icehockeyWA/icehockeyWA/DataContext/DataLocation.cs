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

namespace icehockeyWA.DataContext
{
    [Table]
    public class DataLocation
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
        public char name
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public char address
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public char contact_name
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public char contact_email
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int contact_phone
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
