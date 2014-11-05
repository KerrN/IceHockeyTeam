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

namespace icehockeyWA
{
	public class LoopingDataSource : ILoopingSelectorDataSource
	{
        private int minimum = 0;
		private int maximum;
		private int selectedItem = 0;
        private List<string> dataArray;

        public LoopingDataSource(List<string> dataArray)
		{
            this.dataArray = dataArray;

            maximum = dataArray.Count - 1;
		}

        public object GetNext(object relativeTo)
        {
            int nextIndex = dataArray.IndexOf((string)relativeTo) + 1;

            return dataArray[nextIndex <= maximum ? nextIndex : minimum];
        }

        public object GetPrevious(object relativeTo)
        {
            var previousIndex = dataArray.IndexOf((string)relativeTo) - 1;

            return dataArray[previousIndex >= minimum ? previousIndex : maximum];
        }

        public object SelectedItem
        {
            get
            {
                return dataArray[selectedItem];
			}
			set
			{
				var oldIndex = selectedItem;
                var newIndex = dataArray.IndexOf((string)value);

                if (oldIndex == newIndex)
					return;

                selectedItem = newIndex;

                OnSelectedChanged(new SelectionChangedEventArgs(new[] { oldIndex }, new[] { newIndex }));
			}
        }

		protected virtual void OnSelectedChanged(SelectionChangedEventArgs e)
		{
			var selectionChanged = SelectionChanged;

			if(selectionChanged != null)
				selectionChanged(this, e);

		}
		
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
    }
}