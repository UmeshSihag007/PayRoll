using ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.CreateEmployeeExperiences;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Employees.EmployeeExperiences.Commands.UpdateEmployeeExperience
{
    public class UpdateEmployeeExperienceCommand : IRequest<Result<int>>
    {


        public int Id { get; set; }
        public CreateEmployeeExperiencesCommand command { get; set; }
        public UpdateEmployeeExperienceCommand(int id, CreateEmployeeExperiencesCommand command)
        {
            Id = id;
            this.command = command;
        }
    }
    internal class UpdateEmployeeExperienceCommandHandler : IRequestHandler<UpdateEmployeeExperienceCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeExperienceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateEmployeeExperienceCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeExperience>().GetByIdAsync(request.Id);         
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
            var mapData = _mapper.Map(request.command, data);
       
            await _unitOfWork.Repository<EmployeeExperience>().UpdateAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
