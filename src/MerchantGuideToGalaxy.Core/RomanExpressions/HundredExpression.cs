using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxy.Core.RomanExpressions
{
    class HundredExpression : RomanExpression
    {
        public override string One() => RomanHungred;
        public override string Four() => $"{RomanHungred}{RomanFiveHundred}";
        public override string Five() => $"{RomanFiveHundred}";
        public override string Nine() => $"{RomanHungred}{RomanThousand}";
        public override int Multiplier() => 100;

    }
}
