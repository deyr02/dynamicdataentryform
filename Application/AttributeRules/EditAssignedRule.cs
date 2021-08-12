using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AttributeRules
{
    public class EditAssignedRule
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AttributeRule AttributeRule { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.AttributeRule).SetValidator(new AttributeRuleValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                this._mapper = mapper;
                this._dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var attributeRule = await _dataContext.AttributeRules.FindAsync(request.AttributeRule.AttributeId,
                request.AttributeRule.RuleId);
                if (attributeRule == null) return null;

                _mapper.Map(request.AttributeRule, attributeRule);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to edit the rule");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}