using Domain;
using FluentValidation;

namespace Application.AttributeValueOptions
{
    public class AttributeValueOptionValidator: AbstractValidator<AttributeValueOption>
    {
        public AttributeValueOptionValidator(){
           
            RuleFor(x => x.Option).NotEmpty();
        }
    }
}