using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AttributeValueOptions
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AttributeValueOption AttributeValueOption { get; set; }
        }
        public class CommandValidator: AbstractValidator<Command>{
            public CommandValidator(){
                RuleFor(x => x.AttributeValueOption).SetValidator(new AttributeValueOptionValidator());
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
                _dataContext.AttributeValueOptions.Add(request.AttributeValueOption);
                var Result = await _dataContext.SaveChangesAsync() > 0;
                if(!Result) return Result<Unit>.Failure("Failed to create new Option");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}