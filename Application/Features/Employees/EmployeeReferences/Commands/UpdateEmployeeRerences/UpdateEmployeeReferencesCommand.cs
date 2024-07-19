﻿using ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.ReferralDetails;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.UpdateEmployeeRerences
{
    public class UpdateEmployeeReferencesCommand:IRequest<Result<int>>
    {
        public UpdateEmployeeReferencesCommand(int id, CreateEmployeeReferencesCommand references)
        {
            Id = id;
            this.references = references;
        }

        public int Id { get; set; }
        public CreateEmployeeReferencesCommand references { get; set; }
        
    }
    internal class UpdateEmployeeReferencesCommandHandler : IRequestHandler<UpdateEmployeeReferencesCommand, Result<int>>
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeReferencesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateEmployeeReferencesCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<ReferralDetail>().GetByIdAsync(request.Id);
            if(data == null)
            {
                return Result<int>.BadRequest();
            }

            var mapData = _mapper.Map(request.references,data);
            mapData.EmployeeId = 1;
            await _unitOfWork.Repository<ReferralDetail>().UpdateAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}

