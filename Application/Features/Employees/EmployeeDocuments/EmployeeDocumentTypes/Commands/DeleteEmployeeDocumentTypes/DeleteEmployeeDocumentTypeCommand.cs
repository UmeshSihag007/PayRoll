using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.DeleteEmployeeDocumentTypes
{
    public class DeleteEmployeeDocumentTypeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeleteEmployeeDocumentTypeCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteEmployeeDocumentTypeCommandHandler : IRequestHandler<DeleteEmployeeDocumentTypeCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeDocumentTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteEmployeeDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeDocumentType>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
            await _unitOfWork.Repository<EmployeeDocumentType>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.BadRequest("Deleted Successfully");
        }
    }
}
