using System.ComponentModel.DataAnnotations;

namespace WebApiSampleProject.Models
{
    public class VatValidation
    {
        [Required]
        public String Country { get; set; }
        [Required]
        public String VAT { get; set; }
    }
}
