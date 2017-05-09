using MerchantGuideToGalaxy.Core.RomanExpressions;
using MerchantGuideToGalaxy.Core.IntergalaticExpressions;

namespace MerchantGuideToGalaxy.Core
{

    /// <summary>
    /// Conversor intergalatico
    /// </summary>
    public class IntergalaticConverter
    {
        private static readonly RomanExpression[] RomanExpressionTree =
            new RomanExpression[] {
                new ThousandExpression(),
                new HundredExpression(),
                new TenExpression(),
                new OneExpression()
            };

        private static readonly IntergalaticExpression[] IntergalaticExpressionTree =
            new IntergalaticExpression[]
        {
                new GoldExpression(),
                new SilverExpression(),
                new IronExpression(),
                new EmptyExpression()
        };


        /// <summary>
        /// Romanos para decimal
        /// </summary>
        public int ConvertRomanToCredits(string roman)
        {
            var context = new Context<int>(roman);
            foreach (var expression in RomanExpressionTree)
            {
                expression.Interpret(context);
            }
            return context.Output;
        }

        /// <summary>
        /// Intergalático para romano
        /// </summary>
        public string ConvertIntergalaticToRoman(string intergalatic)
        {
            var context = new Context<string>(intergalatic);
            foreach (var expression in IntergalaticExpressionTree)
            {
                if (context.Input.Contains(expression.Name()))
                {
                    expression.Interpret(context);
                    break;
                }
            }
            return context.Output;
        }

        /// <summary>
        /// Intergalático para decimal com metais
        /// </summary>
        public decimal ConvertIntergalaticToCredits(string intergalatic)
        {
            var context = new Context<string>(intergalatic);
            foreach (var expression in IntergalaticExpressionTree)
            {
                if (context.Input.Contains(expression.Name()))
                {
                    expression.Interpret(context);
                    var roman = (decimal) ConvertRomanToCredits(context.Output);
                    return roman * expression.Multiplier(); 
                }
            }
            throw new System.Exception();
        }
    }
}
