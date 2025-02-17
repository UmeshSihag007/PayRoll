﻿using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.CreateEmployeeFamily;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.UpdateEmployeeFamily
{
    public class UpdateEmployeeFamilyCommand : IRequest<Result<EmployeeFamily>>
    {
        public UpdateEmployeeFamilyCommand(int id, CreateEmployeeFamilyCommand createEmployeeFamily)
        {
            Id = id;
            CreateEmployeeFamily = createEmployeeFamily;
        }

        public int Id { get; set; }
        public CreateEmployeeFamilyCommand CreateEmployeeFamily { get; set; }
    }
    internal class UpdateEmployeeFamilyCommandHandler : IRequestHandler<UpdateEmployeeFamilyCommand, Result<EmployeeFamily>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeFamilyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EmployeeFamily>> Handle(UpdateEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeFamily>().GetByIdAsync(request.Id);
              request.CreateEmployeeFamily.EmployeeId=data.EmployeeId;
            if (data == null)
            {
                return Result<EmployeeFamily>.BadRequest();
            }
            var mapData = _mapper.Map(request.CreateEmployeeFamily, data);
            await _unitOfWork.Repository<EmployeeFamily>().UpdateAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<EmployeeFamily>.Success(data, "Updated");
        }
    }
}
