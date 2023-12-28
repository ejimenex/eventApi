using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using MediatR;

namespace EventApi.Application.Features.UsersSrv.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<GetAllUserVM>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public UserFilter Filters { get; set; }
    }
    public class GetAllUserQueryHandler(IUserRepository _userRepository, IMapper _mapper) : IRequestHandler<GetAllUserQuery, GetAllUserVM>
    {
        public async Task<GetAllUserVM> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var list = await _userRepository.GetPaged(request.Filters, request.Page, request.Size);
            var count = await _userRepository.GetCount(request.Filters);
            var data = _mapper.Map<List<GetAllUserDto>>(list);

            return new GetAllUserVM()
            {
                Count = count,
                Size = request.Size > 10 ? 10 : request.Size,
                Page = request.Page < 1 ? 1 : request.Page,
                Data = data
            };
        }
    }
}
