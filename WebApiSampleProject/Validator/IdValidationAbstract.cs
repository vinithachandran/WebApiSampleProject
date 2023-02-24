namespace WebApiSampleProject.Validator
{
    public abstract class IdValidationAbstract
    {

        public static string CountryCode { get; protected set; }  
        public abstract ValidationResult ValidateVAT(string vatId);
   
    }
}
