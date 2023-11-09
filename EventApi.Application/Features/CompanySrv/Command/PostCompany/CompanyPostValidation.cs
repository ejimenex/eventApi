using EventApi.Application.Contract;
using EventApi.Application.Features.CompanySrv.Command.PostCompany;
using FluentValidation;

namespace EventApi.Application.Features.UsersSrv.Command.Post
{
    public class CompanyPostValidation : AbstractValidator<CompanyPostCommand>
    {

        private readonly ICountryRepository _countryRepository;
        private readonly ICompanyRepository _compaRepository;
        public CompanyPostValidation(ICompanyRepository compaRepositor, ICountryRepository countryRepository)
        {
            _compaRepository = compaRepositor;
            _countryRepository = countryRepository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required");
            RuleFor(p => p.DocumentNumber).NotEmpty().WithMessage("Document Number it is required");
            RuleFor(p => p.CountryId).NotEqual(0).WithMessage("Country it is required");
            RuleFor(c => c).MustAsync(ValidateCompanyExist).WithMessage("This company already exist");
            RuleFor(c => c).MustAsync(ValidateCutryExist).WithMessage("This country does not exist");
        }
        private async Task<bool> ValidateCompanyExist(CompanyPostCommand e, CancellationToken token) => (!await _compaRepository.ExistCompany(e.Name));
        private async Task<bool> ValidateCutryExist(CompanyPostCommand e, CancellationToken token) => (!await _countryRepository.ExistId(e.CountryId));
    }
}
