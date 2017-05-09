using MerchantGuideToGalaxy.Core;
using System;

namespace MerchantGuideToGalaxy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var questionParser = new QuestionParser(new IntergalaticConverter());
            questionParser.Evaluate("glob is I");
            questionParser.Evaluate("prok is V");
            questionParser.Evaluate("pish is X");
            questionParser.Evaluate("tegj is L");
            questionParser.Evaluate("glob glob Silver is 34 Credits");
            questionParser.Evaluate("glob prok Gold is 57800 Credits");
            questionParser.Evaluate("pish pish Iron is 3910 Credits");

            System.Console.WriteLine(questionParser.Evaluate("how much is pish tegj glob glob ?"));
            System.Console.WriteLine(questionParser.Evaluate("how many Credits is glob prok Silver ?"));
            System.Console.WriteLine(questionParser.Evaluate("how many Credits is glob prok Gold ?"));
            System.Console.WriteLine(questionParser.Evaluate("how many Credits is glob prok Iron ?"));
            System.Console.WriteLine(questionParser.Evaluate("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));

            System.Console.ReadKey();
        }
    }
}