namespace Model
{
    /// <summary>
    /// Class for constants.
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// List of base <see langword="int"/> numbers (1, 2, 3, 4, 5).
        /// </summary>
        private static readonly List<int> _listC = new List<int>()
        {
            1, 2, 3, 4, 5
        };

        /// <summary>
        /// Generates list of numbers multiplied by 10 enpowered of n.
        /// </summary>
        /// <param name="n">Multipier (10^n)</param>
        /// <returns>List of base numbers multiplied by 10^n.</returns>
        public static List<int> GetListC(int n)
        {
            List<int> listCResult = new List<int>();
            foreach (var item in _listC)
            {
                listCResult.Add(item * (int)Math.Pow(10, n));
            }
            return listCResult;
        }

    }
}
