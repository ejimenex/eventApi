using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.EquipmentSrv.Command.PostCommand
{
    public class EquipmentPostCommandHandler(IMapper _mapper, IEquipmentRepository _equipmentRepository) : IRequestHandler<EquipmentPostCommand, ApiResponse<EquipmentPostCommandDto>>
    {

        public async Task<ApiResponse<EquipmentPostCommandDto>> Handle(EquipmentPostCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Equipment>(request);
            var dto = _mapper.Map<EquipmentPostCommandDto>(request);
            await _equipmentRepository.AddAsync(entity);
            return new ApiResponse<EquipmentPostCommandDto> { Success = true, Message = "The equipment has been inserted", Data = dto };

        }
    }
}
