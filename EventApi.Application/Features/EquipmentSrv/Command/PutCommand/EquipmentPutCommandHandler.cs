using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using MediatR;

namespace EventApi.Application.Features.EquipmentSrv.Command.PutCommand
{
    public class EquipmentPutCommandHandler(IMapper _mapper, IEquipmentRepository _equipmentRepository) : IRequestHandler<EquipmentPutCommand, Unit>
    {
        public async Task<Unit> Handle(EquipmentPutCommand request, CancellationToken cancellationToken)
        {
            var entity = await _equipmentRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, entity, typeof(EquipmentPutCommand), typeof(Equipment));
            await _equipmentRepository.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
