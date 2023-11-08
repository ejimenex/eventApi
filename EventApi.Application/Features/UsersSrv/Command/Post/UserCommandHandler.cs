using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Application.Exceptions;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.UsersSrv.Command.Post
{
    public class UserCommandHandler: IRequestHandler<UserCommand, ApiResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserCommandHandler(IUserRepository userRepository,IMapper mapper)
        {
                _userRepository = userRepository;
                _mapper = mapper;
        }

        public async Task<ApiResponse<UserDto>> Handle(UserCommand request, CancellationToken cancellationToken)
        {

            var validator = new UserValidation(this._userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new FriendlyException(validationResult);
            }
            var entity = _mapper.Map<User>(request);
            var dto = _mapper.Map<UserDto>(request);
            await _userRepository.AddAsync(entity);
            return new ApiResponse<UserDto> {Success = true, Message = "El usuario ha sido insertado", Object = dto};
        }
    }
}
