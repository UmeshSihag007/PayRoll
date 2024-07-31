using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.RelationTypes;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.RelationTypes.Queries.GetRelationTypes
{
    public class GetRelationTypeQuery:IRequest<Result<List<LookUpDto>>>
    {
    }
    internal class GetRelationTypeQueryHandler : IRequestHandler<GetRelationTypeQuery, Result<List<LookUpDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRelationTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<LookUpDto>>> Handle(GetRelationTypeQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<RelationType>().GetAllAsync();
            if (data == null)
            {
                return Result<List<LookUpDto>>.NotFound();
            }
            var mapData = _mapper.Map<List<LookUpDto>>(data);
            return Result<List<LookUpDto>>.Success(mapData);


        }
    }
}
