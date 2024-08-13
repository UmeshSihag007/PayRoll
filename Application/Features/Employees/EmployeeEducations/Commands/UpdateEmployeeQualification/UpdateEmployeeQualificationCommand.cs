using ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation;
using ApwPayroll_Application.Features.Employees.EmployeeEducations.Quories;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeQualifications.Commands.UpdateEmployeeQualification
{
    public class UpdateEmployeeQualificationCommand : IRequest<Result<EmployeeQualification>>
    {


        public int Id { get; set; }

        public CreateEmployeeEducationCommand Qualification { get; set; }

        public UpdateEmployeeQualificationCommand(int id, CreateEmployeeEducationCommand qualification)
        {
            Id = id;
            Qualification = qualification;
        }
    }
    internal class UpdateEmployeeQualificationCommandHandler : IRequestHandler<UpdateEmployeeQualificationCommand, Result<EmployeeQualification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeQualificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EmployeeQualification>> Handle(UpdateEmployeeQualificationCommand request, CancellationToken cancellationToken)
        {
         
            var data = await _unitOfWork.Repository<EmployeeQualification>().GetByIdAsync(request.Id);
           request.Qualification.EmployeeId=data.EmployeeId;
            if (data == null)
            {
                return Result<EmployeeQualification>.BadRequest();
            }
            var mapData=  _mapper.Map(request.Qualification, data);
            await _unitOfWork.Repository<EmployeeQualification>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return Result<EmployeeQualification>.Success(data, "Update Successfully");
        }
    }
}
