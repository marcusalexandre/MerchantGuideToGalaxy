using System.Text;

namespace MerchantGuideToGalaxy.Core
{

    public abstract class IntergalaticExpression
    {
        public const string IntergalaticOne = "glob";
        public const string IntergalaticFive = "prok";
        public const string IntergalaticTen = "pish";
        public const string IntergalaticFifty = "tegj";

        public void Interpret(Context<string> context)
        {
            if (context.Input?.Length <= 0)
                return;

            var roman = new StringBuilder();
            foreach (var expression in context.Input.ToLower().Split(' '))
            {
                switch (expression)
                {
                    case IntergalaticOne:
                        roman.Append(RomanExpression.RomanOne);
                        break;
                    case IntergalaticFive:
                        roman.Append(RomanExpression.RomanFive);
                        break;
                    case IntergalaticTen:
                        roman.Append(RomanExpression.RomanTen);
                        break;
                    case IntergalaticFifty:
                        roman.Append(RomanExpression.RomanFifty);
                        break;
                }
            }
            context.Output = roman.ToString();
        }

        public abstract string Name();

        public abstract decimal Multiplier();

    }
}
