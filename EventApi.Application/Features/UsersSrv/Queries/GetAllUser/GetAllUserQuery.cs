using AutoMapper;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using MediatR;

namespace EventApi.Application.Features.UsersSrv.Queries.GetAllUser
{
    public class GetAllUserQuery:IRequest<GetAllUserVM>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public UserFilter Filters { get; set; }
    }
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserVM>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserRepository userRepository,IMapper mapper)
        {
                _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetAllUserVM> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var list = await this._userRepository.GetPaged(request.Filters, request.Page, request.Size);
            var count = await this._userRepository.GetCount(request.Filters);
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
