using ApwPayroll_Application.Features.Employees.EmployeeFamilies.Queries.GetByEmployeeIdFamilyDetail;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeFamilies.Queries.GetByEmployeeFamilyDetails
{
    public class GetByEmployeeFamilyDetailQuery : IRequest<Result<GetEmployeeFamilyDetailDto>>
    {
        public int Id { get; set; }

        public GetByEmployeeFamilyDetailQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetByEmployeeFamilyDetailQueryHandler : IRequestHandler<GetByEmployeeFamilyDetailQuery, Result<GetEmployeeFamilyDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByEmployeeFamilyDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetEmployeeFamilyDetailDto>> Handle(GetByEmployeeFamilyDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeFamily>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<GetEmployeeFamilyDetailDto>.BadRequest();
            }
            var mapData = _mapper.Map<GetEmployeeFamilyDetailDto>(data);
            return Result<GetEmployeeFamilyDetailDto>.Success(mapData);
        }
    }
}
