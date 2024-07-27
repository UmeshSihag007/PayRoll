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

namespace ApwPayroll_Application.Features.Employees.EmployeeReferences.Queries.GetAllEmployeeReferences
{
    public class GetEmployeeReferalQuery:IRequest<Result<List<ReferralDetail>>>
    {
        public int Id { get; set; }

        public GetEmployeeReferalQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetEmployeeReferalQueryHandler : IRequestHandler<GetEmployeeReferalQuery, Result<List<ReferralDetail>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeReferalQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<ReferralDetail>>> Handle(GetEmployeeReferalQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<ReferralDetail>().GetAllAsync();
            if (data == null)
            {
                return Result<List<ReferralDetail>>.NotFound();
            }
            return Result<List<ReferralDetail>>.Success(data);
        }
    }
}
