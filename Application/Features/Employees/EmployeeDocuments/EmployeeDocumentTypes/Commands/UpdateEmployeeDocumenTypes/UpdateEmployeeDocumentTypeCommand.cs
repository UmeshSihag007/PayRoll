using ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.CreateEmployeeDocumentTypes;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeDocuments.EmployeeDocumentTypes.Commands.UpdateEmployeeDocumenTypes
{
    public class UpdateEmployeeDocumentTypeCommand : IRequest<Result<EmployeeDocumentType>>
    {
        public int Id { get; set; }
        public CreateEmployeeDocumentTypeCommand command;

        public UpdateEmployeeDocumentTypeCommand(int id, CreateEmployeeDocumentTypeCommand command)
        {
            Id = id;
            this.command = command;
        }
    }
    internal class UpdateEmployeeDocumentTypeCommandHandler : IRequestHandler<UpdateEmployeeDocumentTypeCommand, Result<EmployeeDocumentType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EmployeeDocumentType>> Handle(UpdateEmployeeDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<EmployeeDocumentType>().GetByIdAsync(request.Id);
            if (data == null)
            {
                return Result<EmployeeDocumentType>.BadRequest();
            }
            var mapData = _mapper.Map(request.command, data);


            await _unitOfWork.Repository<EmployeeDocumentType>().UpdateAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<EmployeeDocumentType>.Success(data, "Update Successfully");
        }
    }
}

