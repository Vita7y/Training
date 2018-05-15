using System;
using System.Collections.Generic;
using CodeTrain;
using Xunit;

namespace CodeTrainUnitTest
{
    public class TestCountryTravelRoute
    {
        [Fact]
        public void TestIFindRout()
        {
            var ctr = new TravelRoute();

            ctr.LoadRoutes(new List<(string from, string to)>()
            {
                ("Мельбурн", "Кельн"),
                ("Москва", "Париж"),
                ("Кельн", "Москва")
            });

            var res = ctr.FindRoute("Мельбурн", "Париж");
            Assert.NotNull(res);
            Assert.Equal(3, res.Count);
            Assert.Equal(("Мельбурн", "Кельн"), res[0]);
            Assert.Equal(("Кельн", "Москва"), res[1]);
            Assert.Equal(("Москва", "Париж"), res[2]);
        }

        [Fact]
        public void TestGetRoutBetween3Cities()
        {
            var ctr = new TravelRoute();

            ctr.LoadRoutes(new List<(string from, string to)>()
            {
                ("Мельбурн", "Кельн"),
                ("Москва", "Париж"),
                ("Кельн", "Москва")
            });

            var res = ctr.GetRoute();
            Assert.NotNull(res);
            Assert.Equal(3, res.Count);
            Assert.Equal(("Мельбурн", "Кельн"), res[0]);
            Assert.Equal(("Кельн", "Москва"), res[1]);
            Assert.Equal(("Москва", "Париж"), res[2]);
        }

        [Fact]
        public void TestGetRoutBetween5Cities()
        {
            var ctr = new TravelRoute();

            ctr.LoadRoutes(new List<(string from, string to)>()
            {
                ("Париж", "NY"),
                ("Мельбурн", "Кельн"),
                ("NY", "San Francisco"),
                ("Москва", "Париж"),
                ("Кельн", "Москва")
            });

            var res = ctr.GetRoute();
            Assert.NotNull(res);
            Assert.Equal(5, res.Count);
            Assert.Equal(("Мельбурн", "Кельн"), res[0]);
            Assert.Equal(("Кельн", "Москва"), res[1]);
            Assert.Equal(("Москва", "Париж"), res[2]);
            Assert.Equal(("Париж", "NY"), res[3]);
            Assert.Equal(("NY", "San Francisco"), res[4]);
        }

        [Fact]
        public void TestLoadIncorrectRoutes()
        {
            var ctr = new TravelRoute();

            Assert.Throws<ArgumentNullException>(() => ctr.LoadRoutes(null));
            Assert.Throws<ArgumentNullException>(() =>
                ctr.LoadRoutes(new List<(string from, string to)>()
                {
                    ("Мельбурн", "Кельн"),
                    ("Москва", null),
                    ("Кельн", "Москва")
                }));
            Assert.Throws<ArgumentNullException>(() =>
                ctr.LoadRoutes(new List<(string from, string to)>()
                {
                    ("Мельбурн", "Кельн"),
                    ("Москва", ""),
                    ("Кельн", "Москва")
                }));

        }

        [Fact]
        public void TestRoutNotFound()
        {
            var ctr = new TravelRoute();

            ctr.LoadRoutes(new List<(string from, string to)>()
            {
                ("Мельбурн", "Кельн"),
                ("Москва", "Париж"),
                ("Тверь", "Москва")
            });

            var res = ctr.FindRoute("Мельбурн", "Париж");
            Assert.Empty(res);
        }

        [Fact]
        public void TestNotFullRout()
        {
            var ctr = new TravelRoute();

            ctr.LoadRoutes(new List<(string from, string to)>()
            {
                ("Мельбурн", "Кельн"),
                ("Москва", "Париж"),
                ("Тверь", "Москва")
            });

            var res = ctr.GetRoute();
            Assert.Null(res);
        }
    }
}