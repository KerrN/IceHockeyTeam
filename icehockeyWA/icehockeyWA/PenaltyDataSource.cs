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
	public class PenaltyDataSource : ILoopingSelectorDataSource
	{
        private int minimum = 0;
        private int maximum;
        private int selectedItem = 0;
        private string[] penaltyArray;

		public PenaltyDataSource()
		{
			// Insert code required on object creation below this point.
            penaltyArray = new string[10]{"Penalty1", "Penalty2", "Penalty3", "Penalty4",
                "Penalty5", "Penalty6", "Penalty7", "Penalty8", "Penalty9", "Penalty10"};
            maximum = penaltyArray.Length - 1;
		}

        public object GetNext(object relativeTo)
        {
            int nextIndex = Array.IndexOf(penaltyArray, relativeTo) + 1;

            return penaltyArray[nextIndex <= maximum ? nextIndex : minimum];
        }

        public object GetPrevious(object relativeTo)
        {
            var previousIndex = Array.IndexOf(penaltyArray, relativeTo) - 1;

            return penaltyArray[previousIndex >= minimum ? previousIndex : maximum];
        }

        public object SelectedItem
        {
            get
            {
                return penaltyArray[selectedItem];
            }
            set
            {
                var oldIndex = selectedItem;
                var newIndex = Array.IndexOf(penaltyArray, value);

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