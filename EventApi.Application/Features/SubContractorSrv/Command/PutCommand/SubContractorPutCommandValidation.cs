using EventApi.Application.Contract;
using EventApi.Application.Features.SubContractorSrv.Command.PutCommand;
using FluentValidation;

namespace EventApi.Application.Features.SubContractorSrv.Command.PostCommand
{
    public class SubContractorPutCommandValidation : AbstractValidator<SubContractorPutCommand>
    {
        private readonly ISubContractorRepository _subContractorRespository;
        public SubContractorPutCommandValidation(ISubContractorRepository subContractorRespository)
        {
            _subContractorRespository = subContractorRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.DocumentNumber).NotEmpty().WithMessage("Document Number it is required.");
        }
    }
}
