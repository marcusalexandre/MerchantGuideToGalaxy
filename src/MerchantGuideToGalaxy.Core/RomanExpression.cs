using MerchantGuideToGalaxy.Core.RomanExpressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MerchantGuideToGalaxy.Core
{

    /// <summary>
    /// Interpretação de expressões romanas
    /// </summary>
    public abstract class RomanExpression
    {
        public const string RomanOne = "I";
        public const string RomanFive = "V";
        public const string RomanTen = "X";
        public const string RomanFifty = "L";
        public const string RomanHungred = "C";
        public const string RomanFiveHundred = "D";
        public const string RomanThousand = "M";

        public static readonly RomanExpression[] RomanTree = new RomanExpression[]
            {
                new ThousandExpression(),
                new HundredExpression(),
                new TenExpression(),
                new OneExpression()
            };
        private static readonly List<Regex> InvalidPatterns = new List<Regex>
        {
            new Regex(@"I{4,}|X{4,}|C{4,}|M{4,}"),
            new Regex(@"D{2,}|L{2,}|V{2,}"),
            new Regex(@"I[LCDM]"),
            new Regex(@"X[DM]"),
            new Regex(@"V[XLCDM]"),
            new Regex(@"L[CDM]"),
            new Regex(@"DM"),
            new Regex(@"I{2,}[VX]"),
            new Regex(@"X{2,}[LC]"),
            new Regex(@"C{2,}[DM]")
        };



        public void Interpret(Context<int> context)
        {
            if (!IsValid(context.Input))
                throw new System.Exception("Invalid Patterns");
            if (context.Input?.Length <= 0)
                return;

            if (context.Input.StartsWith(Nine(), System.StringComparison.CurrentCultureIgnoreCase))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(Nine().Length);
            }
            else if (context.Input.StartsWith(Four(), System.StringComparison.CurrentCultureIgnoreCase))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(Four().Length);
            }
            else if (context.Input.StartsWith(Five(), System.StringComparison.CurrentCultureIgnoreCase))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(Five().Length);
            }

            while (context.Input.StartsWith(One(), System.StringComparison.CurrentCultureIgnoreCase))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(One().Length);
            }
        }


        private bool IsValid(string expression)
        {
            foreach (var invalidPattern in InvalidPatterns)
            {
                if (invalidPattern.IsMatch(expression))
                    return false;
            }
            return true;
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }
}
