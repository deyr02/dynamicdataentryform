using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Forms
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Form Form { get; set; }
        }

        // public class CommandValidator : AbstractValidator<Command>
        // {
        //     public CommandValidator()
        //     {
        //         RuleFor(x => x.Form).SetValidator(new FormValidator());
        //     }
        // }

        public class Handler : IRequestHandler<Command, Result<Unit>>{
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
              
                _context.Forms.Add(request.Form);
                var result = await _context.SaveChangesAsync() >0;
                if (!result)return Result<Unit>.Failure("Failed to cre new form");
                return Result<Unit>.Success(Unit.Value);

            }
        }

    }

}