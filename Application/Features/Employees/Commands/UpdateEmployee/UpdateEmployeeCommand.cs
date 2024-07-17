﻿using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Result<Employee>>
    {
        public UpdateEmployeeCommand(int employeeId, CreateEmployeeCommand command)
        {
            EmployeeId = employeeId;
            Command = command;
        }

        public int EmployeeId { get; set; }
        public CreateEmployeeCommand Command { get; set; }

    }
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<Employee>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public async Task<Result<Employee>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);

            var mapdata = _mapper.Map(request.Command, data);
            await _unitOfWork.Repository<Employee>().AddAsync(mapdata);
            await _unitOfWork.Save(cancellationToken);
            return Result<Employee>.Success(mapdata);
        }
    }
}
