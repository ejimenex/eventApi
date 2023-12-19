using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using MediatR;

namespace EventApi.Application.Features.EquipmentSrv.Queries.GetByIdAsync
{
    public class GetEquipmentByIdQuery : IRequest<EquipmentByIdDto>
    {
        public int Id { get; set; }
    }
    public class GetEquipmentByIdQueryHandler : IRequestHandler<GetEquipmentByIdQuery, EquipmentByIdDto>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;
        public GetEquipmentByIdQueryHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }
        public async Task<EquipmentByIdDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _equipmentRepository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new CustomException("There is not equipment with this Id");
            return _mapper.Map<EquipmentByIdDto>(entity);
        }
    }
}
