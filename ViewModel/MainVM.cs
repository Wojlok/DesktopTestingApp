using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using ViewModel.Messages;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for main window.
    /// </summary>
    public partial class MainVM : ObservableRecipient, IRecipient<RequestTableMessage>
    {

        private string[] _functionsTexts =
        {
            "f(x, y) = ax + b + c",
            "f(x, y) = ax\xB2 + by + c",
            "f(x, y) = ax\xB3 + by\xB2 + c",
            "f(x, y) = ax\x2074 + by\xB3 + c",
            "f(x, y) = ax\x2075 + by\x2074 + c"
        };

        [ObservableProperty]
        private List<string> _functions = new List<string>()
        {
            "Линейная", "Квадратичная", "Кубическая",
            "4-ой степени", "5-ой степени"
        };

        [ObservableProperty]
        private ObservableCollection<FunctionVM> _functionsList = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FunctionsList))]
        private FunctionVM _currentFunction;


        [ObservableProperty]
        private ObservableCollection<TableVM> _tableRows = new();


        /// <summary>
        /// Default constructor of the class.
        /// </summary>
        public MainVM()
        {
            IsActive = true;

            for (int i = 0; i < _functions.Count; i++)
            {
                List<int> cL = Model.Constant.GetListC(i);
                FunctionsList.Add(new(_functions[i], new(cL), i, _functionsTexts[i]));
            }

            CurrentFunction = FunctionsList.First();
            TableRows.Add(new TableVM());
        }

        /// <summary>
        /// Event handler for changed function type.
        /// </summary>
        /// <param name="oldValue">Previous function type.</param>
        /// <param name="newValue">Present function type.</param>
        partial void OnCurrentFunctionChanged(FunctionVM? oldValue, FunctionVM newValue)
        {
            if (oldValue != null)
            {
                oldValue.A.PropertyChanged -= TextboxValueChanged;
                oldValue.B.PropertyChanged -= TextboxValueChanged;
                oldValue.PropertyChanged -= TextboxValueChanged;
            }

            if (newValue != null)
            {
                newValue.A.PropertyChanged += TextboxValueChanged;
                newValue.B.PropertyChanged += TextboxValueChanged;
                newValue.PropertyChanged += TextboxValueChanged;
            }

            UpdateTable();
        }

        private void TextboxValueChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
            => UpdateTable();

        private void UpdateTable()
        {
            var message = new TableData(CurrentFunction.A.Value, CurrentFunction.B.Value, CurrentFunction.C, CurrentFunction.N);
            WeakReferenceMessenger.Default.Send(new TableDataMessage(message));
        }

        /// <summary>
        /// Request for table data update.
        /// </summary>
        /// <param name="message">Requastable data with function parameters.</param>
        public void Receive(RequestTableMessage message) => UpdateTable();

    }
}