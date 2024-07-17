using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.GradeTypeEnums;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeEducations.Commands.CreateEmployeeEducation
{
    public class CreateEmployeeEducationCommand : IRequest<Result<int>>
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public int CourseId { get; set; }
        public string? Institution { get; set; }
        public int? LocationId { get; set; }
        public string? UniversityBoard { get; set; }
        public decimal ObtainMarks { get; set; }
        public decimal TotalMarks { get; set; }
        public string? Specification { get; set; }
        public int FromDate { get; set; }
        public int ToDate { get; set; }
    }
    internal class CreateEmployeeEducationCommandHandler : IRequestHandler<CreateEmployeeEducationCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeEducationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
   
            var checkEmplyee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);
            if (checkEmplyee == null)
            {
                return Result<int>.BadRequest($"Invalid Employee Id :{request.EmployeeId}");
            }
            var mapData = _mapper.Map<EmployeeQualification>(request);
            mapData.GradeType = GradeTypeEnum.A;
            var data = await _unitOfWork.Repository<EmployeeQualification>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();

        }
    }
}
