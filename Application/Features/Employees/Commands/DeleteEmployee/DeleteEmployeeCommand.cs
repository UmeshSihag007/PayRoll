using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.Commands.DeleteEmployee
{
   public class DeleteEmployeeCommand:IRequest<Result<int>>
    { 
        public int EmployeeId { get; set;}

        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        { 
            var data =await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);    
              
           await _unitOfWork.Repository<Employee>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);

            return Result<int>.Success();
        }
    }
}
