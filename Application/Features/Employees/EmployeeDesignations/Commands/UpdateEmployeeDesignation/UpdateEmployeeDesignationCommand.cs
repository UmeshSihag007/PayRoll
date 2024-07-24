﻿using ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.CreateEmployeeDesignation;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.UpdateEmployeeDesignation;

public class UpdateEmployeeDesignationCommand : IRequest<Result<int>>
{
    public UpdateEmployeeDesignationCommand(int id, CreateEmployeeDesignationCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateEmployeeDesignationCommand command { get; set; }

}
internal class UpdateEmployeeDesignationCommandHandler : IRequestHandler<UpdateEmployeeDesignationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEmployeeDesignationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateEmployeeDesignationCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Designation>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }
        var mapData = _mapper.Map<Designation>(data);
        await _unitOfWork.Repository<Designation>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }
}
