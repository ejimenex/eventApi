using EventApi.Application.Contract.Persistence;
using EventApi.Application.Exceptions;
using EventApi.Application.Features.UsersSrv.Command.Post;
using EventApi.Domain.Entities.Security;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.UsersSrv.Command.Delete
{
    public class DeleteUserCommand : IRequest<ApiResponse<User>>
    {
        public int Id { get; set; }
    }
    public class DeleteUserCommandHandler(IAsyncRepository<User> userRepository) : IRequestHandler<DeleteUserCommand, ApiResponse<User>>
    {
        public async Task<ApiResponse<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id) ?? throw new CustomException("User Dot Not Exist");
            user.IsDeleted = true;
            await userRepository.UpdateAsync(user);
            return new ApiResponse<User> { Success = true, Message = "User Deleted", Data = user };
        }
    }
}
