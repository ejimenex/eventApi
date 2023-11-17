using EventApi.Application.Contract;
using EventApi.Application.Features.OcupationSrv.Command;
using FluentValidation;

namespace EventApi.Application.Features.SubContractorSrv.Command.PostCommand
{
    public class OcupationPostCommandValidation : AbstractValidator<OcupationPostCommand>
    {
        private readonly IOcupationRepository _ocupationRespository;
        public OcupationPostCommandValidation(IOcupationRepository ocupationRespository)
        {
            _ocupationRespository = ocupationRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(c => c).MustAsync(ValidateOcupationExist).WithMessage("This ocupation already exist.");
        }
        private async Task<bool> ValidateOcupationExist(OcupationPostCommand e, CancellationToken token) => (!await _ocupationRespository.ExistOcupation(e.Name));
    }
}
