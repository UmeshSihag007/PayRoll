using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Courses.Commands.CreateCourses;

public class CreateCoursesCommand : IRequest<Result<Course>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
internal class CreateCoursesCommandHandler : IRequestHandler<CreateCoursesCommand, Result<Course>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCoursesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Course>> Handle(CreateCoursesCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<Course>(request);
       var data =await _unitOfWork.Repository<Course>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Course>.Success(data, "Create Successfully");
    }
}
