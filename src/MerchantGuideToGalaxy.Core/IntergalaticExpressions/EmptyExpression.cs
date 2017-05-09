namespace MerchantGuideToGalaxy.Core.IntergalaticExpressions
{
    class EmptyExpression : IntergalaticExpression
    {
        public override string Name() => string.Empty;

        public override decimal Multiplier() => 1;
    }
}
