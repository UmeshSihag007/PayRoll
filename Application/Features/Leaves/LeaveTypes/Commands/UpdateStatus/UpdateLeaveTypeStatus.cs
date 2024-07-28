using ApwPayroll_Application.Features.Banks.Commands.CreateBankCommands;
using ApwPayroll_Application.Features.Banks.Commands.UpdateBankCommands;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Banks;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Courses.Commands.UpdateStatus;
using ApwPayroll_Domain.Entities.Employees.Courses;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateStatus;

public class UpdateLeaveTypeStatus : IRequest<Result<LeaveType>>
{
    public UpdateLeaveTypeStatus(int id, bool isActive)
    {
        Id = id;
        IsActive = isActive;
    }

    public int Id { get; set; }
    public bool IsActive { get; set; }
}

internal class UpdateLeaveTypeStatusHandler : IRequestHandler<UpdateLeaveTypeStatus, Result<LeaveType>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLeaveTypeStatusHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LeaveType>> Handle(UpdateLeaveTypeStatus request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<LeaveType>.BadRequest();
        }

        data.IsActive = request.IsActive;
        await _unitOfWork.Repository<LeaveType>().UpdateAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<LeaveType>.Success(data, data.IsActive ? "LeaveType is now Active." : "LeaveType is now Disactive.");
    }
}
