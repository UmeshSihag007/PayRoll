//using ApwPayroll_Application.Interfaces.Repositories;
//using ApwPayroll_Application.Interfaces.Repositories.Documents;
//using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
//using ApwPayroll_Domain.Entities.Employees;
//using ApwPayroll_Shared;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using System.ComponentModel.DataAnnotations;

//namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;

//public class CreateEmployeeDocumentCommand : IRequest<Result<int>>
//{
//    public int EmployeeId { get; set; }
//    public int TypeId { get; set; }
//     public int? EmployeeDocumentTypeId { get; set; }

//    [Required(ErrorMessage = "Please upload a document.")]
//    public IFormFile Url { get; set; }
//}
//internal class CreateEmployeeDocumentCommandHandler : IRequestHandler<CreateEmployeeDocumentCommand, Result<int>>
//{
//    private readonly IDocumentRepository _documentRepository;
//    private readonly IUnitOfWork _unitOfWork;

//    public CreateEmployeeDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
//    {
//        _documentRepository = documentRepository;
//        _unitOfWork = unitOfWork;
//    }

//    public async Task<Result<int>> Handle(CreateEmployeeDocumentCommand request, CancellationToken cancellationToken)
//    {
//        request.EmployeeId = 1;


//        var checkEmployee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);
//        if (checkEmployee == null)
//        {
//            return Result<int>.BadRequest();
//        }
//        var document = await _documentRepository.CreateDocument(request.Url,null,request.TypeId);

//       checkEmployee.AddDocument(document.Id,request.EmployeeDocumentTypeId.Value);
//        await _unitOfWork.Save(cancellationToken);
//        return Result<int>.Success();

//    }
//}
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.Documents;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.Commands.CreateEmployeeDocuments;

public class CreateEmployeeDocumentCommand : IRequest<Result<int>>
{
    public int EmployeeId { get; set; }
    public List<CreateEmployeeDocumentDto> EmployeeDocuments { get; set; } = new List<CreateEmployeeDocumentDto>();

    public CreateEmployeeDocumentCommand(int employeeId, List<CreateEmployeeDocumentDto> employeeDocuments)
    {
        EmployeeId = employeeId;
        EmployeeDocuments = employeeDocuments;
    }
}
internal class CreateEmployeeDocumentCommandHandler : IRequestHandler<CreateEmployeeDocumentCommand, Result<int>>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateEmployeeDocumentCommand request, CancellationToken cancellationToken)
    {
        request.EmployeeId = 1;
        var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);
        if (employee == null)
        {
            return Result<int>.BadRequest();
        }

        foreach (var item in request.EmployeeDocuments)
        {
            var employeeDocument = await _unitOfWork.Repository<EmployeeDocumentType>().GetByIdAsync(item.EmployeeDocumentTypeId);
            if (employeeDocument == null)
            {
                return Result<int>.BadRequest($"Invalid EmployeeDocumentId:{item.EmployeeDocumentTypeId}");
            }

            var createdDocument = await _documentRepository.CreateDocument(item.Document, null, 1);
            employee.AddDocument(createdDocument.Id, item.EmployeeDocumentTypeId, item.Code);

            await _unitOfWork.Save(cancellationToken);
        }
        //for(int i = 0; i<= request.EmployeeDocumentTypeIds.Count; i++)
        //{
        //    var document = request.Documents[i];
        //    var documentTypeId = request.EmployeeDocumentTypeIds[i];

        //    var createdDocument = await _documentRepository.CreateDocument(document, null, documentTypeId);

        //    employee.AddDocument(createdDocument.Id, documentTypeId, request.Code[i]);

        //    await _unitOfWork.Save(cancellationToken);

        //} 

        return Result<int>.Success();
    }
}
