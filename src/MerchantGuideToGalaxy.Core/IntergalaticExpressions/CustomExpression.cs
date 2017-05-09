namespace MerchantGuideToGalaxy.Core.IntergalaticExpressions
{
    class CustomExpression : IntergalaticExpression
    {
        private readonly string _name;
        private readonly decimal _multiplier;

        public CustomExpression(string name, decimal multiplier)
        {
            _name = name;
            _multiplier = multiplier;
        }

        public override string Name() => _name;

        public override decimal Multiplier() => _multiplier;
    }
}
