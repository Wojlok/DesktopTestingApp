using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for only numeric TextBox.
    /// </summary>
    public class DoubleTextboxVM : ObservableObject
    {
        private string _text = "";
        private string _previousText = "";
        private double? _value;

        /// <summary>
        /// Numeric value from TextBox.
        /// </summary>
        public double? Value 
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// Text from TextBox.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                if (_text == value) return;

                if (IsValid(value, out double? res))
                {
                    _previousText = value;
                    SetProperty(ref _text, value);
                    SetProperty(ref _value, res);
                    OnPropertyChanged(nameof(Text));
                    OnPropertyChanged(nameof(Value));
                }
                else
                {
                    SetProperty(ref _text, _previousText);
                }
            }
        }

        /// <summary>
        /// Numeric validation of TextBox input.
        /// </summary>
        /// <param name="input">Text from TextBox.</param>
        /// <param name="res">Parsed double.</param>
        /// <returns>Is input numeric.</returns>
        private bool IsValid(string input, out double? val)
        {
            val = null;
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            if (input.EndsWith('.') || input.EndsWith(','))
            {
                input += '0';
            }

            if (input == "-")
            {
                val = null;
                return true;
            }

            if (input.Contains(' '))
            {
                return false;
            }

            string deminused = input.Replace("-", "");

            if (deminused.Length > 1 && deminused.StartsWith('0') && !deminused.Contains(',')
                || deminused.StartsWith(','))
            {
                return false;
            }

            if (double.TryParse(input, out double d))
            {
                val = d;
                return true;
            }
            return false;
        }

    }
}