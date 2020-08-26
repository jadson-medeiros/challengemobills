using FluentValidation;

namespace ChallengeMobills.Business.Models.Validations
{
    public class ExpenseValidation : AbstractValidator<Expense>
    {
        public ExpenseValidation()
        {
            RuleFor(f => f.Date)
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(f => f.Value)
                .GreaterThan(0).WithMessage("The {PropertyName} need be diferent than {ComparisonValue}");
        }
    }
}