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
        [TestMethod]
        /// Proper className
        public void TC4_1_ClassNameReturnsObject()
        {
            object expected = new MoodAnalyzer();
            object obj = MoodAnalyzerFactory.CreateMoodAnalyse("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        [TestMethod]
        /// ImProper className
        public void TC4_2_ClassNameReturnsObject_WithException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("ExceptionHandling.ModAnalyzer", "MoodAnalyzer");
                expected.Equals(obj);
            }
            catch(MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such class", e.Message);
            }
        }
        /*[TestMethod]
        /// ImProper constructorName
        public void TC4_3_ConstructorNameReturnsObject_WithException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("ExceptionHandling.MoodAnalyzer", "ModAnalyzer");
                expected.Equals(obj);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such constructor", e.Message);
            }
        }*/
        [TestMethod]
        /// Proper className
        public void RefactorTC4_1_ClassNameReturnsObject()
        {
            object expected = new MoodAnalyzer();
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithoutAssembly("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        [TestMethod]
        /// ImProper className
        public void RefactorTC4_2_ClassNameReturnsObject_WithException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithoutAssembly("ExceptionHandling.ModAnalyzer", "MoodAnalyzer");
                expected.Equals(obj);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }
        [TestMethod]
        /// ImProper constructorName
        public void RefactorTC4_3_ConstructorNameReturnsObject_WithException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithoutAssembly("ExceptionHandling.MoodAnalyzer", "ModAnalyzer");
                expected.Equals(obj);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such constructor found", e.Message);
            }
        }
    }
}