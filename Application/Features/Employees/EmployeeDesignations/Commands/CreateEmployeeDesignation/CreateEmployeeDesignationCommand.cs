﻿using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDesignations.Commands.CreateEmployeeDesignation
{
    public class CreateEmployeeDesignationCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class CreateEmployeeDesignationCommandHandler : IRequestHandler<CreateEmployeeDesignationCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeDesignationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEmployeeDesignationCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Designation>(request);
            await _unitOfWork.Repository<Designation>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
