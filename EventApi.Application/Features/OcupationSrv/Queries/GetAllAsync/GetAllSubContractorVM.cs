namespace EventApi.Application.Features.OcupationSrv.Queries.GetAllAsync
{
    public class GetAllOcupationVM
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<GetAllOcupationDto> Data { get; set; }
    }
}
