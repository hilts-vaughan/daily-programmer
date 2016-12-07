using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace Daily20161205
{
    public class Tests
    {

        [Fact]
        public void TestWordWithMultipleOfOneLetterButMissingAtLeastOneInTheTiles()
        {
            var word = "pizza";
            var tiles = "azip";
            Assert.Equal(false, Scrabble.CanFormWordWithTiles(word, tiles));
        }

        [Fact]
        public void TestWordCanBeBuiltWithExcessTiles()
        {
            var word = "pizza";
            var tiles = "ppiizzaaaaaaa";
            Assert.Equal(true, Scrabble.CanFormWordWithTiles(word, tiles));
        }

        [Fact]
        public void TestWordCanBeFormedWithJustEnoughLetters()
        {
            var word = "pizza";
            var tiles = "azzipa";
            Assert.Equal(true, Scrabble.CanFormWordWithTiles(word, tiles));
        }

        [Fact]
        public void TestCanBuildWordWithWildcard()
        {
            var word = "smaller";
            var tiles = "small??";
            Assert.Equal(true, Scrabble.CanFormWordWithTiles(word, tiles));
        }


        [Fact]
        public void TestCannotBuildWordWithoutEnoughWildCards()
        {
            var word = "smaller";
            var tiles = "smla?";
            Assert.Equal(false, Scrabble.CanFormWordWithTiles(word, tiles));
        }

        [Fact]
        public void RedditTestCasesThatShouldPass()
        {
            foreach (var truthCase in TruthCases())
            {
                var test = Scrabble.CanFormWordWithTiles(truthCase.Item2, truthCase.Item1);
                Assert.Equal(true, test);
            }
        }

        [Fact]
        public void RedditTestCasesThatShouldFail()
        {
            foreach (var truthCase in FailureCases())
            {
                var test = Scrabble.CanFormWordWithTiles(truthCase.Item2, truthCase.Item1);
                Assert.Equal(false, test);
            }
        }

        public static IEnumerable<Tuple<string, string>> TruthCases()
        {
            return new List<Tuple<string, string>>
            {
                Tuple.Create("ladilmy", "daily"),
                Tuple.Create("orrpgma", "program"),
                Tuple.Create("pizza??", "pizzazz"),
                Tuple.Create("a??????", "program"),
            };
        }


        public static IEnumerable<Tuple<string, string>> FailureCases()
        {
            return new List<Tuple<string, string>>
            {
                Tuple.Create("pizza?", "pizzazz"),
                Tuple.Create("eerriin", "eerie"),
                Tuple.Create("orppgma", "program"),
                Tuple.Create("b??????", "program"),
            };
        }
    }
}