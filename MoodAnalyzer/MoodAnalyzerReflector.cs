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
    }
}
