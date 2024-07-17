using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeQualifications.Commands.UpdateEmployeeQualification
{
    public class UpdateEmployeeQualificationCommand : IRequest<Result<int>>
    {


        public int Id { get; set; }

        public CreateEmployeeEducationCommand Qualification { get; }

        public UpdateEmployeeQualificationCommand(int id, CreateEmployeeEducationCommand qualification)
        {
            Id = id;
            Qualification = qualification;
        }
    }
    internal class UpdateEmployeeQualificationCommandHandler : IRequestHandler<UpdateEmployeeQualificationCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeQualificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateEmployeeQualificationCommand request, CancellationToken cancellationToken)
        {
            var checkEmplyee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Qualification.EmployeeId);
            if (checkEmplyee == null)
            {
                return Result<int>.BadRequest($"Invalid Employee Id :{request.Qualification.EmployeeId}");
            }
            var data = await _unitOfWork.Repository<EmployeeQualification>().GetByIdAsync(request.Id);
      
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
            var mapData = _mapper.Map(request.Qualification, data);
            await _unitOfWork.Repository<EmployeeQualification>().UpdateAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
