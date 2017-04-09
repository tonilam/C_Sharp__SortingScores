using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingScores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingScores.Tests {
    [TestClass()]
    public class ScoreComparerTests {
        [TestMethod()]
        public void CompareTest() {
            ScoreComparer sc = new ScoreComparer();
            scoreRecord smallerScore = new scoreRecord();
            scoreRecord largerScore = new scoreRecord();

            smallerScore.firstName = "ABC";
            smallerScore.lastName = "XYZ";
            smallerScore.score = 80;

            largerScore.firstName = "ABC";
            largerScore.lastName = "XYZ";
            largerScore.score = 99;

            Assert.AreEqual(sc.Compare(smallerScore, largerScore), 1);
            Assert.AreEqual(sc.Compare(largerScore, smallerScore), -1);
            Assert.AreEqual(sc.Compare(largerScore, largerScore), 0);
        }
    }
}