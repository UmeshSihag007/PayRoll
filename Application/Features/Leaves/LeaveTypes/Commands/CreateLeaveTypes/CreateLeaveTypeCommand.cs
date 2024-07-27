using ApwPayroll_Application.Features.Courses.Commands.CreateCourses;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Leaves.LeaveTypes.Commands.CreateLeaveTypes
{
    public class CreateLeaveTypeCommand : IRequest<Result<int>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    internal class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<LeaveType>(request);
            await _unitOfWork.Repository<LeaveType>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
