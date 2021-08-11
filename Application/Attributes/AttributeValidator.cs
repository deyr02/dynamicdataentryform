using Domain;
using FluentValidation;

namespace Application.Attributes
{
    public class AttributeValidator : AbstractValidator<Attribute>
    {
        public AttributeValidator()
        {
            RuleFor(x => x.AttributeName).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.FormId).NotEmpty();
            RuleFor(x => x.ControlTypeId).NotEmpty();
            RuleFor(x => x.DataTypeId).NotEmpty();
        }
    }
}