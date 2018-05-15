using System.Linq;
using CodeTrain.DataAlg;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_LinkedList
    {
        [Fact]
        public void Test_LinkedList_Add()
        {
            var list = new VLinkedList<int>();
            Assert.Equal(0, list.Count());
            list.Add(1);
            Assert.Equal(1, list.Count());
            Assert.Equal(1, list.First());
            Assert.Equal(1, list.Last());

            list.Add(2);
            Assert.Equal(2, list.Count());
            Assert.Equal(1, list.First());
            Assert.Equal(2, list.Last());

            list.Add(3);
            Assert.Equal(3, list.Count());
            Assert.Equal(1, list.First());
            Assert.Equal(3, list.Last());

        }

        [Fact]
        public void Test_LinkedList_Delete()
        {
            var list = new VLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.Equal(3, list.Count());
            Assert.Equal(1, list.First());
            Assert.Equal(3, list.Last());

            list.Delete(4);
            Assert.Equal(3, list.Count());
            Assert.Equal(1, list.First());
            Assert.Equal(3, list.Last());


            list.Delete(2);
            Assert.Equal(2, list.Count());
            Assert.Equal(1, list.First());
            Assert.Equal(3, list.Last());

            list.Delete(1);
            Assert.Equal(1, list.Count());
            Assert.Equal(3, list.First());
            Assert.Equal(3, list.Last());

            list.Delete(3);
            Assert.Equal(0, list.Count());
            Assert.Equal(0, list.First());
            Assert.Equal(0, list.Last());

            list.Add(4);
            list.Add(5);
            list.Add(6);
            Assert.Equal(3, list.Count());
            Assert.Equal(4, list.First());
            Assert.Equal(6, list.Last());

            list.Delete(4);
            Assert.Equal(2, list.Count());
            Assert.Equal(5, list.First());
            Assert.Equal(6, list.Last());

            list.Delete(6);
            Assert.Equal(1, list.Count());
            Assert.Equal(5, list.First());
            Assert.Equal(5, list.Last());

            list.Delete(5);
            Assert.Equal(0, list.Count());
            Assert.Equal(0, list.First());
            Assert.Equal(0, list.Last());
        }

        [Fact]
        public void Test_LinkedList_Enumerate()
        {
            var list = new VLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var j = 1;
            foreach (var i in list)
            {
                Assert.Equal(j++, i);
            }

        }
    }
}