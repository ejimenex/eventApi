﻿using EventApi.Application.Contract;
using FluentValidation;

namespace EventApi.Application.Features.UsersSrv.Command.Post
{
    public class UserValidation : AbstractValidator<UserCommand>
    {
        private readonly IUserRepository _userRepository;
        public UserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Required").EmailAddress().WithMessage("Email is not valid");
            RuleFor(p => p.Password).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
             .MinimumLength(8).WithMessage("{PropertyName} need to have more than 8 characters")
             .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.");
            RuleFor(p => p.FullName).NotEmpty().WithMessage("Fullname Required");
            RuleFor(c => c).MustAsync(ValidateUserExist).WithMessage("This email already exist");
        }
        private async Task<bool> ValidateUserExist(UserCommand e, CancellationToken token) => (!await _userRepository.ExistEmail(e.Email));
    }
}
