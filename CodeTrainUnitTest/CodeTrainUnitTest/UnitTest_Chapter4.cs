using System;
using System.Collections.Generic;
using CodeTrain;
using CodeTrain.DataAlg;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_Chapter4
    {
        [Fact]
        public void Test_Min()
        {
            var res = Chapter4Trees.FindRouteBetweenTwoPoints(new List<(string from, string to)>()
            {
                ("Мельбурн", "Кельн"),
                ("Москва", "Париж"),
                ("Кельн", "Москва")
            }, "Мельбурн", "Париж");

            Assert.NotNull(res);
            Assert.NotNull(res);
            Assert.Equal(3, res.Count);
            Assert.Equal(("Мельбурн", "Кельн"), res[2]);
            Assert.Equal(("Кельн", "Москва"), res[1]);
            Assert.Equal(("Москва", "Париж"), res[0]);
        }
    }
}