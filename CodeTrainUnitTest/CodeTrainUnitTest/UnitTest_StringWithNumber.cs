using CodeTrain;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_StringWithNumber
    {
        [Fact]
        public void Test_Incrace_000()
        {
            var res = StringWithNumber.Incrace("000");
            Assert.Equal("001", res);
        }

        [Fact]
        public void Test_Incrace_999()
        {
            var res = StringWithNumber.Incrace("999");
            Assert.Equal("000", res);
        }

        [Fact]
        public void Test_Incrace_A0B001()
        {
            var res = StringWithNumber.Incrace("A0B001");
            Assert.Equal("A0B002", res);
        }

        [Fact]
        public void Test_Incrace_A0B0129()
        {
            var res = StringWithNumber.Incrace("A0B0129");
            Assert.Equal("A0B0130", res);
        }

        [Fact]
        public void Test_Incrace_A0B999()
        {
            var res = StringWithNumber.Incrace("A0B999");
            Assert.Equal("A0B000", res);
        }

    }
}
