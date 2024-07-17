using ApwPayroll_Application.Features.DocumentTypes.Queries.GetAllDocumentTypes;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.DocumentTypes.Queries.GetDocumentTypeById
{
    public class GetDocumentTypeByIdQuery:IRequest<Result<GetDocumentTypeDto>>
    {
        public int Id { get; set; }
        public GetDocumentTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetDocumentTypeByIdQueryHandler : IRequestHandler<GetDocumentTypeByIdQuery, Result<GetDocumentTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDocumentTypeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetDocumentTypeDto>> Handle(GetDocumentTypeByIdQuery request, CancellationToken cancellationToken)
        {
          var data =await _unitOfWork.Repository<DocumentType>().GetByIdAsync(request.Id);
            if(data == null)
            {
                return Result<GetDocumentTypeDto>.BadRequest();
            }
            var  mapData= _mapper.Map<GetDocumentTypeDto>(data);
            return Result<GetDocumentTypeDto>.Success(mapData);
        }
    }
}
