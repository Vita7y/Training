using System;
using CodeTrain;
using Xunit;

namespace CodeTrainUnitTest
{
    public class UnitTest_Chapter1
    {
        [Fact]
        public void Test_CharsCounter_AllCharsUnique()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal(true, ch1.CharsCounter_AllCharsUnique("aAbBcCdD"));
            Assert.Equal(false, ch1.CharsCounter_AllCharsUnique("aAbBcCdDaAbBcCdD"));
        }

        [Fact]
        public void Test_CharsCounter_AllCharsUnique2()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal(true, ch1.CharsCounter_AllCharsUnique2("aAbBcCdD"));
            Assert.Equal(false, ch1.CharsCounter_AllCharsUnique2("aAbBcCdDaAbBcCdD"));
        }

        [Fact]
        public void Test_CharsCounter_Sort()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal("abcd".ToCharArray(), ch1.Sort("bcda"));
            Assert.Equal("ABCDabcd".ToCharArray(), ch1.Sort("aBcDAbCd"));
        }

        [Fact]
        public void Test_CheckReversalStrings()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal(true, ch1.CheckReversalStrings("abcde","edcba"));
            Assert.Equal(false, ch1.CheckReversalStrings("abcde","edcab"));
        }

        [Fact]
        public void Test_ReplaceBlanks()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal("Mr\rJohn\rSmith", ch1.ReplaceBlanks("Mr John   Smith   ", (char) 13));
        }

        [Fact]
        public void Test_CheckPalindrome()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal(true, ch1.CheckPalindrome("tact coa", "tact coa"));
            Assert.Equal(true, ch1.CheckPalindrome("tact coa","taco cat"));
            Assert.Equal(true, ch1.CheckPalindrome("tact coa", "atco cta"));
            Assert.Equal(false, ch1.CheckPalindrome("tact coa", "atco ctc"));
            Assert.Equal(false, ch1.CheckPalindrome("tact coa", "tactcoa"));
        }

        [Fact]
        public void Test_CheckOneModification()
        {
            var ch1 = new Chapter1ArraysAndStrings();
            Assert.Equal(true, ch1.CheckOneModification("pale", "ple"));
            Assert.Equal(true, ch1.CheckOneModification("pales", "pale"));
            Assert.Equal(true, ch1.CheckOneModification("pale", "bale"));
            Assert.Equal(false, ch1.CheckOneModification("pale", "bake"));
        }

    }
}
