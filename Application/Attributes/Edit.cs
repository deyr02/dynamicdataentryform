using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Attributes
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Attribute Attribute { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator(){
                RuleFor(x=>x.Attribute).SetValidator(new AttributeValidator());
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
                var attribute = await _dataContext.Attributes.FindAsync(request.Attribute.AttributeId);
                if (attribute == null) return null;

                _mapper.Map(request.Attribute, attribute);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Failure("Failed to update Attribute");
                return Result<Unit>.Success(Unit.Value);


            }
        }
    }
}