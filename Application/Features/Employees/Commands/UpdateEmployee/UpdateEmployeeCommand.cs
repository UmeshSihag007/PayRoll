using ApwPayroll_Application.Features.Employees.Commands.CreateEmployee;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApwPayroll_Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Result<Employee>>
    {
        public UpdateEmployeeCommand(int employeeId, CreateEmployeeCommand command)
        {
            EmployeeId = employeeId;
            Command = command;
        }

        public int EmployeeId { get; set; }
        public CreateEmployeeCommand Command { get; set; }

    }
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<Employee>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Employee>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Employee>().Entities.Where(x=> x.Id== request.EmployeeId &&  x.IsDeleted==false).Include(x=>x.EmployeeDepartments).Include(x=>x.EmployeeDesignations).FirstOrDefaultAsync();


            if(request.Command.DepartmentId!=0  &&   request.Command.DepartmentId!=null)
            {
                data.AddIfNotDepartmentExists([request.Command.DepartmentId]);
                await _unitOfWork.Save(cancellationToken);
            }
            if(request.Command.DesignationId!=0  && request.Command.DesignationId != null)
            {
                data.AddIfNotDesignationExists([request.Command.DesignationId]);     
                await _unitOfWork.Save(cancellationToken);  
            }

           _mapper.Map(request.Command, data);
            await _unitOfWork.Repository<Employee>().UpdateAsync(data);
            await _unitOfWork.Save(cancellationToken); 


            return Result<Employee>.Success( data,"Updated.");
        }
    }
}
