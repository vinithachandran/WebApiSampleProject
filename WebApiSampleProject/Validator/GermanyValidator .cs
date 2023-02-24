using System.Text.RegularExpressions;

namespace WebApiSampleProject.Validator
{
    public class GermanyValidator : IdValidationAbstract
    {   

        public GermanyValidator()
        {
            CountryCode = nameof(Country.DE);

        }
        public override ValidationResult ValidateVAT(string vatId)
        {
            vatId = vatId.RemoveSpecialCharacthers();
            vatId = vatId.Replace("DE", string.Empty).Replace("de", string.Empty);
            if (!Regex.IsMatch(vatId, @"^[1-9]\d{8}$"))
            {
                return ValidationResult.InvalidFormat("123456789");
            }

            var product = 10;
            for (var index = 0; index < 8; index++)
            {
                var sum = (vatId[index].ToInt() + product) % 10;
                if (sum == 0)
                {
                    sum = 10;
                }

                product = 2 * sum % 11;
            }

            var val = 11 - product;
            var checkDigit = val == 10
                ? 0
                : val;

            bool isValid = checkDigit == vatId[8].ToInt();
            return isValid ? ValidationResult.Success() : ValidationResult.InvalidChecksum();
        }
        
    }
}
