using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.DocumentTypes.Commands.DeleteDocumentType
{
    public class DeleteDocumentTypeCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeleteDocumentTypeCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDocumentTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
           var data =await _unitOfWork.Repository<DocumentType>().GetByIdAsync(request.Id); 
            if (data == null)
            {
                return Result<int>.BadRequest();
            }
            await _unitOfWork.Repository<DocumentType>().DeleteAsync(data);
            await _unitOfWork.Save(cancellationToken);
            return  Result<int>.Success();  
        }
    }
}
