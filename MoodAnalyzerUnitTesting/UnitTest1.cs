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
    }
}