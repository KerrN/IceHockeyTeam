﻿#pragma checksum "C:\Users\041309786\Documents\GitHub\IceHockeyTeam\icehockeyWA\icehockeyWA\Penalty.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "178A47D54A918ACBFCF77886513C11B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Primitives;
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
    
    
    public partial class Penalty : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid TopPanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid LoopingSelectorPanel;
        
        internal Microsoft.Phone.Controls.Primitives.LoopingSelector PlayerLoopingSelector;
        
        internal Microsoft.Phone.Controls.Primitives.LoopingSelector PenaltyLoopingSelector;
        
        internal Microsoft.Phone.Controls.Primitives.LoopingSelector TimeLoopingSelector;
        
        internal System.Windows.Controls.Grid OptionPanel;
        
        internal System.Windows.Controls.CheckBox PenaltyShotChk;
        
        internal System.Windows.Controls.Button OtherPenaltyBtn;
        
        internal System.Windows.Controls.ListBox PenaltiesListBox;
        
        internal System.Windows.Controls.Grid ButtonPanel;
        
        internal System.Windows.Controls.Button AddHomePenaltyBtn;
        
        internal System.Windows.Controls.Button AddAwayPenaltyBtn;
        
        internal System.Windows.Controls.Button ConfirmBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/icehockeyWA;component/Penalty.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TopPanel = ((System.Windows.Controls.Grid)(this.FindName("TopPanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.LoopingSelectorPanel = ((System.Windows.Controls.Grid)(this.FindName("LoopingSelectorPanel")));
            this.PlayerLoopingSelector = ((Microsoft.Phone.Controls.Primitives.LoopingSelector)(this.FindName("PlayerLoopingSelector")));
            this.PenaltyLoopingSelector = ((Microsoft.Phone.Controls.Primitives.LoopingSelector)(this.FindName("PenaltyLoopingSelector")));
            this.TimeLoopingSelector = ((Microsoft.Phone.Controls.Primitives.LoopingSelector)(this.FindName("TimeLoopingSelector")));
            this.OptionPanel = ((System.Windows.Controls.Grid)(this.FindName("OptionPanel")));
            this.PenaltyShotChk = ((System.Windows.Controls.CheckBox)(this.FindName("PenaltyShotChk")));
            this.OtherPenaltyBtn = ((System.Windows.Controls.Button)(this.FindName("OtherPenaltyBtn")));
            this.PenaltiesListBox = ((System.Windows.Controls.ListBox)(this.FindName("PenaltiesListBox")));
            this.ButtonPanel = ((System.Windows.Controls.Grid)(this.FindName("ButtonPanel")));
            this.AddHomePenaltyBtn = ((System.Windows.Controls.Button)(this.FindName("AddHomePenaltyBtn")));
            this.AddAwayPenaltyBtn = ((System.Windows.Controls.Button)(this.FindName("AddAwayPenaltyBtn")));
            this.ConfirmBtn = ((System.Windows.Controls.Button)(this.FindName("ConfirmBtn")));
        }
    }
}

