namespace EventApi.Infrasestructure.Filters
{
    public record ActivitiesFilter(string name, DateTime? dateFrom, DateTime? dateTo, int? status);

}
