using ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Commands.UpdateBranchCommands;

public class UpdateBranchCommand : IRequest<Result<int>>
{
    public UpdateBranchCommand(int id, CreateBranchCommand command)
    {
        Id = id;
        this.command = command;
    }

    public int Id { get; set; }
    public CreateBranchCommand command { get; set; }

}
internal class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repository<Branch>().GetByIdAsync(request.Id);
        if (data == null)
        {
            return Result<int>.BadRequest();
        }

        var mapData = _mapper.Map(request.command, data);
        await _unitOfWork.Repository<Branch>().UpdateAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success();
    }

}
