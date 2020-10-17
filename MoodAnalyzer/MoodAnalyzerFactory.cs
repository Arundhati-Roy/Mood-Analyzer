using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor");
                }
                catch (MissingMethodException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such method");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such class");
            }

        }
        public static object CreateMoodAnalyseWithoutAssembly(string className, string constructorName)
        {
            // getting the type of MoodAnalyserClass
            Type type = typeof(MoodAnalyzer);
            //If the class name exists in given assembly
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                //If the constructor passed is correct
                if (type.Name.Equals(constructorName))
                {
                    return Activator.CreateInstance(type);
                }
                //If the constructor passed doesnt exist then throw error
                else
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
            }
            //If the class passed doesnt exist throw custom exception
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }

        }
        public static object CreateMoodAnalyseWithParameter(string className, string constructorName,string message)
        {
            // getting the type of MoodAnalyserClass
            Type type = typeof(MoodAnalyzer);
            //If the class name exists in given assembly
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                //If the constructor passed is correct
                if (type.Name.Equals(constructorName))
                {
                    return Activator.CreateInstance(type,message);
                }
                //If the constructor passed doesnt exist then throw error
                else
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
            }
            //If the class passed doesnt exist throw custom exception
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }

        }
    }
}

