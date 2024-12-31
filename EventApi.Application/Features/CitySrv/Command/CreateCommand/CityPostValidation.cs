using EventApi.Application.Contract;
using FluentValidation;

namespace EventApi.Application.Features.CitySrv.Command.CreateCommand
{
    public class CityPostValidation : AbstractValidator<CityPostCommand>
    {
        private readonly ICityRepository _cityRespository;
        public CityPostValidation(ICityRepository cityRespository)
        {
            _cityRespository = cityRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(p => p.CountryId).NotNull().WithMessage("Country Date it's required.");
            RuleFor(c => c).MustAsync(ValidateCityExistExist).WithMessage("This city already exist.");
        }
         private async Task<bool> ValidateCityExistExist(CityPostCommand e, CancellationToken token) => (!await _cityRespository.ExistCity(e.Name));
    }

}
