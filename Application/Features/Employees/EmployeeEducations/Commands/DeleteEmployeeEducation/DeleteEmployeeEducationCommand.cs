using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.DeleteEmployeeEducation
{
    public class DeleteEmployeeEducationCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public DeleteEmployeeEducationCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteEmployeeEducationCommandHandler : IRequestHandler<DeleteEmployeeEducationCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeEducationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeQualification>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
            await _unitOfWork.Repository<EmployeeQualification>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
