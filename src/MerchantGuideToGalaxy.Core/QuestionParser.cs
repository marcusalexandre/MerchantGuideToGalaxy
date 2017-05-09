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

        public QuestionParser(IntergalaticConverter intergalaticConverter)
        {
            _intergalaticConverter = intergalaticConverter;
        }

        public string Evaluate(string question)
        {
            try
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
                    var roman = (int)_intergalaticConverter.ConvertIntergalaticToCredits(value);
                    return $"{value} is {roman}{Credits}";
                }
                else if (question.Contains(Assignment))
                {
                    var left = question.Substring(0, question.IndexOf(Assignment));
                    var right = question.Substring(question.IndexOf(Assignment) + Assignment.Length);
                    var split = left.Split(' ');

                    if (right.EndsWith(Credits))
                    {
                        var roman = string.Empty;
                        foreach(var value in split)
                        {
                            if (_intergalaticConverter.IsDirt(value))
                            {
                                roman += _intergalaticConverter.ConvertIntergalaticToRoman(value);
                            }
                            else if (value != split[split.Length - 1])
                            {
                                throw new Exception();
                            }
                            else
                            {
                                var credits = decimal.Parse(right.Substring(0, right.Length - Credits.Length));
                                var multiplier = (decimal) _intergalaticConverter.ConvertRomanToCredits(roman);
                                _intergalaticConverter.AddQuotationMetal(value, credits / multiplier);
                                return string.Empty;
                            }
                        }
                        throw new Exception();
                    }
                    else if (split.Length != 1)
                    {
                        throw new Exception();
                    }
                    _intergalaticConverter.AddQuotationDirt(left, right);
                    return string.Empty;

                }
                else
                {
                    return "I have no idea what you are talking about";
                }
            }
            catch
            {
                return "Invalid query";
            }
        }
    }
}
