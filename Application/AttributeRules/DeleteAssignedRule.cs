using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.AttributeRules
{
    public class DeleteAssignedRule
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AttributeRule AttributeRule { get; set; }
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
                var attributeRule = await _dataContext.AttributeRules.FindAsync(request.AttributeRule.AttributeId, request.AttributeRule.RuleId);
                if (attributeRule == null) return null;

                _dataContext.AttributeRules.Remove(attributeRule);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete attribute rule");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}