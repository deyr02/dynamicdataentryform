using Domain;
using FluentValidation;

namespace Application.AttributeRules
{
    public class AttributeRuleValidator : AbstractValidator<AttributeRule>
    {
        public AttributeRuleValidator()
        {
            RuleFor(x=>x.AttributeId).NotEmpty();
            RuleFor(x=> x.RuleId).NotEmpty();
           
        }
    }
}