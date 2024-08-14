using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.UpdateStatus
{
     
    public class UpdateEmployeeDocumentTypeStatusCommand : IRequest<Result<int>>
    {
        public UpdateEmployeeDocumentTypeStatusCommand(int id, bool? isActive, bool? isCodeRequired, bool? isDocumentRequired)
        {
            Id = id;
            IsActive = isActive;
            IsCodeRequired = isCodeRequired;
            IsDocumentRequired = isDocumentRequired;
        }

        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCodeRequired { get; set; }
        public bool? IsDocumentRequired { get; set; }
    }

    internal class UpdateEmployeeDocumentTypeStatusCommandHandler : IRequestHandler<UpdateEmployeeDocumentTypeStatusCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeDocumentTypeStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateEmployeeDocumentTypeStatusCommand request, CancellationToken cancellationToken)
        {

            var data = await _unitOfWork.Repository<EmployeeDocumentType>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
           

            data.IsActive = request.IsActive.Value;
            
                data.IsCodeRequired = request.IsCodeRequired.Value;

           
                data.IsDocumentRequired = request.IsDocumentRequired.Value;
          
            await _unitOfWork.Repository<EmployeeDocumentType>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success(data.Id, " Status Updated Successfully .");
        }
    }
}
