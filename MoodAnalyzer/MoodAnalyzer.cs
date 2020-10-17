using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ExceptionHandling
{
    public class MoodAnalyzer
    {
        public string message;
        
        public string AnalyseMood(string message)
        {
            if (message.Contains("Sad"))
                return "Sad";
            else
                return "Happy";
        }
    }
}