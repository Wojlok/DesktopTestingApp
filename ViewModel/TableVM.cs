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

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private double? _a;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private double? _b;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private int _c;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private int _n;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private double? _x;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Func))]
        private double? _y;

        private double? _func;

        /// <summary>
        /// Function f(x,y) getter.
        /// </summary>
        public double? Func
        {
            get
            {
                double? result = Model.Solver.Calculate(A, B, X, Y, C, N);
                return result;
            }

        }

        /// <summary>
        /// Coeffitients receiver.
        /// </summary>
        public void Receive(TableDataMessage message)
        {
            A = message.Value.A;
            B = message.Value.B;
            C = message.Value.C;
            N = message.Value.N;
        }

        partial void OnXChanged(double? value)
        {
            WeakReferenceMessenger.Default.Send(new RequestTableMessage(null));
        }

        partial void OnYChanged(double? value)
        {
            WeakReferenceMessenger.Default.Send(new RequestTableMessage(null));
        }

        /// <summary>
        /// Table data initialization constructor.
        /// </summary>
        public TableVM(double? x, double? y, double? func) : this()
        {
            X = x;
            Y = y;
            this._func = func;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TableVM()
        {
            IsActive = true;
        }

    }
}

