using MerchantGuideToGalaxy.Core;
using System;

namespace MerchantGuideToGalaxy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var questionParser = new QuestionParser();

            System.Console.WriteLine(questionParser.Evaluate("how much is pish tegj glob glob ?"));
            System.Console.WriteLine(questionParser.Evaluate("how many Credits is glob prok Silver ?"));
            System.Console.WriteLine(questionParser.Evaluate("how many Credits is glob prok Gold ?"));
            System.Console.WriteLine(questionParser.Evaluate("how many Credits is glob prok Iron ?"));
            System.Console.WriteLine(questionParser.Evaluate("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));

            System.Console.ReadKey();
        }
    }
}