using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCalculator
{
    class AndroidUI
    {

        private double _buttonSize = 80;

        Grid _grid;

        public AndroidUI(Grid grid)
        {
            this._grid = grid;
        }
        public void InitializeInputButtons()
        {
            foreach(Button button in  _grid)
            {
                if (button.Text != "0")
                {
                    button.Margin = new Thickness(3, 3, 3, 3);
                    button.CornerRadius = ((int)_buttonSize) / 2;
                    button.HeightRequest = _buttonSize;
                    button.WidthRequest = _buttonSize;
                }
                else
                {
                    button.Margin = new Thickness(5, 5, 5, 5);
                    button.CornerRadius = ((int)_buttonSize) / 2;
                    button.HeightRequest = _buttonSize;
                    button.WidthRequest = (_buttonSize * 2) + 6;
                }

                button.FontAttributes = FontAttributes.Bold;
                button.FontSize = 24;
            }

        }
    }
}
