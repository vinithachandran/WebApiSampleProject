using FluentValidation.Validators;
using System.Diagnostics.Metrics;
//using CountryValidation.Countries;
using System.Collections.Generic;
using System.Linq;

namespace WebApiSampleProject.Validator
{
    public enum Country
    {
        DE,        
        //DK,
        //US,
    }
    public class CountryValidation 
    {
        static readonly Dictionary<Country, IdValidationAbstract> _supportedCountries;

        static CountryValidation()
        {
            _supportedCountries = Load();
        }

        public static bool IsCountrySupported(Country country)
        {
            return _supportedCountries.ContainsKey(country);
        }

        public static List<string> SupportedCountries
        {
            get
            {
                return _supportedCountries.Keys.Select(c => c.ToString()).ToList();
            }
        }


        private static Dictionary<Country, IdValidationAbstract> Load()
        {
            Dictionary<Country, IdValidationAbstract> ssnCountries = new Dictionary<Country, IdValidationAbstract>
            {

                { Country.DE, new GermanyValidator() },

            };
            return ssnCountries;
        }
      

        public ValidationResult ValidateVAT(string vat, Country country)
        {
            if (_supportedCountries.ContainsKey(country))
            {
                return _supportedCountries[country].ValidateVAT(vat);
            }
            return ValidationResult.Invalid("Not supported");
        }
        
    }
}
