using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using MediatR;

namespace ApwPayroll_Application.Features.Courses.Commands.DeleteCourses;

public class DeleteCourseCommand : IRequest<Result<int>>
{
    public DeleteCourseCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Course>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.NotFound();
        }
        await _unitOfWork.Repository<Course>().DeleteAsync(data);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();

    }
}
