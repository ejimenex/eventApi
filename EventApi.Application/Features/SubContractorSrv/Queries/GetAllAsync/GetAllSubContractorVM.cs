namespace EventApi.Application.Features.SubContractorSrv.Queries.GetAllAsync
{
    public class GetAllSubContractorVM
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<GetAllSusContractorDto> Data { get; set; }
    }
}
