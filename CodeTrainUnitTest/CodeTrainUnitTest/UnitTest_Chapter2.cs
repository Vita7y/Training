using CodeTrain;
using CodeTrain.DataAlg;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_Chapter2
    {
        /// <summary>
        /// Chapter2 2.1
        /// </summary>
        [Fact]
        public void Test_DeleteDublicates()
        {
            var str = Chapter2LinkedLists.DeleteDublicate("abcd");
            Assert.Equal("abcd", str);
            str = Chapter2LinkedLists.DeleteDublicate("abcbdb");
            Assert.Equal("abcd", str);
            str = Chapter2LinkedLists.DeleteDublicate("abcbcbcbcbcbcbcdbbb");
            Assert.Equal("abcd", str);
        }

        /// <summary>
        /// Chapter2 2.2
        /// </summary>
        [Fact]
        public void Test_GetElementFromEnd()
        {
            var list = new VLinkedList<char>();
            list.Add("abcdefg".ToCharArray());
            var ch = Chapter2LinkedLists.GetElementFromEnd(list, 0);
            Assert.Equal('g', ch);
            ch = Chapter2LinkedLists.GetElementFromEnd(list, 6);
            Assert.Equal('a', ch);
            ch = Chapter2LinkedLists.GetElementFromEnd(list, 3);
            Assert.Equal('d', ch);
        }

    }
}