using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Attributes
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Attribute Attribute { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator(){
                RuleFor(x => x.Attribute).SetValidator(new AttributeValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                this._dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                    _dataContext.Attributes.Add(request.Attribute);
                    var Result = await _dataContext.SaveChangesAsync() > 0;
                    if(!Result) return Result<Unit>.Failure("Failed to create attribute");
                    return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}