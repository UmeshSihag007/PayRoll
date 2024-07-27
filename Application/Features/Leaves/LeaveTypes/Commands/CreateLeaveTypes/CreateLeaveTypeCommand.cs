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
    public class CreateLeaveTypeCommand : IRequest<Result<LeaveType>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    internal class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Result<LeaveType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<LeaveType>> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<LeaveType>(request);
         var data=   await _unitOfWork.Repository<LeaveType>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<LeaveType>.Success(data, "Create Successfully");
        }
    }
}
