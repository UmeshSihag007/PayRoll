using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Leaves;
using ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApwPayroll_Application.Features.Leaves.LeaveResponseStatues.Commands.CreateLeaveResponseStatues
{
    public class CreateLeaveResponeStatusCommand : IRequest<Result<LeaveResponseStatus>>
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Leave is required.")]
        public int LeaveId { get; set; }
        public int? ResponseById { get; set; }
        public string? ResponseRemark { get; set; }
        public LeaveStatusEnum LeaveStatus { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int? ForwordId { get; set; }
    }
    internal class CreateLeaveResponeStatusCommandHandler : IRequestHandler<CreateLeaveResponeStatusCommand, Result<LeaveResponseStatus>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLeaveResponeStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<LeaveResponseStatus>> Handle(CreateLeaveResponeStatusCommand request, CancellationToken cancellationToken)
        {
            var leave = await _unitOfWork.Repository<Leave>().GetByIdAsync(request.LeaveId);
            if (leave == null)
            {
                return Result<LeaveResponseStatus>.BadRequest();
            }

            var mapData = _mapper.Map<LeaveResponseStatus>(request);
            var data = await _unitOfWork.Repository<LeaveResponseStatus>().AddAsync(mapData);

            await _unitOfWork.Save(cancellationToken);

            return Result<LeaveResponseStatus>.Success(data, "Create Successfully");
        }
    }
}
