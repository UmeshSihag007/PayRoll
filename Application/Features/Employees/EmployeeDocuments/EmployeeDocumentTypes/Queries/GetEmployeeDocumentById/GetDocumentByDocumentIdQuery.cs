using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.Queries.GetDocumentById
{
    public class GetDocumentByDocumentIdQuery : IRequest<Result<EmployeeDocument>>
    {
        public GetDocumentByDocumentIdQuery(int employeeId, int? documentId)
        {
            EmployeeId = employeeId;
            DocumentId = documentId;
        }

        public int EmployeeId { get; set; }
        public int? DocumentId { get; set; }
    }

    internal class GetDocumentByDocumentIdQueryHandler : IRequestHandler<GetDocumentByDocumentIdQuery, Result<EmployeeDocument>>
    {

        private readonly IMapper _mapper;
        private readonly IEmployeeDocumentRepository _employeeDocumentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetDocumentByDocumentIdQueryHandler(IMapper mapper, IEmployeeDocumentRepository employeeDocumentRepository, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _employeeDocumentRepository = employeeDocumentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<EmployeeDocument>> Handle(GetDocumentByDocumentIdQuery request, CancellationToken cancellationToken)
        {
            //var data = await _employeeDocumentRepository.GetEmployeeDocument(request.EmployeeId, request.DocumentId.);


            var data = await _unitOfWork.Repository<EmployeeDocument>().Entities.Where(x => x.EmployeeId == request.EmployeeId  && x.EmployeeDocumentTypeId==request.DocumentId).Include(x => x.Document).Include(x => x.EmployeeDocumentType)
                .FirstOrDefaultAsync();
            if (data == null)
            {
                return Result<EmployeeDocument>.NotFound();
            }
            var mapData = _mapper.Map<EmployeeDocument>(data);
            return Result<EmployeeDocument>.Success(mapData);
        }
    }
}
