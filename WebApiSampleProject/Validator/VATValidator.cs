using FluentValidation;
using WebApiSampleProject.Controllers;
using WebApiSampleProject.Models;

namespace WebApiSampleProject.Validator
{
    public class VATValidator : AbstractValidator<VatValidation>
    {
        public VATValidator()
        {
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.VAT).NotEmpty();
        }
    }
}
