using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.EmployeeEducations.Quories.GetAllEmployeeQualifications
{
    public class GetEmployeeQualificationQuery : IRequest<Result<List<EmployeeQualification>>>
    {
        public int Id { get; set; }

        public GetEmployeeQualificationQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetEmployeeQualificationQueryHandler : IRequestHandler<GetEmployeeQualificationQuery, Result<List<EmployeeQualification>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEmployeeQualificationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<EmployeeQualification>>> Handle(GetEmployeeQualificationQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeQualification>().Entities.Where(x=>x.EmployeeId==request.Id &&  x.IsDeleted==false).ToListAsync();
            if (data == null)
            {
                return Result<List<EmployeeQualification>>.NotFound();
            }

            return Result<List<EmployeeQualification>>.Success(data);
        }
    }
}
