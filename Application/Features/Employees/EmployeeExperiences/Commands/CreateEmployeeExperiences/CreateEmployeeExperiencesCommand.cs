using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.CreateEmployeeExperiences;

public class CreateEmployeeExperiencesCommand : IRequest<Result<int>>
{
    public int? Id { get; set; }
    public int EmployeeId { get; set; }

    public string ComanyName { get; set; }
    public string ComanyAddress { get; set; }
    public string Designation { get; set; }
    public string Industry { get; set; }
    public string EmployeeCode { get; set; }
    public decimal AnnualInCome { get; set; }
    public string InsuranceNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletedDate { get; set; }
}
internal class CreateEmployeeExperiencesCommandHandler : IRequestHandler<CreateEmployeeExperiencesCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeExperiencesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateEmployeeExperiencesCommand request, CancellationToken cancellationToken)
    {
        var checkEmployee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.EmployeeId);
        if (checkEmployee == null)
        {
            return Result<int>.BadRequest();
        }
        var mapData = _mapper.Map<EmployeeExperience>(request);
        await _unitOfWork.Repository<EmployeeExperience>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success( mapData.Id, "Created SuccessFully");
    }

}
