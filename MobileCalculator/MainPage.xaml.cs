using System.Diagnostics;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        private string _currentNumber;
        public string currentNumber 
        {
            get 
            { 
                return _currentNumber; 
            }
            set
            {
                _currentNumber = value;
                OutputText.Text = _currentNumber;
            }
        }

        private double _storedNumber = 0;

        private bool _multiplyActive;
        private bool _divideActive;
        private bool _addActive;
        private bool _subtractActive;


        public MainPage()
        {
            InitializeComponent();

            // Android-specific initialization
#if ANDROID
            // Run Android-specific code here
            InitializeAndroidSpecific();
#endif

#if WINDOWS
            // Run Android-specific code here
            InitializeWindowsSpecific();
#endif
        }


        private void InitializeAndroidSpecific()
        {
            AndroidUI androidUI = new AndroidUI(InputGrid);
            androidUI.InitializeInputButtons();
        }

        private void InitializeWindowsSpecific()
        {
            Debug.WriteLine("Running On Windows");
        }

        private void ACButton_Clicked(object sender, EventArgs e)
        {
            currentNumber = "";
            _storedNumber = 0;
            MarkButtonActive(null);
        }

        private void PlusMinusButton_Clicked(object sender, EventArgs e)
        {
            if (currentNumber == "")
            {
                currentNumber += "-";
            }
            else
            {
                double currentNumberAsDouble = Convert.ToDouble(currentNumber);
                double reversedCurrentNumber = 0 - currentNumberAsDouble;
                currentNumber = reversedCurrentNumber.ToString();
            }

        }

        private void PercentButton_Clicked(object sender, EventArgs e)
        {

        }

        private void DivideButton_Clicked(object sender, EventArgs e)
        {
            Calculate();
            setCalculationActive(ref _divideActive);
            MarkButtonActive(sender as Button);


        }
        private void TimesButton_Clicked(object sender, EventArgs e)
        {
            Calculate();
            setCalculationActive(ref _multiplyActive);
            MarkButtonActive(sender as Button);


        }

        private void MinusButton_Clicked(object sender, EventArgs e)
        {
            Calculate();
            setCalculationActive(ref _subtractActive);
            MarkButtonActive(sender as Button);


        }

        private void PlusButton_Clicked(object sender, EventArgs e)
        {
            Calculate();
            setCalculationActive(ref _addActive);
            MarkButtonActive(sender as Button);

        }

        private void SevenButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 7;
        }

        private void EightButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 8;
        }

        private void NineButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 9;
        }

        private void FourButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 4;
        }

        private void FiveButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 5;
        }

        private void SixButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 6;
        }

        private void OneButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 1;
        }

        private void TwoButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 2;
        }

        private void ThreeButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 3;
        }

        private void ZeroButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += 0;
        }

        private void DecimalButton_Clicked(object sender, EventArgs e)
        {
            currentNumber += ".";
        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            Calculate();
            currentNumber = _storedNumber.ToString();
            MarkButtonActive(null);
        }

        private void Calculate()
        {
            if (Double.TryParse(currentNumber, out double currentNumberDouble))
            {
                if (_multiplyActive)
                {
                    _storedNumber = (_storedNumber * currentNumberDouble);
                }
                else if (_divideActive)
                {
                    _storedNumber = (_storedNumber / currentNumberDouble);
                }
                else if (_addActive)
                {
                    _storedNumber = (_storedNumber + currentNumberDouble);
                }
                else if (_subtractActive)
                {
                    _storedNumber = (_storedNumber - currentNumberDouble);
                }
                else
                {
                    _storedNumber = currentNumberDouble;
                }
                _currentNumber = "";
                OutputText.Text = _storedNumber.ToString(); ;

                _multiplyActive = false;
                _divideActive = false;
                _addActive = false;
                _subtractActive = false;
            }
        }

        private void setCalculationActive(ref bool calculation)
        {
            _multiplyActive = false;
            _divideActive = false;
            _addActive = false;
            _subtractActive = false;

            calculation = true;
        }

        private void MarkButtonActive(Button? button)
        {
            Button[] buttonList = { PlusButton, MinusButton, DivideButton, TimesButton, EqualButton };

            foreach (Button b in buttonList)
            {
                b.BackgroundColor = Colors.Orange;
                b.TextColor = Colors.White;
            }

            if (button != null)
            {
                button.BackgroundColor = Colors.White;
                button.TextColor = Colors.Orange;
            }

        }
    }

}
