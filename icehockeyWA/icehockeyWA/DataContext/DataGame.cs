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
    public class DataGame
    {

        private EntitySet<DataLocation> locationRef;
        private EntitySet<DataPenalties> penaltiesRef;
        private EntitySet<DataGoals> goalsRef;

        public DataGame()
        {
            this.locationRef = new EntitySet<DataLocation>();
            this.goalsRef = new EntitySet<DataGoals>();
            this.penaltiesRef = new EntitySet<DataPenalties>();
        }

      

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int location_ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public DateTime date
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public DateTime time
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int linesman_ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int ref_ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int team_awayID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int team_home_ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public char extra_time
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public char game_time
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public char notes
        {
            get;
            set;
        }

        [Association(Name = "New_Game ", Storage = "GameRef", ThisKey = "Game_ID", OtherKey = "ID", IsForeignKey = true)]

        public EntitySet<DataLocation> Location
        {
            get
            {
                return this.locationRef;
            }
        }


        public EntitySet<DataGoals> Goals
        {
            get
            {
                return this.goalsRef;
            }
        }

        public EntitySet<DataPenalties> Penalties
        {
            get
            {
                return this.penaltiesRef;
            }
        }

    }
}
