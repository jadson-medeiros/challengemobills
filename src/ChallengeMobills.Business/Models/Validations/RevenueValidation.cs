using FluentValidation;

namespace ChallengeMobills.Business.Models.Validations
{
    public class RevenueValidation : AbstractValidator<Revenue>
    {
        public RevenueValidation()
        {
            RuleFor(f => f.Date)
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(f => f.Value)
                .GreaterThan(0).WithMessage("The {PropertyName} need be diferent than {ComparisonValue}");
        }
    }
}