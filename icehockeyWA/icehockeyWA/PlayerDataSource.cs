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
	public class PlayerDataSource : ILoopingSelectorDataSource
	{
        private int minimum = 0;
		private int maximum;
		private int selectedItem = 0;
        private string[] playerArray;

		public PlayerDataSource()
		{
			// Insert code required on object creation below this point.
            playerArray = new string[10]{"Player1", "Player2", "Player3", "Player4",
                "Player5", "Player6", "Player7", "Player8", "Player9", "Player10"};
            maximum = playerArray.Length - 1;
		}

        public object GetNext(object relativeTo)
        {
            int nextIndex = Array.IndexOf(playerArray, relativeTo) + 1;

            return playerArray[nextIndex <= maximum ? nextIndex : minimum];
        }

        public object GetPrevious(object relativeTo)
        {
            var previousIndex = Array.IndexOf(playerArray, relativeTo) - 1;

            return playerArray[previousIndex >= minimum ? previousIndex : maximum];
        }

        public object SelectedItem
        {
            get
            {
                return playerArray[selectedItem];
			}
			set
			{
				var oldIndex = selectedItem;
				var newIndex = Array.IndexOf(playerArray, value);

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