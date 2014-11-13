using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls.Primitives;

namespace Penalty
{
	public class TimeDataSource : ILoopingSelectorDataSource
	{
        private int minimum = 0;
        private int maximum;
        private int selectedItem = 0;
        private string[] timeArray;
		
		public TimeDataSource()
		{
			// Insert code required on object creation below this point.
            timeArray = new string[10]{"Time1", "Time2", "Time3", "Time4",
                "Time5", "Time6", "Time7", "Time8", "Time9", "Time10"};
            maximum = timeArray.Length - 1;
		}

        public object GetNext(object relativeTo)
        {
            int nextIndex = Array.IndexOf(timeArray, relativeTo) + 1;

            return timeArray[nextIndex <= maximum ? nextIndex : minimum];
        }

        public object GetPrevious(object relativeTo)
        {
            var previousIndex = Array.IndexOf(timeArray, relativeTo) - 1;

            return timeArray[previousIndex >= minimum ? previousIndex : maximum];
        }

        public object SelectedItem
        {
            get
            {
                return timeArray[selectedItem];
            }
            set
            {
                var oldIndex = selectedItem;
                var newIndex = Array.IndexOf(timeArray, value);

                if (oldIndex == newIndex)
                    return;

                selectedItem = newIndex;

                OnSelectedChanged(new SelectionChangedEventArgs(new[] { oldIndex }, new[] { newIndex }));
            }
        }

        protected virtual void OnSelectedChanged(SelectionChangedEventArgs e)
        {
            var selectionChanged = SelectionChanged;

            if (selectionChanged != null)
                selectionChanged(this, e);

        }

        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
    }
}