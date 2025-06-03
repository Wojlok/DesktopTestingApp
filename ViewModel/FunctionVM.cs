using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for function ListBox.
    /// </summary>
    public partial class FunctionVM: ObservableObject
    {

        [ObservableProperty]
        private DoubleTextboxVM _a = new();

        [ObservableProperty]
        private DoubleTextboxVM _b = new();

        [ObservableProperty]
        private int _c;

        /// <summary>
        /// The power of current function type.
        /// </summary>
        public int N { get; set; }

        [ObservableProperty]
        private string _functionName;

        [ObservableProperty]
        private string _functionText;

        [ObservableProperty]
        private ObservableCollection<int> _cList;


        /// <summary>
        /// Main constructor of the class.
        /// </summary>
        /// <param name="name">Name of the function.</param>
        /// <param name="cList">Possible variants of c values.</param>
        /// <param name="n">The power of current function type.</param>
        /// <param name="functionText">Math expression of current function type.</param>
        public FunctionVM (string name, ObservableCollection<int> cList, int n, string functionText)
        {
            FunctionName = name;
            CList = cList;
            FunctionText = functionText;
            N = n;
            C = CList.First();
        }

        /// <summary>
        /// Displays class as string
        /// </summary>
        /// <returns>Name of the current function type.</returns>
        public override string ToString()
        {
            return FunctionName;
        }
    }
}
