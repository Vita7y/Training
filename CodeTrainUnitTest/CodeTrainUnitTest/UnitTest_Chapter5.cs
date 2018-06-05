using System;
using System.Collections.Generic;
using CodeTrain;
using CodeTrain.DataAlg;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_Chapter5
    {
        [Fact]
        public void Test_InsertBitsIntoNumber()
        {
            int res;
            var r = Chapter5Bits.InsertBitsIntoNumber(1024, 19, 2, 6, out res);
            Assert.True(r);
            Assert.Equal(1100, res);
            r = Chapter5Bits.InsertBitsIntoNumber(257, 5, 4, 6, out res);
            Assert.True(r);
            Assert.Equal(337, res);
        }
    }
}