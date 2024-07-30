    using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.DocumentTypes.Queries.GetAllDocumentTypes
{
    public class GetAllDocumentTypeQuery : IRequest<Result<List<GetDocumentTypeDto>>>
    {
    }
    internal class GetAllDocumentTypeQueryHandler : IRequestHandler<GetAllDocumentTypeQuery, Result<List<GetDocumentTypeDto>>>
{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllDocumentTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<List<GetDocumentTypeDto>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<DocumentType>().GetAllAsync();
            if (data.Count == 0)
            {
                return Result<List<GetDocumentTypeDto>>.NotFound();
            }
            var mapData = _mapper.Map<List<GetDocumentTypeDto>>(data);
            return Result<List<GetDocumentTypeDto>>.Success(mapData);
        }
    }
}
