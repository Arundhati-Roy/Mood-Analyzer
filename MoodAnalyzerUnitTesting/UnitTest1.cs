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
            //Assert
            string expected = "Sad";
            string message = "I am in a Sad mood";
            //string message = "I am in a Happy mood";
            //string message = null;

            MoodAnalyzer moodAnalyse = new MoodAnalyzer();

            //Act
            string mood = moodAnalyse.AnalyseMood(message);

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        public void TC1_2_AnyMood()
        {
            //Assert
            string expected = "Happy";
            string message = "I am in a any mood";
            //string message = "I am in a Happy mood";
            //string message = null;

            MoodAnalyzer moodAnalyse = new MoodAnalyzer();

            //Act
            string mood = moodAnalyse.AnalyseMood(message);

            //Assert
            Assert.AreEqual(expected, mood);

        }
    }
}