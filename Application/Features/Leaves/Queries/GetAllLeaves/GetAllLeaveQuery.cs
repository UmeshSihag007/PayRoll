using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Leaves.Queries.GetAllLeaves;

public class GetAllLeaveQuery : IRequest<Result<List<Leave>>>
{
}
internal class GetAllLeaveQueryHandler : IRequestHandler<GetAllLeaveQuery, Result<List<Leave>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllLeaveQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<Leave>>> Handle(GetAllLeaveQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Leave>().Entities.Where(x => x.IsDeleted == false).Include(x => x.LeaveType).ToListAsync();
        if (data == null)
        {
            return Result<List<Leave>>.NotFound();
        }

        return Result<List<Leave>>.Success(data);
    }
}
