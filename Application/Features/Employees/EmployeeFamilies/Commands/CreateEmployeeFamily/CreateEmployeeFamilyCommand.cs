using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApwPayroll_Application.Features.Employees.EmployeeFamilies.Commands.CreateEmployeeFamily
{
    public class CreateEmployeeFamilyCommand : IRequest<Result<int>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnum Gender { get; set; }

    }
    internal class CreateEmployeeFamilyCommandHandler : IRequestHandler<CreateEmployeeFamilyCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateEmployeeFamilyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<EmployeeFamily>(request);
            mapData.IsActive = true;
            mapData.RelationTypeId = 3;
        
          await _unitOfWork.Repository<EmployeeFamily>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
