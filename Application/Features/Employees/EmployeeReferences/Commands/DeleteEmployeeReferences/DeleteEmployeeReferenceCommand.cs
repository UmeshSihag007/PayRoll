using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.ReferralDetails;
using ApwPayroll_Shared;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeReferences.Commands.DeleteEmployeeReferences
{
    public class DeleteEmployeeReferenceCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }

        public DeleteEmployeeReferenceCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteEmployeeReferenceCommandHandler : IRequestHandler<DeleteEmployeeReferenceCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeReferenceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteEmployeeReferenceCommand request, CancellationToken cancellationToken)
        {
           var data = await _unitOfWork.Repository<ReferralDetail>().GetByIdAsync(request.Id);
            if(data == null) 
            { 
                return  Result<int>.BadRequest();
            }
            await _unitOfWork.Repository<ReferralDetail>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.BadRequest("Deleted Successfully");
        }
    }
}
