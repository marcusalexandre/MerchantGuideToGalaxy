namespace MerchantGuideToGalaxy.Core
{
    public class Context<TOutput>
    {
        public Context(string input)
        {
            Input = input;
        }

        public string Input { get; internal set; }
        internal TOutput Output { get; set; }
    }
}
