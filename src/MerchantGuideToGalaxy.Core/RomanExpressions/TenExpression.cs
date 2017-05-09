using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxy.Core.RomanExpressions
{
    class TenExpression : RomanExpression
    {
        public override string One() => RomanTen; 
        public override string Four() => $"{RomanTen}{RomanFifty}"; 
        public override string Five() => RomanFifty; 
        public override string Nine() => $"{RomanTen}{RomanHungred}"; 
        public override int Multiplier() => 10;
    }
}
