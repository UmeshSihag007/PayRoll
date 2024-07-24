using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;

namespace ApwPayroll_Application.Features.Employees.EmployeeCouses.Commands.DeleteEmployeeCourses;

public class DeleteEmployeeCourseCommand:IRequest<Result<int>>
{
    public DeleteEmployeeCourseCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}
internal class DeleteEmployeeCourseCommandHandler : IRequestHandler<DeleteEmployeeCourseCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DeleteEmployeeCourseCommand request, CancellationToken cancellationToken)
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
