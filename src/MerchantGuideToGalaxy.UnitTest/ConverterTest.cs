using MerchantGuideToGalaxy.Core;
using Xunit;

namespace MerchantGuideToGalaxy.UnitTest
{

    /// <summary>
    /// Testes de Conversão
    /// </summary>
    public class ConverterTest
    {
        private readonly IntergalaticConverter _intergalaticConverter;
        public ConverterTest()
        {
            _intergalaticConverter = new IntergalaticConverter();
        }


        /// <summary>
        /// Conversão de algarismos romanos para decimais
        /// </summary>
        [Theory(DisplayName ="Roman to Credits")]
        [InlineData("MMVI", 2006)]
        [InlineData("MCMXLIV", 1944)]
        [InlineData("MCMIII", 1903)]
        public void ConvertRomanToCredits(string roman, int credits)
        {
            var value = _intergalaticConverter.ConvertRomanToCredits(roman);
            Assert.Equal(value, credits);
        }

        /// <summary>
        /// Conversão de quantidade intergaláticas para romanos
        /// </summary>
        [Theory(DisplayName = "Intergalatic to Roman")]
        [InlineData("glob", "I")]
        [InlineData("prok", "V")]
        [InlineData("pish", "X")]
        [InlineData("tegj", "L")]
        public void ConvertIntergalaticToRoman(string intergalatic, string roman)
        {
            var value = _intergalaticConverter.ConvertIntergalaticToRoman(intergalatic);
            Assert.Equal(value, roman);
        }


        /// <summary>
        /// Conversão de quantidade intergaláticas para decimais
        /// </summary>
        [Theory(DisplayName = "Intergalatic to Credits")]
        [InlineData("glob glob Silver", 34)]
        [InlineData("glob prok Gold", 57800)]
        [InlineData("pish pish Iron", 3910)]
        public void ConvertIntergalaticToCredits(string intergalatic, int credits)
        {
            var value = _intergalaticConverter.ConvertIntergalaticToCredits(intergalatic);
            Assert.Equal(value, credits);
        }

    }
}
