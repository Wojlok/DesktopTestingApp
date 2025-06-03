using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ViewModel.Messages;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for result table.
    /// </summary>
    public partial class TableVM : ObservableRecipient, IRecipient<TableDataMessage>
    {

        private double? _a;

        private double? _b;

        private int _c;

        private int _n;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private DoubleTextboxVM _x = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private DoubleTextboxVM _y = new();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TableVM()
        {
            IsActive = true;
            X.PropertyChanged += DoublePropertyChanged;
            Y.PropertyChanged += DoublePropertyChanged;
        }

        /// <summary>
        /// Function f(x,y) getter.
        /// </summary>
        public double? Func
        {
            get
            {
                double? result = Model.Solver.Calculate(_a, _b, X.Value, Y.Value, _c, _n);
                return result;
            }
        }

        /// <summary>
        /// Coeffitients receiver.
        /// </summary>
        public void Receive(TableDataMessage message)
        {
            _a = message.Value.A;
            _b = message.Value.B;
            _c = message.Value.C;
            _n = message.Value.N;
            OnPropertyChanged(nameof(Func));
        }

        partial void OnXChanged(DoubleTextboxVM value)
        {
            WeakReferenceMessenger.Default.Send(new RequestTableMessage(this));
        }

        partial void OnYChanged(DoubleTextboxVM value)
        {
            WeakReferenceMessenger.Default.Send(new RequestTableMessage(this));
        }

        /// <summary>
        /// Table data initialization constructor.
        /// </summary>
        private void DoublePropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new RequestTableMessage(this));
        }
    }
}

