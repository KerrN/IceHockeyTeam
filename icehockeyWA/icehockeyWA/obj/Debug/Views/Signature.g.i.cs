﻿#pragma checksum "C:\Users\041401298\Downloads\IceHockeyTeam\icehockeyWA\icehockeyWA\Views\Signature.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B29C149DCAAD9308BCE757DC57EC661F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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


namespace signature_silverlight {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid ContentGrid;
        
        internal System.Windows.Controls.InkPresenter inkTest;
        
        internal System.Windows.Controls.TextBox textBox1;
        
        internal System.Windows.Controls.Button btnUndo;
        
        internal System.Windows.Controls.Button btnRedo;
        
        internal System.Windows.Controls.Button btnDone;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/icehockeyWA;component/Views/Signature.xaml", System.UriKind.Relative));
            this.ContentGrid = ((System.Windows.Controls.Grid)(this.FindName("ContentGrid")));
            this.inkTest = ((System.Windows.Controls.InkPresenter)(this.FindName("inkTest")));
            this.textBox1 = ((System.Windows.Controls.TextBox)(this.FindName("textBox1")));
            this.btnUndo = ((System.Windows.Controls.Button)(this.FindName("btnUndo")));
            this.btnRedo = ((System.Windows.Controls.Button)(this.FindName("btnRedo")));
            this.btnDone = ((System.Windows.Controls.Button)(this.FindName("btnDone")));
        }
    }
}

