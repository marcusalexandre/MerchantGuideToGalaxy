using MerchantGuideToGalaxy.Core.RomanExpressions;
using MerchantGuideToGalaxy.Core.IntergalaticExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchantGuideToGalaxy.Core
{

    /// <summary>
    /// Conversor intergalatico
    /// </summary>
    public class IntergalaticConverter
    {
        private readonly IDictionary<string, IntergalaticExpression> _intergalaticExpressions = new Dictionary<string, IntergalaticExpression>();
        private readonly IDictionary<string, string> _quotationsDirt = new Dictionary<string, string>();

        private static readonly RomanExpression[] RomanExpressionTree =
            new RomanExpression[] {
                new ThousandExpression(),
                new HundredExpression(),
                new TenExpression(),
                new OneExpression()
            };


        public void AddQuotationDirt(string dirtValue, string romanValue)
            => _quotationsDirt[dirtValue] = romanValue;

        public void AddQuotationMetal(string metalValue, decimal multiplier)
            => _intergalaticExpressions[metalValue] = new CustomExpression(metalValue, multiplier);


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
            foreach (var customExpression in _intergalaticExpressions.Values)
            {
                if (context.Input.Contains(customExpression.Name()))
                {
                    customExpression.Interpret(context, _quotationsDirt);
                    break;
                }
            }
            var expression = new EmptyExpression();
            expression.Interpret(context, _quotationsDirt);
            return context.Output;
        }


        /// <summary>
        /// Retorna fator de cotação do metal
        /// </summary>
        public decimal GetQuotationMetal(string metal)
            => _intergalaticExpressions[metal].Multiplier();

        /// <summary>
        /// Retorna verdade se o valor é uma terra
        /// </summary>
        public bool IsDirt(string value)
            => _quotationsDirt.ContainsKey(value);

        /// <summary>
        /// Intergalático para decimal com metais
        /// </summary>
        public decimal ConvertIntergalaticToCredits(string intergalatic)
        {
            var context = new Context<string>(intergalatic);
            foreach (var expression in _intergalaticExpressions.Values.Union(new[] { new EmptyExpression() }))
            {
                if (context.Input.Contains(expression.Name()))
                {
                    expression.Interpret(context, _quotationsDirt);
                    var roman = (decimal) ConvertRomanToCredits(context.Output);
                    return roman * expression.Multiplier(); 
                }
            }
            throw new Exception();
        }
    }
}
