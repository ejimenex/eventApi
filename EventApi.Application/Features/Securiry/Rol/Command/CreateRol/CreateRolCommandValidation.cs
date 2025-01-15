using EventApi.Application.Contract;
using EventApi.Application.Contract.Persistence;
using EventApi.Application.Features.OcupationSrv.Command;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.Securiry.Rol.Command.CreateRol
{
    public class CreateRolCommandValidation : AbstractValidator<CreateRolCommand>
    {
        private readonly IAsyncRepository<Role> _roleRespository;
        ITokenService _tokenService;
        public CreateRolCommandValidation(IAsyncRepository<Role> roleRespository,ITokenService tokenService)
        {
            _roleRespository = roleRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is Required.");
            RuleFor(c => c).MustAsync(ValidateRolExist).WithMessage("This role already exist.");
        }
        private async Task<bool> ValidateRolExist(CreateRolCommand e, CancellationToken token) => (!await _roleRespository.ExistAsync(c=> c.Name.Trim().ToLower().Equals
        (e.Name.Trim().ToLower()) && c.TenantId.Equals(_tokenService.GetTokenData().Result.TenantId)));
    }
}
