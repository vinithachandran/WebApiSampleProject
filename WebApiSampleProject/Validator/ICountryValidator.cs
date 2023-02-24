namespace WebApiSampleProject.Validator
{
    public interface ICountryValidator
    {
        ValidationResult ValidateVAT(string vat, Country country);
      
    }
}
