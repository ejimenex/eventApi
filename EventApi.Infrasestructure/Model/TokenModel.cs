namespace EventApi.Infrasestructure.Model
{
    public class TokenModel
    {
        public string UserName { get; set; }
        public Guid TenantId { get; set; }
        public List<string> Pemission { get; set; }
    }
}
