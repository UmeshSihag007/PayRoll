using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Branches.Commands.CreateBranchCommands;

public class CreateBranchCommand : IRequest<Result<Branch>>
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
internal class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<Branch>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Branch>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var mapData = _mapper.Map<Branch>(request);
        var data = await _unitOfWork.Repository<Branch>().AddAsync(mapData);
        await _unitOfWork.Save(cancellationToken);
        return Result<Branch>.Success(data, "Create Successfully");
    }

}
