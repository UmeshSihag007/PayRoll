using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Domain.Entities.Menus.MenuTypes;
using ApwPayroll_Shared;
using AutoMapper;
using MediatR;

namespace ApwPayroll_Application.Features.Menus.MenuTypes.Queries.GetMenuTypes
{
    public class GetMenuTypeQuery : IRequest<Result<List<LookUpDto>>>;

    internal class GetMenuTypeQueryHandler : IRequestHandler<GetMenuTypeQuery, Result<List<LookUpDto>>>
{
        private readonly IGenericRepository<MenuType> _repository;
        private readonly IMapper _mapper;

        public GetMenuTypeQueryHandler(IGenericRepository<MenuType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<LookUpDto>>> Handle(GetMenuTypeQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var mapData=_mapper.Map<List<LookUpDto>>(data);
            return Result<List<LookUpDto>>.Success(mapData);
        }
    }
}
