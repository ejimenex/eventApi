namespace EventApi.Application.Features.ActivitiesSrv.Queries.ActivitiesGetAll
{
    public class GetAllActivitiesDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
