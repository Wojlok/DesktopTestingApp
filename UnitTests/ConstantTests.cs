using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace UnitTests
{
    public class ConstantTests
    {
        [Fact]
        public void GetListC_OutputItemIsMaxValue_ReturnsTrue()
        {
            int n = 0;
            bool result = true;
            n = int.MaxValue;
            foreach(var item in Constant.GetListC(n))
            {
                if (item == int.MaxValue) result = false; break;
            }
            Assert.True(result);
        }
    }
}