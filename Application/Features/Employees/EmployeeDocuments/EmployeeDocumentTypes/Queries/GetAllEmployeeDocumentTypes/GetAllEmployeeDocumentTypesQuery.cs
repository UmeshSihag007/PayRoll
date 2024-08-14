using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Queries.GetAllEmployeeDocumentTypes
{
    public class GetAllEmployeeDocumentTypesQuery : IRequest<Result<List<EmployeeDocumentType>>>
    {

    }
    internal class GetAllEmployeeDocumentTypesQueryHandler : IRequestHandler<GetAllEmployeeDocumentTypesQuery, Result<List<EmployeeDocumentType>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmployeeDocumentTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<EmployeeDocumentType>>> Handle(GetAllEmployeeDocumentTypesQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeDocumentType>().GetAllAsync();
            if (data == null)
            {
                return Result<List<EmployeeDocumentType>>.NotFound();
            }
            var mapData = _mapper.Map<List<EmployeeDocumentType>>(data);
            return Result<List<EmployeeDocumentType>>.Success(mapData);
        }
    }
}
