using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Ink;

namespace signature_silverlight
{
    public partial class MainPage : PhoneApplicationPage
    {
        int counter;
        Boolean sig_status;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            inkTest.MouseMove += new MouseEventHandler(inkTest_MouseMove);  
            inkTest.MouseLeftButtonDown += new MouseButtonEventHandler(inkTest_MouseLeftButtonDown);  
            inkTest.MouseLeftButtonUp += new MouseButtonEventHandler(inkTest_MouseLeftButtonUp);
            counter = 0;
            sig_status = false;

        }

        private Stroke _currentStroke;  
  
        private void inkTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)  
        {  
            _currentStroke = null;  
        }  
  
        private void inkTest_MouseMove(object sender, MouseEventArgs e)  
        {  
            if (_currentStroke != null)  
                _currentStroke.StylusPoints.Add(GetStylusPoint(e.GetPosition(inkTest)));  
        }  
  
        private void inkTest_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  
        {  
            inkTest.CaptureMouse();  
            _currentStroke = new Stroke();  
            _currentStroke.StylusPoints.Add(GetStylusPoint(e.GetPosition(inkTest)));  
            _currentStroke.DrawingAttributes.Color = Colors.Blue;  
            inkTest.Strokes.Add(_currentStroke);
            counter = counter + 1;
            textBox1.Text = counter.ToString();
        }  
  
        private StylusPoint GetStylusPoint(Point position)  
        {  
            return new StylusPoint(position.X, position.Y);  
        }  

        private Stack<Stroke> _removedStrokes = new Stack<Stroke>();  
  
        private void btnUndo_Click(object sender, RoutedEventArgs e)  
        {  
            if (inkTest.Strokes != null && inkTest.Strokes.Count > 0)  
            {  
                _removedStrokes.Push(inkTest.Strokes.Last());  
                inkTest.Strokes.RemoveAt(inkTest.Strokes.Count - 1);
                counter = counter - 1;
                textBox1.Text = counter.ToString();
            }  
        }  
  
        private void btnRedo_Click(object sender, RoutedEventArgs e)  
        {  
            if (_removedStrokes != null && _removedStrokes.Count > 0)  
            {  
                inkTest.Strokes.Add(_removedStrokes.Pop());
                counter = counter + 1;
                textBox1.Text = counter.ToString();
            }  
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if (counter < 1)
            { 
                textBox1.Text="no sig";
                sig_status = false;
            }
            else
            { 
                textBox1.Text = "sig accepted";
                sig_status = true;
                NavigationService.Navigate(new Uri("/Views/ConfirmGameView.xaml", UriKind.Relative));
            }
        }  

    }
}