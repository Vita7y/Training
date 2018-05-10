using CodeTrain;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_Chapter2
    {
        [Fact]
        public void Test_DeleteDublicates()
        {
            var str = Chapter2LinkedLists.DeleteDublicate("abcd");
            Assert.Equal("abcd", str);
            str = Chapter2LinkedLists.DeleteDublicate("abbbcd");
            Assert.Equal("abcd", str);
            str = Chapter2LinkedLists.DeleteDublicate("abbbcccccdbbb");
            Assert.Equal("abcdb", str);
        }
    }
}