﻿//using ApwPayroll_Application.Interfaces.Repositories;
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
using ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
    public CreateEmployeeDocumentCommand()
    {

    }
}
internal class CreateEmployeeDocumentCommandHandler : IRequestHandler<CreateEmployeeDocumentCommand, Result<int>>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IEmployeeDocumentRepository _employeeDocumentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork, IEmployeeDocumentRepository employeeDocumentRepository)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
        _employeeDocumentRepository = employeeDocumentRepository;
    }

    public async Task<Result<int>> Handle(CreateEmployeeDocumentCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var employee = await _unitOfWork.Repository<Employee>().Entities.Where(x => x.Id == request.EmployeeId && x.IsDeleted == false).Include(x => x.EmployeeDocuments).FirstOrDefaultAsync();
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
                var existingDocument = employee.EmployeeDocuments.Where(x=>x.EmployeeDocumentTypeId== item.EmployeeDocumentTypeId)
                     .FirstOrDefault();

                if (existingDocument != null)
                {
                    var updatedDocument = await _documentRepository.updateDocument(existingDocument.DocumentId, item.Document);
                    //// Update existing document
                    //employee.AddIfDocumentNotExists([updatedDocument.Id], item.EmployeeDocumentTypeId,item.Code);

                    await _employeeDocumentRepository.updateDocumentType(request.EmployeeId, updatedDocument.Id, item.Code);
                    await _unitOfWork.Save(cancellationToken);

                      
                }
                else
                {
                    var createdDocument = await _documentRepository.CreateDocument(item.Document, null, 1);
                    employee.AddDocument(createdDocument.Id, item.EmployeeDocumentTypeId, item.Code);
                    await _unitOfWork.Save(cancellationToken);
                }
            }
        }
        catch (Exception ex)
        {

            return Result<int>.BadRequest(ex.Message);
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
