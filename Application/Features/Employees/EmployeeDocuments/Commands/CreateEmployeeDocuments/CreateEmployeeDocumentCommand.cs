using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.Documents;
using ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;

public class CreateEmployeeDocumentCommand : IRequest<Result<EmployeeDocument>>
{
    public int EmployeeId { get; set; }
    public List<CreateEmployeeDocumentDto> EmployeeDocuments { get; set; } = new List<CreateEmployeeDocumentDto>();

    public CreateEmployeeDocumentCommand(int employeeId, List<CreateEmployeeDocumentDto> employeeDocuments)
    {
        EmployeeId = employeeId;
        EmployeeDocuments = employeeDocuments;
    }

    public CreateEmployeeDocumentCommand() { }
}

internal class CreateEmployeeDocumentCommandHandler : IRequestHandler<CreateEmployeeDocumentCommand, Result<EmployeeDocument>>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IEmployeeDocumentRepository _employeeDocumentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork, IEmployeeDocumentRepository employeeDocumentRepository, IMapper mapper)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
        _employeeDocumentRepository = employeeDocumentRepository;
        _mapper = mapper;
    }

    public async Task<Result<EmployeeDocument>> Handle(CreateEmployeeDocumentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _unitOfWork.Repository<Employee>()
                .Entities
                .Where(x => x.Id == request.EmployeeId && x.IsDeleted == false)
                .Include(x => x.EmployeeDocuments)
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return Result<EmployeeDocument>.BadRequest("Employee not found.");
            }

            foreach (var item in request.EmployeeDocuments)
            {
                var employeeDocumentType = await _unitOfWork.Repository<EmployeeDocumentType>()
                    .GetByIdAsync(item.EmployeeDocumentTypeId);

                if (employeeDocumentType == null)
                {
                    return Result<EmployeeDocument>.BadRequest($"Invalid EmployeeDocumentTypeId: {item.EmployeeDocumentTypeId}");
                }

                var existingDocument = employee.EmployeeDocuments
                    .FirstOrDefault(x => x.EmployeeDocumentTypeId == item.EmployeeDocumentTypeId && x.EmployeeId == request.EmployeeId);

                if (existingDocument != null)
                {
                    if (item.Document == null && employeeDocumentType.IsDocumentRequired==true )
                    {
                        return Result<EmployeeDocument>.BadRequest($"{employeeDocumentType.Name} document is required.");
                    }

                    if (existingDocument.DocumentId != null  && item.Document!=null)
                    {
                        await _documentRepository.updateDocument(existingDocument.DocumentId.Value, item.Document);
                    }
                    if(item.Document!=null && existingDocument.DocumentId == null)
                    {
                    var  docuement =    await _documentRepository.CreateDocument(item.Document, null, 1);
                        existingDocument.DocumentId = docuement.Id;

                    }

                    existingDocument.Code = item.Code;
                    await _unitOfWork.Repository<EmployeeDocument>().UpdateAsync(existingDocument);
                }
                else
                {
                    if (item.Document == null && employeeDocumentType.IsDocumentRequired)
                    {
                        return Result<EmployeeDocument>.BadRequest($"{employeeDocumentType.Name} document is required.");
                    }

                    EmployeeDocument newDocument;
                    if (item.Document != null)
                    {
                        var createdDocument = await _documentRepository.CreateDocument(item.Document, null, 1);

                        newDocument = new EmployeeDocument
                        {
                            Code = item.Code,
                            EmployeeDocumentTypeId = item.EmployeeDocumentTypeId,
                            EmployeeId = request.EmployeeId,
                            DocumentId = createdDocument.Id,
                            IsActive = true
                        };
                    }
                    else
                    {
                        newDocument = new EmployeeDocument
                        {
                            Code = item.Code,
                            EmployeeDocumentTypeId = item.EmployeeDocumentTypeId,
                            EmployeeId = request.EmployeeId,
                            IsActive = true
                        };
                    }

                    await _unitOfWork.Repository<EmployeeDocument>().AddAsync(newDocument);
                }

                await _unitOfWork.Save(cancellationToken);
            }

            return Result<EmployeeDocument>.Success();
        }
        catch (Exception ex)
        {
            return Result<EmployeeDocument>.BadRequest(ex.Message);
        }
    }
}
