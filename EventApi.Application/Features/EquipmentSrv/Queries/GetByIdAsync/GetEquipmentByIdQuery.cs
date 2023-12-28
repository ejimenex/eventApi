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
    public class GetEquipmentByIdQueryHandler(IEquipmentRepository _equipmentRepository, IMapper _mapper) : IRequestHandler<GetEquipmentByIdQuery, EquipmentByIdDto>
    {

        public async Task<EquipmentByIdDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _equipmentRepository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new CustomException("There is not equipment with this Id");
            return _mapper.Map<EquipmentByIdDto>(entity);
        }
    }
}
