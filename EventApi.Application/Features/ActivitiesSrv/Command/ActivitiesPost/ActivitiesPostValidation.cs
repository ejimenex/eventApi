using EventApi.Application.Contract;
using EventApi.Application.Features.SubContractorSrv.Command.PostCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPost
{
    public class ActivitiesPostValidation : AbstractValidator<ActivitiesPostCommand>
    {
        private readonly IActivitiesRepository _activitiesRespository;
        public ActivitiesPostValidation(IActivitiesRepository activitiesRespository)
        {
            _activitiesRespository = activitiesRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.EstimatedEndDate).NotNull().WithMessage("Estimate End Date it's required.");
        }
       // private async Task<bool> ValidateSubContractorExistExist(SubContractorPostCommand e, CancellationToken token) => (!await _subContractorRespository.ExistESubContractor(e.Name));
    }

}
