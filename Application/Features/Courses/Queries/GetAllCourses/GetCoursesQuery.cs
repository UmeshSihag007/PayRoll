using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Courses.Queries.GetAllCourses;

public class GetCoursesQuery : IRequest<Result<List<Course>>>
{
}
internal class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, Result<List<Course>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<Course>>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Course>().GetAllAsync();
        if (data == null)
        {
            return Result<List<Course>>.NotFound();
        }

        return Result<List<Course>>.Success(data);
    }
}
