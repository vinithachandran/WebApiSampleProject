namespace WebApiSampleProject.Validator
{
    public sealed class ValidationResult
    {
        public static ValidationResult Success()
        {
            return new ValidationResult() { IsValid = true };
        }

        public static ValidationResult Invalid(string errorMessage)
        {
            return new ValidationResult() { ErrorMessage = errorMessage, IsValid = false };
        }

        public static ValidationResult InvalidChecksum()
        {
            return new ValidationResult() { ErrorMessage = $"Invalid checksum.", IsValid = false };
        }
        public static ValidationResult InvalidFormat(string format)
        {
            return new ValidationResult() { ErrorMessage = $"Invalid format. The code must have this format {format}", IsValid = false };
        } 
        public bool IsValid { get; private set; }

        public string ErrorMessage { get; private set; }
    }
}

