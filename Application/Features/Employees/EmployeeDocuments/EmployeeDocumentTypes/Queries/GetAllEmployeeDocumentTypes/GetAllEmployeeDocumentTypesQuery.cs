using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDocumentTypes
{
    public class GetAllEmployeeDocumentTypesQuery:IRequest<Result<List<LookUpDto>>>
    {
 
    }
    internal class GetAllEmployeeDocumentTypesQueryHandler : IRequestHandler<GetAllEmployeeDocumentTypesQuery, Result<List<LookUpDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmployeeDocumentTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<LookUpDto>>> Handle(GetAllEmployeeDocumentTypesQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeDocumentType>().GetAllAsync();
            if (data == null)
            {
                return Result<List<LookUpDto>>.NotFound();   
            }
            var mapData=_mapper.Map<List<LookUpDto>>(data);
            return Result<List<LookUpDto>>.Success(mapData);
        }
    }
}
