using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AttributeValueOptions
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AttributeValueOption AttributeValueOption { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.AttributeValueOption).SetValidator(new AttributeValueOptionValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext ,  IMapper mapper)
            {
                this._dataContext = dataContext;
                this._mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var option = await _dataContext.AttributeValueOptions.FindAsync(request.AttributeValueOption.Id);
                if (option == null) return null;
                _mapper.Map(request.AttributeValueOption, option);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if(!result) return Result<Unit>.Failure("Failed to Edit the Option");
                return Result<Unit>.Success(Unit.Value); 
            }
        }
    }
}