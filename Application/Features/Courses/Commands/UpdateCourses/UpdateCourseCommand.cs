using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Courses.Commands.UpdateCourses;

public class UpdateCourseCommand : IRequest<Result<Course>>
{
    public UpdateCourseCommand(int id, CreateCoursesCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateCoursesCommand command { get; set; }

}
internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Result<Course>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Course>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Course>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<Course>.BadRequest();
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<Course>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Course>.Success(data,"Update Successfully");
    }
}
