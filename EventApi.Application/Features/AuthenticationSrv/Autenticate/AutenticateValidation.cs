using EventApi.Application.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Features.AuthenticationSrv.Autenticate
{
    public class AutenticateValidation : AbstractValidator<AutenticateCommand>
    {
        private readonly IUserRepository _userRepository;
        public AutenticateValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Required").EmailAddress().WithMessage("Email is not valid");
            RuleFor(p => p.Password).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
             .MinimumLength(8).WithMessage("{PropertyName} need to have more than 8 characters")
             .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.");
            RuleFor(c => c).MustAsync(ValidateUserExist).WithMessage("Wrong email, please check and input again!");
        }
        private async Task<bool> ValidateUserExist(AutenticateCommand e, CancellationToken token) => (await _userRepository.ExistEmail(e.Email));
    }
}