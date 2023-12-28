using EventApi.Application.Features.EquipmentSrv.Command.PutCommand;
using FluentValidation;

namespace EventApi.Application.Features.EquipmentSrv.Command.PostCommand
{
    public class EquipmentPutCommandValidation : AbstractValidator<EquipmentPutCommand>
    {
        public EquipmentPutCommandValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Code it is required.");
        }
    }
}
