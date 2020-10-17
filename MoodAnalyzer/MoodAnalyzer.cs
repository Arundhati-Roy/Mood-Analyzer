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
            if (this.message.Contains("Sad"))
                return "Sad";
            else
                return "Happy";
        }
    }
}