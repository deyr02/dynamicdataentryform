using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Attributes
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int Id { get; set; }
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
                var attribute = await _dataContext.Attributes.FindAsync(request.Id);
                if(attribute == null) return null;

                _dataContext.Remove(attribute);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if(!result) return Result<Unit>.Failure("Failed to delete Attribute");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}