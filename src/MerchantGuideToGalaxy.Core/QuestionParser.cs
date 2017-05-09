using System;

namespace MerchantGuideToGalaxy.Core
{
    public class QuestionParser
    {

        private readonly IntergalaticConverter _intergalaticConverter;
        const string HowMuchIs  = "how much is ";
        const string HowManyCreditsIs = "how many Credits is ";
        const string Question = " ?";
        const string Assignment = " is ";
        const string Credits = " Credits";
        const string IHaveNoIdeaWhatYouAreTalkingAbout = "I have no idea what you are talking about";
        const string InvalidQuery = "Invalid query";

        public QuestionParser(IntergalaticConverter intergalaticConverter)
        {
            _intergalaticConverter = intergalaticConverter;
        }

        /// <summary>
        /// Evaluate a question
        /// </summary>
        public string Evaluate(string question)
        {
            try
            {
                if (question.StartsWith(HowMuchIs) && question.EndsWith(Question))
                {
                    return QuestionHowMuchIs(question);
                }

                if (question.StartsWith(HowManyCreditsIs) && question.EndsWith(Question))
                {
                    return QuestionHowManyCreditsIs(question);
                }

                if (question.Contains(Assignment))
                {
                    return QuestionAssignment(question);
                }
                
                return IHaveNoIdeaWhatYouAreTalkingAbout;
            }
            catch
            {
                return InvalidQuery;
            }
        }

        /// <summary>
        /// Parse question how much is
        /// </summary>
        private string QuestionHowMuchIs(string question)
        {
            var value = question.Substring(HowMuchIs.Length);
            value = value.Substring(0, value.Length - Question.Length);
            var roman = _intergalaticConverter.ConvertIntergalaticToCredits(value);
            return $"{value} is {roman}";
        }

        /// <summary>
        /// Parse question how many credits is
        /// </summary>
        private string QuestionHowManyCreditsIs(string question)
        {
            var value = question.Substring(HowMuchIs.Length);
            value = value.Substring(0, value.Length - Question.Length);
            var roman = _intergalaticConverter.ConvertIntergalaticToCredits(value);
            return $"{value} is {roman}";
        }

        /// <summary>
        /// Parse "is"
        /// </summary>
        private string QuestionAssignment(string question)
        {
            var left = question.Substring(0, question.IndexOf(Assignment));
            var right = question.Substring(question.IndexOf(Assignment) + Assignment.Length);
            var split = left.Split(' ');
            var roman = string.Empty;

            if (split.Length == 1)
            {
                _intergalaticConverter.AddQuotationDirt(left, right);
                return string.Empty;
            }
            else if (right.EndsWith(Credits))
            {
                foreach (var value in split)
                {
                    if (_intergalaticConverter.IsDirt(value))
                    {
                        roman += _intergalaticConverter.ConvertIntergalaticToRoman(value);
                        continue;
                    }
                    else if (value == split[split.Length - 1])
                    {
                        var credits = decimal.Parse(right.Substring(0, right.Length - Credits.Length));
                        var multiplier = (decimal)_intergalaticConverter.ConvertRomanToCredits(roman);
                        _intergalaticConverter.AddQuotationMetal(value, credits / multiplier);
                        return string.Empty;
                    }
                    throw new Exception(InvalidQuery);
                }
            }

            throw new Exception(InvalidQuery);
        }
    }
}
