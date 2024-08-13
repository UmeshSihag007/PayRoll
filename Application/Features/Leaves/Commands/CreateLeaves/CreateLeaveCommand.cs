using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves;

public class CreateLeaveCommand : IRequest<Result<Leave>>
{
    public int? Id { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public string Reason { get; set; }
    public long ContactNumber { get; set; }
    public bool IsPaid { get; set; }
    public LeaveStatusEnum LeaveStatus { get; set; }
    public bool IsHalfDay { get; set; }

    public LeaveTypeRule? LeaveTypeRole {  get; set; }
}
internal class CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, Result<Leave>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Leave>> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
    {
        // Get LeaveType
        var leaveType = await _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.LeaveTypeId);
        if (leaveType == null)
        {
            return Result<Leave>.BadRequest();
        }

        if (request.LeaveTypeRole != null)
        {
            var branch = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.LeaveTypeRole.BranchId??0);
            if (branch == null)
            {
                return Result<Leave>.BadRequest();
            }

            var designation = await _unitOfWork.Repository<Designation>().GetByIdAsync(request.LeaveTypeRole.DesignationId ?? 0);
            if (designation == null)
            {
                return Result<Leave>.BadRequest();
            }
        }

        var mapData = _mapper.Map<Leave>(request);
        var data = await _unitOfWork.Repository<Leave>().AddAsync(mapData);

        await _unitOfWork.Save(cancellationToken);

        if (request.LeaveTypeRole != null)
        {
            var leaveTypeRule = new LeaveTypeRule
            {
                LeaveTypeId = data.LeaveTypeId,
                DesignationId = request.LeaveTypeRole.DesignationId ?? 0,
                Gender = request.LeaveTypeRole.Gender,
                BranchId = request.LeaveTypeRole.BranchId
            };
            await _unitOfWork.Repository<LeaveTypeRule>().AddAsync(leaveTypeRule);
            await _unitOfWork.Save(cancellationToken);
        }
        return Result<Leave>.Success(data, "Create Successfully");
    }
}

/*internal class CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, Result<Leave>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Leave>> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
    {
        var leaveType = _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.LeaveTypeId);
        if (leaveType == null)
        {
            return Result<Leave>.BadRequest();
        }
        var branch = _unitOfWork.Repository<Branch>().GetByIdAsync(request.LeaveTypeRole.BranchId);
        if (leaveType == null)
        {
            return Result<Leave>.BadRequest();
        }
        var designation = _unitOfWork.Repository<Designation>().GetByIdAsync(request.LeaveTypeRole?.DesignationId);
        if (leaveType == null)
        {
            return Result<Leave>.BadRequest();
        }
        var mapData = _mapper.Map<Leave>(request);
        var data = await _unitOfWork.Repository<Leave>().AddAsync(mapData);

        await _unitOfWork.Save(cancellationToken);

        if (request.LeaveTypeRole != null)
        {
           
            var leaveTypeRule = new LeaveTypeRule
            {
                LeaveTypeId = data.LeaveTypeId,
                DesignationId = request.LeaveTypeRole.DesignationId,
                Gender = request.LeaveTypeRole.Gender,
                BranchId = request.LeaveTypeRole.BranchId,  
            };
            await _unitOfWork.Repository<LeaveTypeRule>().AddAsync(leaveTypeRule);
            await _unitOfWork.Save(cancellationToken);
        }
        return Result<Leave>.Success(data, "Create Successfully");
    }
}
*/


