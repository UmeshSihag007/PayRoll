using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Leaves.Queries.GetLeaveByIds;

public class GetLeaveByIdQuery : IRequest<Result<Leave>>
{
    public int Id { get; set; }

    public GetLeaveByIdQuery(int id)
    {
        Id = id;
    }
    internal class GetLeaveByIdQueryHandler : IRequestHandler<GetLeaveByIdQuery, Result<Leave>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLeaveByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Leave>> Handle(GetLeaveByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Leave>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<Leave>.BadRequest();
            }
            var mapData = _mapper.Map<Leave>(data);
            return Result<Leave>.Success(mapData);
        }
    }

}
