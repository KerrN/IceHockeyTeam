﻿#pragma checksum "C:\Users\Jinho\Documents\Visual Studio 2010\Projects\icehockeyWA\icehockeyWA\Game.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A3FFD167CC90B04B8A3987C2D466D7B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace icehockeyWA {
    
    
    public partial class Game : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox HomeTeamTb;
        
        internal System.Windows.Controls.Button LeftShotBtn;
        
        internal System.Windows.Controls.Button LeftGoalBtn;
        
        internal System.Windows.Controls.Button LeftPenaltyBtn;
        
        internal System.Windows.Controls.TextBox ScoreTb;
        
        internal System.Windows.Controls.TextBox PeriodTb;
        
        internal System.Windows.Controls.TextBox TimeTb;
        
        internal System.Windows.Controls.Button OthersBtn;
        
        internal System.Windows.Controls.TextBox AwayTeamTb;
        
        internal System.Windows.Controls.Button RightShotBtn;
        
        internal System.Windows.Controls.Button RightGoalBtn;
        
        internal System.Windows.Controls.Button RIghtPenaltyBtn;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/icehockeyWA;component/Game.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.HomeTeamTb = ((System.Windows.Controls.TextBox)(this.FindName("HomeTeamTb")));
            this.LeftShotBtn = ((System.Windows.Controls.Button)(this.FindName("LeftShotBtn")));
            this.LeftGoalBtn = ((System.Windows.Controls.Button)(this.FindName("LeftGoalBtn")));
            this.LeftPenaltyBtn = ((System.Windows.Controls.Button)(this.FindName("LeftPenaltyBtn")));
            this.ScoreTb = ((System.Windows.Controls.TextBox)(this.FindName("ScoreTb")));
            this.PeriodTb = ((System.Windows.Controls.TextBox)(this.FindName("PeriodTb")));
            this.TimeTb = ((System.Windows.Controls.TextBox)(this.FindName("TimeTb")));
            this.OthersBtn = ((System.Windows.Controls.Button)(this.FindName("OthersBtn")));
            this.AwayTeamTb = ((System.Windows.Controls.TextBox)(this.FindName("AwayTeamTb")));
            this.RightShotBtn = ((System.Windows.Controls.Button)(this.FindName("RightShotBtn")));
            this.RightGoalBtn = ((System.Windows.Controls.Button)(this.FindName("RightGoalBtn")));
            this.RIghtPenaltyBtn = ((System.Windows.Controls.Button)(this.FindName("RIghtPenaltyBtn")));
        }
    }
}

