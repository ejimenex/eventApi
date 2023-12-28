using FluentValidation;

namespace EventApi.Application.Features.ActivitiesSrv.Command.ActivitiesPut
{
    public class ActivitiesPutValidation : AbstractValidator<ActivitiesPutCommand>
    {
        public ActivitiesPutValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.EstimatedEndDate).NotNull().WithMessage("Estimate End Date it's required.");
        }

    }
}
