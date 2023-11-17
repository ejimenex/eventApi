namespace EventApi.Application.Features.UsersSrv.Queries.GetAllUser
{
    public class GetAllUserVM
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<GetAllUserDto> Data { get; set; }

    }
}
