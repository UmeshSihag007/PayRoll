using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Shared;
using AutoMapper;
using Couchbase.Core.Retry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Designations.Commands.CreateDesignation
{
    public class CreateDesignationCommand : IRequest<Result<Designation>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class CreateDesignationCommandHandler : IRequestHandler<CreateDesignationCommand, Result<Designation>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDesignationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Designation>> Handle(CreateDesignationCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Designation>(request);
           var data= await _unitOfWork.Repository<Designation>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<Designation>.Success(data, "Create Successfully");
        }
    }
}
