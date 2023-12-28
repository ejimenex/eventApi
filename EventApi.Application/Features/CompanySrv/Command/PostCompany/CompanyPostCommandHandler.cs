using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.CompanySrv.Command.PostCompany
{
    public class CompanyPostCommandHandler(IMapper _mapper, ICompanyRepository _companyRepository, ICountryRepository _countryRepository) : IRequestHandler<CompanyPostCommand, ApiResponse<CompanyResposeDto>>
    {

        public async Task<ApiResponse<CompanyResposeDto>> Handle(CompanyPostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CompanyPostValidation(_companyRepository, _countryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }

            var entity = _mapper.Map<Company>(request);
            var dto = _mapper.Map<CompanyResposeDto>(request);
            entity.IsDisabled = false;
            entity.UniqueId = Guid.NewGuid();
            await _companyRepository.AddAsync(entity);
            return new ApiResponse<CompanyResposeDto> { Success = true, Message = "The company has been inserted", Object = dto };

        }
    }
}
