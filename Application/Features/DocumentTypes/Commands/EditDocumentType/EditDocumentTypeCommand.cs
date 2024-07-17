using ApwPayroll_Application.Features.DocumentTypes.Commands.CreateDocumentType;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.DocumentTypes.Commands.EditDocumentType
{
    public class EditDocumentTypeCommand:IRequest<Result<int>>
    {
        public int Id { get; set; } 
         public   CreateDocumentTypeCommand command;
        public EditDocumentTypeCommand(int id, CreateDocumentTypeCommand command)
        {
            Id = id;
            this.command = command;
        }
    }
    internal class EditDocumentTypeCommandHandler : IRequestHandler<EditDocumentTypeCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(EditDocumentTypeCommand request, CancellationToken cancellationToken)
        {
          var data =await _unitOfWork.Repository<DocumentType>().GetByIdAsync (request.Id);
            if(data == null)
            {
                return Result<int>.BadRequest ();
            }
            var mapData = _mapper.Map(request.command, data);
          

            await _unitOfWork.Repository<DocumentType>().UpdateAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success();
        }
    }
}
