using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionHandling;
using System.Data;
using System;

namespace MoodAnalyzerUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TC1_1_SadMood()
        {
            //Access
            string expected = "Sad";
            string message = "I am in a Sad mood";

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        public void TC1_2_AnyMood()
        {
            //Access
            string expected = "Happy";
            string message = "I am in a any mood";

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        public void RefactorTC1_1_SadMood()
        {
            //Access
            string expected = "Sad";
            string message = "I am in a Sad mood";

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        public void RefactorTC1_2_HappyMood()
        {
            //Access
            string expected = "Happy";
            string message = "I am in a Happy mood";

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        public void TC2_1_NulltoHappy()
        {
            //Access
            string expected = "Happy";
            string message = null;

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow(null)]
        public void TC2_1_NulltoHappy_WithException(string message)
        {
            //Access
            string expected = "Happy";
            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood_WithException(message);

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        public void TC3_1_NullException()
        {
            try
            {
                string message = null;
                MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);
                string mood = moodAnalyse.AnalyseMood_withCustomException(message);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }

        }
        [TestMethod]
        public void TC3_2_EmptyException()
        {
            try
            {
                string message = "";
                MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);
                string mood = moodAnalyse.AnalyseMood_withCustomException(message);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }

        }
    }
}