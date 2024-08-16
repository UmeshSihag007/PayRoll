using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Documents.DocumentTypes;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.CreateEmployeeDocumentTypes
{

    public class CreateEmployeeDocumentTypeCommand : IRequest<Result<EmployeeDocumentType>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Heading { get; set; } = ",";
        public bool IsCodeRequired { get; set; }=false;

        public bool IsDocumentRequired { get; set; }=false ;
    }
    internal class CreateEmployeeDocumentTypeCommandHandler : IRequestHandler<CreateEmployeeDocumentTypeCommand, Result<EmployeeDocumentType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateEmployeeDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<EmployeeDocumentType>> Handle(CreateEmployeeDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<EmployeeDocumentType>(request);
            var data = await _unitOfWork.Repository<EmployeeDocumentType>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<EmployeeDocumentType>.Success(data, "Create Successfully");
        }
    }
}
