using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using EventApi.Infrasestructure.Model;
using MediatR;

namespace EventApi.Application.Features.UsersSrv.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<ApiResponse<GetAllUserVM>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public UserFilter Filters { get; set; }
    }
    public class GetAllUserQueryHandler(IUserRepository _userRepository, IMapper _mapper) : IRequestHandler<GetAllUserQuery, ApiResponse<GetAllUserVM>>
    {
        public async Task<ApiResponse<GetAllUserVM>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var (user,count) = await _userRepository.GetPaged(request.Filters, request.Page, request.Size);
            var data = _mapper.Map<List<GetAllUserDto>>(user);

            var result= new GetAllUserVM()
            {
                Count = count,
                Size = Math.Min(request.Size, 10),
                Page = Math.Max(request.Page, 1),
                Data = data
            };
            return new ApiResponse<GetAllUserVM> {Message=string.Empty,Data=result };
        }
    }
}
