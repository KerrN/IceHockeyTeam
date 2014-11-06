﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

// made by jinho, fixed by lucas and josh

namespace icehockeyWA.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged 


 
   { 



       public event PropertyChangedEventHandler PropertyChanged; 



       protected virtual void OnPropertyChanged(string propName) 


      { 

           if (PropertyChanged != null) 

           { 
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); 

           } 

       } 

   } 


}
