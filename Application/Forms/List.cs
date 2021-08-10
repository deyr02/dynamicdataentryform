using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Forms
{
    public class List
    {
        public class Query : IRequest<List<Form>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Form>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                this._dataContext = dataContext;
            }

            public async Task<List<Form>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Forms.ToListAsync(cancellationToken);
            }
        }
    }
}