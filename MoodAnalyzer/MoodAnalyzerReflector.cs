using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExceptionHandling
{
    public class MoodAnalyzerReflector
    {
        public static string InvokeAnalyseMood(string className, string constuctor, string message, string methodName)
        {
            //Get the instance of the MoodAnalyserClass and create a constructor
            object moodAnalysis = MoodAnalyzerFactory.CreateMoodAnalyseWithParameter(className, constuctor, message);
            Type type = typeof(MoodAnalyzer);
            try
            {
                //Fetching the method info using reflection
                MethodInfo methodInfo = type.GetMethod(methodName);
                //Invoking the method of Mood Analyser Class
                Object obj = methodInfo.Invoke(moodAnalysis, null);
                return obj.ToString().ToUpper();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
        }

        public static string SetField(string message, string fieldName)
        {
            try
            {
                //object of class
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer();

                // Get the type of the class
                Type type = typeof(MoodAnalyzer);

                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName);
                if (message == null)
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be NULL");

                // set the field value of a particular field in particular object
                fieldInfo.SetValue(moodAnalyzer, message);

                return moodAnalyzer.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_FIELD, "Field is not found");

            }
        }
    }
}