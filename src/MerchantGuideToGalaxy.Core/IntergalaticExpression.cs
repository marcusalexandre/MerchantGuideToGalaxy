using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxy.Core
{

    public abstract class IntergalaticExpression
    {

        public void Interpret(Context<string> context, IDictionary<string, string> quotation)
        {
            if (context.Input?.Length <= 0)
                return;

            var roman = new StringBuilder();
            foreach (var expression in context.Input.Split(' '))
            {
                if (quotation.ContainsKey(expression))
                {
                    roman.Append(quotation[expression]);
                }
                else if (expression != Name())
                {
                    throw new Exception($"Inválid expression {expression}");
                }
            }
            context.Output = roman.ToString();
        }

        public abstract string Name();

        public abstract decimal Multiplier();

    }
}
