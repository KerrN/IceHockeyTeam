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

namespace DataBinding
{
    public class Person
    {
        public enum Sex
        {
            Male,
            Female,
        }
        public string Name { get; set; }
        public bool Moustache { get; set; }
        public bool Goatee { get; set; }
        public bool Beard { get; set; }
        public Sex WhichSex { get; set; }
        public double Height { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Favorite { get; set; }

    }
}
