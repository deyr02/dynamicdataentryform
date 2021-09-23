using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Record
{
    // public class List
    // {
    //     public class Query : IRequest<Result<List<RecordDto>>>
    //     {
    //         public Guid FormId { get; set; }
    //     }

    //     public class Handler : IRequestHandler<Query, Result<List<RecordDto>>>
    //     {
    //         private readonly DataContext _dataContext;
    //         private readonly IMapper _mapper;
    //         public Handler(DataContext dataContext, IMapper mapper)
    //         {
    //             this._mapper = mapper;
    //             this._dataContext = dataContext;
    //         }

    //         public async Task<Result<List<RecordDto>>> Handle(Query request, CancellationToken cancellationToken)
    //         {
    //             var form =  _dataContext.Forms.Where(xy => xy.Id == request.FormId).Include(x => x.Attributes).ThenInclude(y => y.Logs)
    //                         .ThenInclude(z => z.Log) .ToListAsync();

    //             if(form ==null) return null;
    //         }
    //     }
    // }
}
