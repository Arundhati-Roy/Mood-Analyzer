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
            catch (MoodAnalyzerCustomException e)
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
        [TestMethod]
        /// Proper ClassName Returns object
        public void TC5_1ReturnObject()
        {
            //Arrange
            object expected = new MoodAnalyzer();
            //Act
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithParameter("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer", "I am in happy mood today");
            //Assert
            expected.GetType().Equals(obj.GetType());
        }
        [TestMethod]
        /// ImProper ClassName with Exception
        public void TC5_2ReturnObject()
        {
            try
            {
                //Arrange
                object expected = new MoodAnalyzer();
                //Act
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithParameter("ExceptionHandling.Mo0dAnalyzer", "MoodAnalyzer", "I am in happy mood today");
                //Assert
                expected.GetType().Equals(obj.GetType());
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }
        [TestMethod]
        /// ImProper ConstructorName with Exception
        public void TC5_3ReturnObject()
        {
            try
            {
                //Arrange
                object expected = new MoodAnalyzer();
                //Act
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithParameter("ExceptionHandling.MoodAnalyzer", "M0odAnalyzer", "I am in happy mood today");
                //Assert
                expected.GetType().Equals(obj.GetType());
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such constructor found", e.Message);
            }
        }
        /// <summary>
        /// TC 6.1 When we give right class name, constructor name and message passed as happy mood and valid method name then should return HAPPY
        /// </summary>
        [TestMethod]
        public void TC6_1_HappyReturnsHappy()
        {
            //Arrange
            MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in happy mood today");
            //Act
            string actual = MoodAnalyzerReflector.InvokeAnalyseMood("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer", "I am in happy mood today", "AnalyseMood");
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }

        /// <summary>
        /// TC 6.2 When we give right class name, constructor name and message passed as happy mood and invalid method name then should throw exception 
        /// </summary>
        [TestMethod]
        public void TC6_2_InvalidThrowsException()
        {
            //Act
            try
            {
                MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in happy mood today");
                object expected = moodAnalyser.AnalyseMood();
                object actual = MoodAnalyzerReflector.InvokeAnalyseMood("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer", "I am in happy mood today", "InvalidMethod");
            }
            //Assert
            catch (MoodAnalyzerCustomException exception)
            {
                Assert.AreEqual("No such method found", exception.Message);
            }
        }

        /// <summary>
        /// TC 6.3 When we give right class name, constructor name and message passed as null and valid method name then should throw exception 
        /// </summary>
        [TestMethod]
        public void TC6_3_NullThrowsException()
        {
            //Act
            try
            {
                MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in happy mood today");
                object expected = moodAnalyser.AnalyseMood();
                object actual = MoodAnalyzerReflector.InvokeAnalyseMood("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer", null, "AnalyseMood");
            }
            //Assert
            catch (MoodAnalyzerCustomException exception)
            {
                Assert.AreEqual("Mood should not be null", exception.Message);
            }
        }
        /// <summary>
        /// TC 7.1 When given proper fieldName and a mood message for happy mood then should return HAPPY
        /// </summary>

        [TestMethod]
        public void TC7_1_ChangeMoodDynamicallyForValidFieldName()
        {
            // ACT
            string actual = MoodAnalyzerReflector.SetField("HAPPY", "message");

            // Assert
            Assert.AreEqual("HAPPY", actual);
        }

        /// <summary>
        ///  TC 7.2 When given wrong fieldName and a happy mood message then should throw exception
        /// </summary>
        [TestMethod]
        public void TC7_2_ChangeMoodDynamicallyInValid()
        {
            try
            {
                // ACT
                string actual = MoodAnalyzerReflector.SetField("I am in happy mood today", "InvalidField");
            }
            catch (MoodAnalyzerCustomException exception)
            {
                // Assert
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }

        /// <summary>
        /// TC 7.3 When given correct fieldName and passing a null mood message then throw error that Mood should not be NULL
        /// </summary>
        [TestMethod]
        public void TC7_3_ChangeMoodDynamicallySetNull()
        {
            try
            {
                // ACT
                string actual = MoodAnalyzerReflector.SetField(null, "message");
            }
            catch (MoodAnalyzerCustomException exception)
            {
                // Assert
                Assert.AreEqual("Mood should not be NULL", exception.Message);
            }
        }
    }
}
