namespace MerchantGuideToGalaxy.Core.RomanExpressions
{
    class ThousandExpression : RomanExpression
    {
        public override string One() => RomanThousand;
        public override string Four() => " ";
        public override string Five() => " ";
        public override string Nine() => " ";
        public override int Multiplier() => 1000;
    }
}
