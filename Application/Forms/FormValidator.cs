using FluentValidation;
using Domain;

namespace Application.Forms
{
    public class FormValidator: AbstractValidator<Form>
    {
        public FormValidator(){
            RuleFor(x=> x.FormName).NotEmpty();
            RuleFor(x=> x.Description).NotEmpty();
            RuleFor(x=> x.Created).NotEmpty();
        }
    }
}