using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ExceptionHandling
{
    public class MoodAnalyzer
    {
        public string message;
        public MoodAnalyzer()
        {
            this.message = null;
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Contains("Sad"))
                    return "Sad";
                else
                    return "Happy";
            }
            catch (NullReferenceException)
            {
                return "Happy";
            }
        }
        public string AnalyseMood_WithException(string message)
        {
            try
            {
                if (this.message.Contains("Sad"))
                    return "Sad";
                else
                    return "Happy";
            }
            catch
            {
                return "Happy";
            }
        }
        public string AnalyseMood_withCustomException(string message)
        {
            try
            {
                if (this.message.Equals(""))
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                if (this.message.Contains("Sad"))
                    return "Sad";
                else
                    return "Happy";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
        }
    }
}