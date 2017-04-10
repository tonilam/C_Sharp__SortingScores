using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingScores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingScores.Tests {
    /**
     * ScoreComparerTests is a unit test class to test all public methods in the
     * namespace SortingScores.
     * 
     * Author: Toni Lam
     * Date: 10 April 2017
     */
    [TestClass()]
    public class ScoreComparerTests {

        /**
         * To test if the compare method from ScoreComparer can return the correct
         * value:
         * if 1st score is greater than the second score > return positive value
         * if 1st score is smaller than the second score > return negative value
         * if 1st score is equal to the second score > return 0
         */
        [TestMethod()]
        public void CompareTestDifferentScores() {
            ScoreComparer sc = new ScoreComparer();
            scoreRecord higherPositionCandidate = new scoreRecord();
            scoreRecord lowerPositionCandidate = new scoreRecord();

            higherPositionCandidate.firstName = "ABC";
            higherPositionCandidate.lastName = "XYZ";
            higherPositionCandidate.score = 99;

            lowerPositionCandidate.firstName = "ABC";
            lowerPositionCandidate.lastName = "XYZ";
            lowerPositionCandidate.score = 80;

            Assert.IsTrue(sc.Compare(lowerPositionCandidate, higherPositionCandidate) > 0);
            Assert.IsTrue(sc.Compare(higherPositionCandidate, lowerPositionCandidate) < 0);
            Assert.IsTrue(sc.Compare(higherPositionCandidate, higherPositionCandidate) == 0);
        }

        /**
         * To test if the compare method from ScoreComparer can return the correct
         * value, given that the scores are equal:
         * if 1st last name is greater than the 2nd last name > return positive value
         * if 1st last name is smaller than the 2nd last name > return negative value
         * if 1st last name is equal to the 2nd last name > return 0
         */
        [TestMethod()]
        public void CompareTestSameScoresDifferntLastName() {
            ScoreComparer sc = new ScoreComparer();
            scoreRecord higherPositionCandidate = new scoreRecord();
            scoreRecord lowerPositionCandidate = new scoreRecord();

            higherPositionCandidate.firstName = "ABC";
            higherPositionCandidate.lastName = "LMN";
            higherPositionCandidate.score = 50;

            lowerPositionCandidate.firstName = "ABC";
            lowerPositionCandidate.lastName = "XYZ";
            lowerPositionCandidate.score = 50;

            Assert.IsTrue(sc.Compare(lowerPositionCandidate, higherPositionCandidate) > 0);
            Assert.IsTrue(sc.Compare(higherPositionCandidate, lowerPositionCandidate) < 0);
            Assert.IsTrue(sc.Compare(higherPositionCandidate, higherPositionCandidate) == 0);
        }


        /**
         * To test if the compare method from ScoreComparer can return the correct
         * value, given that the scores and last name are both equal:
         * if 1st first name is greater than the 2nd first name > return positive value
         * if 1st first name is smaller than the 2nd first name > return negative value
         * if 1st first name is equal to the 2nd first name > return 0
         */
        [TestMethod()]
        public void CompareTestSameScoresAndLastNameDifferntFirstName() {
            ScoreComparer sc = new ScoreComparer();
            scoreRecord higherPositionCandidate = new scoreRecord();
            scoreRecord lowerPositionCandidate = new scoreRecord();

            higherPositionCandidate.firstName = "ABC";
            higherPositionCandidate.lastName = "XYZ";
            higherPositionCandidate.score = 50;

            lowerPositionCandidate.firstName = "DEF";
            lowerPositionCandidate.lastName = "XYZ";
            lowerPositionCandidate.score = 50;

            Assert.IsTrue(sc.Compare(lowerPositionCandidate, higherPositionCandidate) > 0);
            Assert.IsTrue(sc.Compare(higherPositionCandidate, lowerPositionCandidate) < 0);
            Assert.IsTrue(sc.Compare(higherPositionCandidate, higherPositionCandidate) == 0);
        }
    }
}