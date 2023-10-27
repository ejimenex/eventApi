using EventApi.Infrasestructure.Model;

namespace EventApi.Infrasestructure.Contract
{
    public interface ITokenService
    {
        Task<TokenModel> GetTokenData();
    }
}
