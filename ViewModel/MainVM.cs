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
        
        private List<double?> _aList = new List<double?>();

        private List<double?> _bList = new List<double?>();

        private List<int> _cIndexList = new List<int>();


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TableRows))]
        private int _currentCIndex;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TableRows))]
        private double? a = null;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TableRows))]
        private double? b = null;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(A))]
        [NotifyPropertyChangedFor(nameof(B))]
        [NotifyPropertyChangedFor(nameof(CurrentCIndex))]
        [NotifyPropertyChangedFor(nameof(CurrentCList))]
        private ObservableCollection<TableVM> _tableRows = new();

        [ObservableProperty]
        private List<string> _functions = new List<string>()
        {
            "Линейная", "Квадратичная", "Кубическая",
            "4-ой степени", "5-ой степени"
        };

        private string[] _functionsTexts =
        {
            "f(x, y) = ax + b + c",
            "f(x, y) = ax^2 + by + c",
            "f(x, y) = ax^3 + by^2 + c",
            "f(x, y) = ax^4 + by^3 + c",
            "f(x, y) = ax^5 + by^4 + c"
        };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FunctionIndex))]
        private string _functionName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(A))]
        [NotifyPropertyChangedFor(nameof(B))]
        [NotifyPropertyChangedFor(nameof(CurrentCIndex))]
        [NotifyPropertyChangedFor(nameof(CurrentCList))]
        [NotifyPropertyChangedFor(nameof(TableRows))]
        private int _functionIndex;

        List<ObservableCollection<int>> _listC = new();

        [ObservableProperty]
        private ObservableCollection<int> _currentCList;


        partial void OnFunctionIndexChanged(int oldValue, int newValue)
        {
            _aList[oldValue] = A;
            _bList[oldValue] = B;
            _cIndexList[oldValue] = CurrentCIndex;

            A = _aList[newValue];
            B = _bList[newValue];
            CurrentCList = _listC[newValue];
            CurrentCIndex = _cIndexList[newValue];
            FunctionName = _functionsTexts[newValue];

            OnPropertyChanged(nameof(CurrentCList));  
        }

        partial void OnAChanged(double? value)
        {
            WeakReferenceMessenger.Default.Send(new TableDataMessage(
                new TableData(A,B, CurrentCList[CurrentCIndex], CurrentCIndex))
                );
        }

        partial void OnBChanged(double? value)
        {
            WeakReferenceMessenger.Default.Send(new TableDataMessage(
                new TableData(A, B, CurrentCList[CurrentCIndex], CurrentCIndex))
                );
        }

        partial void OnCurrentCIndexChanged(int value)
        {
            if (value > -1)
            {
                WeakReferenceMessenger.Default.Send(new TableDataMessage(
                    new TableData(A, B, CurrentCList[CurrentCIndex], CurrentCIndex))
                    );
            }
        }

        partial void OnFunctionIndexChanged(int value)
        {
            WeakReferenceMessenger.Default.Send(new TableDataMessage(
                new TableData(A, B, CurrentCList[CurrentCIndex], CurrentCIndex))
                );
        }

        public void Receive(RequestTableMessage message)
        {
            WeakReferenceMessenger.Default.Send(new TableDataMessage(
               new TableData(A, B, CurrentCList[CurrentCIndex], CurrentCIndex))
               );
        }

        /// <summary>
        /// Default constructor of the class.
        /// </summary>
        public MainVM()
        {
            IsActive = true;

            CurrentCIndex = 0;
            for (int i = 0; i < Functions.Count; i++)
            {
                var temp = Model.Constant.GetListC(i);
                _listC.Add(new ObservableCollection<int>(temp));
                _aList.Add(a);
                _bList.Add(b);
                _cIndexList.Add(CurrentCIndex);
            }
            FunctionName = _functionsTexts[0];
            CurrentCList = _listC[0];
            FunctionIndex = 0;
            TableRows.Add(new TableVM());
        }

    }
}
