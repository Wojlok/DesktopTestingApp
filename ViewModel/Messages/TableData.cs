namespace ViewModel.Messages
{
    /// <summary>
    /// Data for messages.
    /// </summary>
    public class TableData
    {
        /// <summary>
        /// A coeffitient.
        /// </summary>
        public double? A { get; set; }

        /// <summary>
        /// B coeffitient.
        /// </summary>
        public double? B { get; set; }

        /// <summary>
        /// C coeffitient.
        /// </summary>
        public int C { get; set; }

        /// <summary>
        /// Function f(x,y) type.
        /// </summary>
        public int N { get; set; }
 
        public TableData(double? a, double? b, int c, int n)
        {
            {
                A = a;
                B = b;
                C = c;
                N = n;
            }
        }
    }
}
