using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Locations;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Locations.Queries.GetAllLocations
{
    public class GetAllLocationQuery:IRequest<Result<List<GetAllLocationDto>>>
    {
    }
    internal class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, Result<List<GetAllLocationDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
       private readonly IMapper _mapper;

        public GetAllLocationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllLocationDto>>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            var data=await _unitOfWork.Repository<Location>().Entities.Include(x=>x.Parent).Where(x=>x.IsDeleted==false).ToListAsync();  
            if(data is null)
            {
                return Result<List<GetAllLocationDto>>.NotFound();
            }
            var  mapData=_mapper.Map<List<GetAllLocationDto>>(data);
            return Result<List<GetAllLocationDto>>.Success(mapData);

        }
    }
}
