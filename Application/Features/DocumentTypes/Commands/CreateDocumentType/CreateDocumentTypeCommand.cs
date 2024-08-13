using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.DocumentTypes.Commands.CreateDocumentType
{
    public class CreateDocumentTypeCommand : IRequest<Result<DocumentType>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, Result<DocumentType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<DocumentType>> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<DocumentType>(request);
            var data = await _unitOfWork.Repository<DocumentType>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<DocumentType>.Success(data, "Create Successfully");
        }
    }
}
