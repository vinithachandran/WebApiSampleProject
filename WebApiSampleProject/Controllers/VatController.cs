using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using WebApiSampleProject.Models;
using WebApiSampleProject.Validator;

namespace WebApiSampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class VatController : ControllerBase
    {
       
        [HttpPost ("Validation")]
        public  Int32 Validate([FromBody] VatValidation Vatvalid)
        {
            CountryValidation validator = new CountryValidation();
            ValidationResult ValidationRes = new ValidationResult();
            if (Vatvalid.Country == "Germany")
            {
                ValidationRes = validator.ValidateVAT(Vatvalid.VAT, Country.DE);
            }

           
            if (ValidationRes.IsValid)
            {
                Console.WriteLine("Valid");
                var response = StatusCodes.Status202Accepted;
                return response;
            }
            else
            {
                Console.WriteLine(ValidationRes.ErrorMessage);
                var response = StatusCodes.Status406NotAcceptable;
                return response;
            }
            
           
        }

        
    }
}
