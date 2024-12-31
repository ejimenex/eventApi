using EventApi.Application.Contract;
using FluentValidation;

namespace EventApi.Application.Features.EquipmentSrv.Command.PostCommand
{
    public class EquipmentPostCommandValidation : AbstractValidator<EquipmentPostCommand>
    {
        private readonly IEquipmentRepository _equipmentRespository;
        public EquipmentPostCommandValidation(IEquipmentRepository equipmentRespository)
        {
            _equipmentRespository = equipmentRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Code it is required.");
            RuleFor(c => c).MustAsync(ValidateSubContractorExistExist).WithMessage("This sub-contractor already exist.");
        }
        private async Task<bool> ValidateSubContractorExistExist(EquipmentPostCommand e, CancellationToken token) => 
            (!await _equipmentRespository.ExistEquipent(e.Name));
    }
}
