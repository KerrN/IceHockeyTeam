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

namespace icehockeyWA.Views
{
    public partial class SignatureView : PhoneApplicationPage
    {
        public SignatureView()
        {
            InitializeComponent();
            signaturePad.MouseMove += new MouseEventHandler(signaturePad_MouseMove);
            signaturePad.MouseLeftButtonDown += new MouseButtonEventHandler(signaturePad_MouseLeftButtonDown);
            signaturePad.MouseLeftButtonUp += new MouseButtonEventHandler(signaturePad_MouseLeftButtonUp);
        }

        private Stroke _currentStroke;
        // inpresenter mechanism adapted from an online tutorial AK
        private void signaturePad_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _currentStroke = null;
        }

        private void signaturePad_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentStroke != null)
                _currentStroke.StylusPoints.Add(GetStylusPoint(e.GetPosition(signaturePad)));
        }

        private void signaturePad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            signaturePad.CaptureMouse();
            _currentStroke = new Stroke();
            _currentStroke.StylusPoints.Add(GetStylusPoint(e.GetPosition(signaturePad)));
            _currentStroke.DrawingAttributes.Color = Colors.Blue;
            signaturePad.Strokes.Add(_currentStroke);
        }

        private StylusPoint GetStylusPoint(Point position)
        {
            return new StylusPoint(position.X, position.Y);
        }

        private Stack<Stroke> _removedStrokes = new Stack<Stroke>();
        // inkpresenter mechanism end AK


        // undo and redo functions now obselete given buttons available AK
        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {// variables stroke_count and a boolean variable indicating whether strokes count>0 have since been replaced with the below system variables AK ( original variable were mine)
            if (signaturePad.Strokes != null && signaturePad.Strokes.Count > 0)
            {
                _removedStrokes.Push(signaturePad.Strokes.Last());
                signaturePad.Strokes.RemoveAt(signaturePad.Strokes.Count - 1);
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            if (_removedStrokes != null && _removedStrokes.Count > 0)
            {
                signaturePad.Strokes.Add(_removedStrokes.Pop());
            }
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {

        }  
        
    }
}