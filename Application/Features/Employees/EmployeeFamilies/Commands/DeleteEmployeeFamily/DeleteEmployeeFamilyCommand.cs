using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Shared;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.DeleteEmployeeFamily
{
    public class DeleteEmployeeFamilyCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }

        public DeleteEmployeeFamilyCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteEmployeeFamilyCommandHandler : IRequestHandler<DeleteEmployeeFamilyCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeFamilyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeFamily>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<int>.BadRequest();
            }

            await _unitOfWork.Repository<EmployeeFamily>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return  Result<int>.BadRequest ("Deleted Successfully");
          
        }
    }
}
