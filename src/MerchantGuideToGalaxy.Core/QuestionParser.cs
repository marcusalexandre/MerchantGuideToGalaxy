namespace MerchantGuideToGalaxy.Core
{
    public class QuestionParser
    {

        private readonly IntergalaticConverter _intergalaticConverter;
        const string HowMuchIs  = "how much is ";
        const string HowManyCreditsIs = "how many Credits is ";
        const string Question = " ?";

        public QuestionParser()
        {
            _intergalaticConverter = new IntergalaticConverter();
        }

        public string Evaluate(string question)
        {
            if (question.StartsWith(HowMuchIs) && question.EndsWith(Question))
            {
                var value = question.Substring(HowMuchIs.Length);
                value = value.Substring(0, value.Length - Question.Length);
                var roman = _intergalaticConverter.ConvertIntergalaticToCredits(value);
                return $"{value} is {roman}";
            }
            else if (question.StartsWith(HowManyCreditsIs) && question.EndsWith(Question))
            {
                var value = question.Substring(HowManyCreditsIs.Length);
                value = value.Substring(0, value.Length - Question.Length);
                var roman = (int) _intergalaticConverter.ConvertIntergalaticToCredits(value);
                return $"{value} is {roman} Credits";
            }
            else
            {
                return "I have no idea what you are talking about";
            }
        }
    }
}
