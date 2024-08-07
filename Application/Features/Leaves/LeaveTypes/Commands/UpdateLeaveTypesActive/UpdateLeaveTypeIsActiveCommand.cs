using ApwPayroll_Application.Features.Employees.Commands.UpdateIsLoginAccess;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypesActive
{
    public class UpdateLeaveTypeIsActiveCommand : IRequest<Result<int>>
    {

        public UpdateLeaveTypeIsActiveCommand(int id, bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
    }


    internal class UpdateLeaveTypeIsActiveCommandHandler : IRequestHandler<UpdateLeaveTypeIsActiveCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLeaveTypeIsActiveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateLeaveTypeIsActiveCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
            data.IsActive = request.IsActive;

            await _unitOfWork.Repository<LeaveType>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success(data.Id, "  Status Updated");


        }
    }
}
