using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using Couchbase.Core.IO.Operations;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Courses.Commands.UpdateStatus
{
    public class UpdateCourseStatusCommand : IRequest<Result< int>>
    {
        public UpdateCourseStatusCommand(int id, bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }

        public int Id { get; set; }
         public bool IsActive { get; set; } 
    }

    internal class UpdateCourseStatusCommandHandler : IRequestHandler<UpdateCourseStatusCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCourseStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateCourseStatusCommand request, CancellationToken cancellationToken)
        { 

              var data =await _unitOfWork.Repository<Course>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return  Result<int>.BadRequest();
            }
            data.IsActive = request.IsActive;
            await  _unitOfWork.Repository<Course>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken);
              return Result<int>.Success(data.Id, " Status Updated Successfully ."); 
        }
    }
}
