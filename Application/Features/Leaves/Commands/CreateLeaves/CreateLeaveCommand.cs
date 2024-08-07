using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Leaves.Commands.CreateLeaves
{
    public class CreateLeaveCommand : IRequest<Result<Leave>>
    {
        public int? Id { get; set; }
        public int LeaveTypeId { get; set; }
        public string Reason { get; set; }
        public long ContactNumber { get; set; }
        public bool IsPaid { get; set; }
        public DateTime RequestedDate { get; set; }
        public LeaveStatusEnum LeaveStatus { get; set; }
        public bool IsHalfDay { get; set; }
    }
    internal class CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, Result<Leave>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLeaveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Leave>> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            var leaveType = _unitOfWork.Repository<LeaveType>().GetByIdAsync(request.LeaveTypeId);
            if (leaveType == null)
            {
                return Result<Leave>.BadRequest();
            }
            var mapData = _mapper.Map<Leave>(request);
            var data = await _unitOfWork.Repository<Leave>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<Leave>.Success(data, "Create Successfully");
        }

      
    }
}
