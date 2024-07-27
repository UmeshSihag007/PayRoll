using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Menus.MenuTypes.Commands.CreateMenuType
{
    public class CreateMenuTypeCommand:IRequest<Result<MenuType>>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    internal class CreateMenuTypeCommandHandler : IRequestHandler<CreateMenuTypeCommand, Result<MenuType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MenuType>> Handle(CreateMenuTypeCommand request, CancellationToken cancellationToken)
        {
            var mapData= _mapper.Map<MenuType>(request);
            var data = await _unitOfWork.Repository<MenuType>().AddAsync(mapData);
            return Result<MenuType>.Success(data, "Create Successfully");
        }
    }
}
