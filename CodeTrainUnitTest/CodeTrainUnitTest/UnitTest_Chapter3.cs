using System;
using CodeTrain.DataAlg;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_Chapter3
    {
        [Fact]
        public void Test_Min()
        {
            var stack = new VStack<int>();
            stack.Push(2);
            stack.Push(3);
            stack.Push(1);
            stack.Push(4);
            Assert.Equal(1, stack.Min());
        }

        [Fact]
        public void Test_Push()
        {
            var stack = new VStack<int>(3);
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Assert.Equal(5, stack.Count());
        }

        [Fact]
        public void Test_Pop()
        {
            var stack = new VStack<int>(3);
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Assert.Equal(5, stack.Pop());
            Assert.Equal(4, stack.Pop());
            Assert.Equal(3, stack.Pop());
            Assert.Equal(0, stack.Pop());
            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }
    }
}