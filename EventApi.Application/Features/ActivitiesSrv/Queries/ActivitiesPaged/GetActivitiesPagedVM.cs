namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesPaged
{
    public class GetActivitiesPagedVM
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<GetActivitiesPagesDto> Data { get; set; }
    }
}
