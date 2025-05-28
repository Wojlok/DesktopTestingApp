using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace UnitTests
{
    public class SolverTests
    {
        [Fact]
        public void Calculate_DoubleInputIsNull_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) variables[j] = null;
                    else variables[j] = 25;
                }
                c = 2;
                n = 3;
                if (Solver.Calculate(variables[0], variables[1], 
                    variables[2], variables[3], c, n) != null)
                {
                    result = false;
                }
            }
            Assert.True(result);
        }

        [Fact]
        public void Calculate_DoubleInputIsNaN_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) variables[j] = Double.NaN;
                    else variables[j] = 25;
                }
                c = 2;
                n = 3;
                if (Solver.Calculate(variables[0], variables[1],
                    variables[2], variables[3], c, n) != null)
                {
                    result = false;
                }
            }
            Assert.True(result);
        }

        [Fact]
        public void Calculate_DoubleInputMaxValue_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    variables[j] = Double.MaxValue;
                    c = j;
                    n = j;
                }
                if (Solver.Calculate(variables[0], variables[1],
                    variables[2], variables[3], c, n) != null)
                {
                    result = false;
                }
            }
            Assert.True(result);
        }

        [Fact]
        public void Calculate_IntInputIsBelowZero_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;
            for (int j = 0; j < 4; j++)
            {
                variables[j] = 5;
            }
            c = -1;
            n = 2;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != null)
            {
                result = false;
            }
            c = 2;
            n = -1;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != null)
            {
                result = false;
            }
            Assert.True(result);
        }

        [Fact]
        public void Calculate_IntInputMaxValue_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;
            for (int j = 0; j < 4; j++)
            {
                variables[j] = 5;
            }
            c = int.MaxValue;
            n = 2;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != null)
            {
                    result = false;
            }
            c = 2;
            n = int.MaxValue;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != null)
            {
                result = false;
            }
            Assert.True(result);
        }

        [Fact]
        public void Calculate_CorrectOutput_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;

            variables[0] = 1; // a
            variables[1] = 2; // b
            variables[2] = 3; // x
            variables[3] = 4; // y
            c = 300;
            n = 1;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != 317)
            {
                result = false;
            }

            variables[0] = 4; // a
            variables[1] = 3; // b
            variables[2] = 2; // x
            variables[3] = 1; // y
            c = 2000;
            n = 2;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != 2035)
            {
                result = false;
            }

            variables[0] = 6; // a
            variables[1] = 20; // b
            variables[2] = 512; // x
            variables[3] = 7; // y
            c = 5;
            n = 0;
            if (Solver.Calculate(variables[0], variables[1],
                variables[2], variables[3], c, n) != 3097)
            {
                result = false;
            }
            Assert.True(result);
        }

        [Fact]
        public void Calculate_OutputIsInfinity_ReturnsTrue()
        {
            double?[] variables = new double?[4];
            int c = 0, n = 0;
            bool result = true;

            for (int i = 0; i < 4; i++)
            {
                c = 2;
                n = 3;
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) variables[j] = Double.PositiveInfinity;
                    else variables[j] = 25;
                }
                if (Solver.Calculate(variables[0], variables[1],
                    variables[2], variables[3], c, n) != null)
                {
                    result = false;
                }
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) variables[j] = Double.NegativeInfinity;
                    else variables[j] = 25;
                }
                if (Solver.Calculate(variables[0], variables[1],
                    variables[2], variables[3], c, n) != null)
                {
                    result = false;
                }
            }
            Assert.True(result);
        }
    }
}
