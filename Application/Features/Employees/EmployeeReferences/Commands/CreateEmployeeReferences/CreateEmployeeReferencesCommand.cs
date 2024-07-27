using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
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

namespace ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.CreateEmployeeReferences
{
    public class CreateEmployeeReferencesCommand:IRequest<Result<ReferralDetail>>
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; } 
        public string ReferenceName { get; set; }
        public string Designation { get; set; } 
        public string OrganizationName { get; set; }
        public long ContactNumber { get; set; }
        public int YearsOfAcquaintance { get; set; }
    }
    internal class CreateEmployeeReferencesCommandHandler : IRequestHandler<CreateEmployeeReferencesCommand, Result<ReferralDetail>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeReferencesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ReferralDetail>> Handle(CreateEmployeeReferencesCommand request, CancellationToken cancellationToken)
        {
         
            var mapData = _mapper.Map<ReferralDetail>(request);
            var data= await _unitOfWork.Repository<ReferralDetail>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<ReferralDetail>.Success(data,"Create Successfully");
        }
    }
}
