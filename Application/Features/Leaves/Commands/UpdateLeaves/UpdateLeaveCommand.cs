using ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes;
using ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.UpdateLeaveTypes;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Leaves.Commands.UpdateLeaves;

public class UpdateLeaveCommand : IRequest<Result<Leave>>
{
    public UpdateLeaveCommand(int id, CreateLeaveCommand command)
    {
        Id = id;
        this.command = command;
    }
    public int Id { get; set; }
    public CreateLeaveCommand command { get; set; }
}
internal class UpdateLeaveCommandHandler : IRequestHandler<UpdateLeaveCommand, Result<Leave>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Leave>> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Leave>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<Leave>.BadRequest();
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<Leave>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Leave>.Success(data, "Update Successfully");
    }
}
