using EventApi.Application.Contract;
using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using FluentValidation;

namespace EventApi.Application.Features.SubContractorSrv.Command.PostCommand
{
    public class SubContractorPostCommandValidation : AbstractValidator<SubContractorPostCommand>
    {
        private readonly ISubContractorRepository _subContractorRespository;
        public SubContractorPostCommandValidation(ISubContractorRepository subContractorRespository)
        {
            _subContractorRespository = subContractorRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.DocumentNumber).NotEmpty().WithMessage("Document Number it is required.");
            RuleFor(c => c).MustAsync(ValidateSubContractorExistExist).WithMessage("This sub-contractor already exist.");
        }
        private async Task<bool> ValidateSubContractorExistExist(SubContractorPostCommand e, CancellationToken token) => (!await _subContractorRespository.ExistESubContractor(e.Name));
    }
}
