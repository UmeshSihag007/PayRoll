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

namespace ApwPayroll_Application.Features.Employees.Commands.UpdateIsLoginAccess
{
    public class UpdateIsLoginAccessCommand:IRequest<Result<int>>
    {
        public UpdateIsLoginAccessCommand(int id, bool isLoginAccess)
        {
            Id = id;
            IsLoginAccess = isLoginAccess;
        }

        public int Id { get; set; }
         public bool IsLoginAccess { get; set; } 

    }

    internal class UpdateIsLoginAccessCommandHandler : IRequestHandler<UpdateIsLoginAccessCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIsLoginAccessCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateIsLoginAccessCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);
            if(data== null)
            {
                return Result<int>.BadRequest();
            }
              data.IsLoginAccess=request.IsLoginAccess;

            await _unitOfWork.Repository<Employee>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken);
              return  Result<int>.Success(data.Id,"  Status Updated");    


        }
    }
}
