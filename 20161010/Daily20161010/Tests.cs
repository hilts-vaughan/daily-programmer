using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Daily20161010
{
    public class Tests
    {
        [Fact]
        public void ShouldNotPickZeroForNumbersSmallerThanOneThousand()
        {
            var number = 999;
            var c = KaprekarsComputor.GetMaximalDigitFromFourDigitNumber(number);
            Assert.Equal('9', c);
        }

        [Fact]
        public void ShouldPickNumberWhenAllSame()
        {
            var number = 1111;
            var c = KaprekarsComputor.GetMaximalDigitFromFourDigitNumber(number);
            Assert.Equal('1', c);
        }

        [Fact]
        public void ShouldPickHighestNumberWhenClose()
        {
            var number = 8889;
            var c = KaprekarsComputor.GetMaximalDigitFromFourDigitNumber(number);
            Assert.Equal('9', c);
        }

        [Fact]
        public void ShouldPickZeroForZero()
        {
            var number = 0;
            var c = KaprekarsComputor.GetMaximalDigitFromFourDigitNumber(number);
            Assert.Equal('0', c);
        }

        [Fact]
        public void ShouldIgnoreNegatives()
        {
            var number = -1234;
            var c = KaprekarsComputor.GetMaximalDigitFromFourDigitNumber(number);
            Assert.Equal('4', c);
        }

        [Fact]
        public void ShouldOrderDescendingProperly()
        {
            var number = 1234;
            var s = KaprekarsComputor.GetDigitsInDescendingOrder(number);
            Assert.Equal("4321", s);
        }

        [Fact]
        public void ShouldOrderDesendingNegativesProperly()
        {
            var number = -3456;
            var s = KaprekarsComputor.GetDigitsInDescendingOrder(number);
            Assert.Equal("6543", s);
        }

        [Fact]
        public void ShouldOrderPaddedNumbersProperly()
        {
            var number = 12;
            var s = KaprekarsComputor.GetDigitsInDescendingOrder(number);
            Assert.Equal("2100", s);
        }

        [Fact]
        public void DigitsInAscendingOrder()
        {
            var number = 12;
            var s = KaprekarsComputor.GetDigitsInAscendingOrder(number);
            Assert.Equal("0012", s);
        }

        [Fact]
        public void CountIterationsForRedditTestCases()
        {
            var cases = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(6589, 2),
                new Tuple<int, int>(5455, 5),
                new Tuple<int, int>(6174, 0)
            };

            cases.ForEach(x =>
            {
                var iterations = KaprekarsComputor.CountIterations(x.Item1);
                Assert.Equal(x.Item2, iterations);
            });
        }

    }
}