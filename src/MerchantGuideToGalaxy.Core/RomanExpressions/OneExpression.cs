namespace MerchantGuideToGalaxy.Core.RomanExpressions
{
    class OneExpression : RomanExpression
    {
        public override string One() => RomanOne;
        public override string Four() => $"{RomanOne}{RomanFive}";
        public override string Five() => RomanFive;
        public override string Nine() => $"{RomanOne}{RomanTen}";
        public override int Multiplier() => 1;
    }
}
