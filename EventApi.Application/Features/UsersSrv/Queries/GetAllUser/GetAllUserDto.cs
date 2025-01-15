namespace EventApi.Application.Features.UsersSrv.Queries.GetAllUser
{
    public class GetAllUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Ocupation { get; set; }
        public string ExternalCode { get; set; }
        public int LoginQuantity { get; set; }
        public DateTime LastLogin { get; set; }
        

    }
}
