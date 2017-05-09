using MerchantGuideToGalaxy.Core;
using Xunit;

namespace MerchantGuideToGalaxy.UnitTest
{

    /// <summary>
    /// Testes de Parse
    /// </summary>
    public class QuestionParserTest
    {
        /// <summary>
        /// Conversão de algarismos romanos para decimais
        /// </summary>
        [Theory(DisplayName = "Dirty Assignment")]
        [InlineData("glob is I", 1)]
        [InlineData("prok is V", 5)]
        [InlineData("pish is X", 10)]
        [InlineData("tegj is L", 50)]
        public void DirtyAssigment(string evaluate, decimal result)
        {
            var converter = new IntergalaticConverter();
            var questionParser = new QuestionParser(converter);
            questionParser.Evaluate(evaluate);
            var value = converter.ConvertIntergalaticToCredits(evaluate.Split(' ')[0]);
            Assert.Equal(result, value);
        }

        /// <summary>
        /// Conversão de algarismos romanos para decimais
        /// </summary>
        [Theory(DisplayName = "Metal Assignment")]
        [InlineData("glob glob Silver is 34 Credits", "Silver", 17)]
        [InlineData("glob prok Gold is 57800 Credits","Gold",  14450)]
        [InlineData("pish pish Iron is 3910 Credits", "Iron", 195.5)]
        public void MetalAssignment(string evaluate, string metal, decimal result)
        {
            var converter = new IntergalaticConverter();
            converter.AddQuotationDirt("glob", "I");
            converter.AddQuotationDirt("prok", "V");
            converter.AddQuotationDirt("pish", "X");
            converter.AddQuotationDirt("tegj", "L");

            var questionParser = new QuestionParser(converter);
            questionParser.Evaluate(evaluate);

            var quotation = converter.GetQuotationMetal(metal);
            Assert.Equal(result, quotation);
        }

        /// <summary>
        /// Checagem de queries inválidas
        /// </summary>
        [Theory(DisplayName = "Invalid Query")]
        [InlineData("how much is pish tegj glob glob glob glob ?")]
        [InlineData("how many Credits is nothing ?")]
        public void InvalidQuery(string query)
        {
            var converter = new IntergalaticConverter();
            var questionParser = new QuestionParser(new IntergalaticConverter());
            questionParser.Evaluate("glob is I");
            questionParser.Evaluate("prok is V");
            questionParser.Evaluate("pish is X");
            questionParser.Evaluate("tegj is L");
            questionParser.Evaluate("glob glob Silver is 34 Credits");
            questionParser.Evaluate("glob prok Gold is 57800 Credits");
            questionParser.Evaluate("pish pish Iron is 3910 Credits");

            var invalid = questionParser.Evaluate(query);
            Assert.Equal("Invalid query", invalid);
        }

    }


}
