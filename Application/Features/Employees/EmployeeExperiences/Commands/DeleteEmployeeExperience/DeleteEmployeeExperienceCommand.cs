using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Shared;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.DeleteEmployeeExperience
{
    public class DeleteEmployeeExperienceCommand:IRequest<Result<int>>
    {
        public int Id{ get; set;}

        public DeleteEmployeeExperienceCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteEmployeeExperienceCommandHandler : IRequestHandler<DeleteEmployeeExperienceCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeExperienceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteEmployeeExperienceCommand request, CancellationToken cancellationToken)
        {
             var data=await _unitOfWork.Repository<EmployeeExperience>().GetByIdAsync(request.Id);
            if(data == null)
            {
                return Result<int>.BadRequest();
            }
            await _unitOfWork.Repository<EmployeeExperience>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.BadRequest("Deleted Successfully");   
        }
    }
}
