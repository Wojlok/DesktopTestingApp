namespace Model
{
    /// <summary>
    /// Class for doing the math.
    /// </summary>
    public class Solver
    {
        /// <summary>
        /// Calculate the expression.
        /// </summary>
        /// <param name="a">Coefficent a.</param>
        /// <param name="b">Coffienct b.</param>
        /// <param name="x">Variable X.</param>
        /// <param name="y">Variable Y.</param>
        /// <param name="c">Coefficent c.</param>
        /// <param name="n">Enpower of the expression.</param>
        /// <returns>Calculated expression or <see langword="null"/> if there was an error</returns>
        public static double? Calculate(double? a, double? b, double? x, double? y, int c, int n)
        {
            if (n == int.MaxValue || c == int.MaxValue) return null;
            if (a == null || b == null || x == null || y == null) return null;
            if (Double.IsNaN((double)a) || Double.IsNaN((double)b) || Double.IsNaN((double)x) || Double.IsNaN((double)y)) return null;
            if (c < 0 || n < 0) return null;
            double? f;
            f = a * Math.Pow((double)x, n) + b * Math.Pow((double)y, n - 1) + c;
            if (a == double.MaxValue || b == double.MaxValue || x == double.MaxValue || y == double.MaxValue || f == double.MaxValue) return null;
            if (double.IsInfinity((double)f))
            {
                return null;
            }

            return f;
        }
    }
}
