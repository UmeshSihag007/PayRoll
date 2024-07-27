using ApwPayroll_Application.Features.Designations.Commands.CreateDesignation;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Designations.Commands.UpdateDesignation;

public class UpdateDesignationCommand : IRequest<Result<Designation>>
{
    public UpdateDesignationCommand(int id, CreateDesignationCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateDesignationCommand command { get; set; }

}
internal class UpdateDesignationCommandHandler : IRequestHandler<UpdateDesignationCommand, Result<Designation>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDesignationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Designation>> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Designation>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<Designation>.BadRequest();
        }
        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<Designation>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Designation>.Success(data, "Update Successfully");
    }
}
