namespace EventApi.Application.Features.CompanySrv.Command.PostCompany
{
    public class CompanyResposeDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string DocumentNumber { get; set; }
        public int CountryId { get; set; }
    }
}
