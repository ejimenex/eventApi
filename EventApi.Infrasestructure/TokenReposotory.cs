using EventApi.Infrasestructure.Contract;
using EventApi.Infrasestructure.Model;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace EventApi.Infrasestructure
{
    public class TokenRepository : ITokenService
    {
        private readonly IHttpContextAccessor contextAccessor;
        public TokenRepository(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        public Task<TokenModel> GetTokenData()
        {
            var user = contextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var handler = new JwtSecurityTokenHandler();
            if (user is null)
                throw new ArgumentException("Header request is null");
            user = user.Replace("Bearer ", "");
            var tokenS = handler.ReadToken(user) as JwtSecurityToken;
            var tokenData = tokenS.Claims; 
            var token = new TokenModel();
            token.UserName = tokenData.First(c => c.Type.EndsWith("email")).Value;
            token.TenantId = new Guid(tokenData.First(c => c.Type.EndsWith("tenantId")).Value);
            var permission = tokenData.Where(c => c.Type.EndsWith("Permissions")).ToList();
            var listPermission = new List<string>();
            foreach (var item in permission)
            {
                listPermission.Add(item.Value.ToString());
            }
            token.Pemission = listPermission;
            return Task.FromResult(token);
        }
    }
}
