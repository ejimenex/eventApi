using EventApi.Infrasestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Infrasestructure.Contract
{
    public interface ITokenService
    {
        Task<TokenModel> GetTokenData();
    }
}
