
using RLocker.Model.Intrefaces;
using System.Collections.Generic;
using System.Linq;

namespace RLocker.Model
{
    public class TokenManager : ITokenManager
    {
        List<string> tokens = null;

        ITokenPersistance tokenPersistance;
        ITokenGenerator generator;

        public TokenManager(ITokenPersistance tokenPersistance, ITokenGenerator generator)
        {
            this.tokenPersistance = tokenPersistance;
            this.generator = generator;
        }
        
        public string GenerateToken()
        {
            var token =  this.generator.GenerateToken();
            tokenPersistance.SaveToken(token);

            var newTokens = new List<string>(tokens);
            newTokens.Add(token);
            tokens = newTokens;

            return token;
        }

        public bool ValidateToken(string token)
        {
            if(tokens == null)
            {
                tokens = tokenPersistance.GetTokens();
            }
            var localTokens = tokens;
            return localTokens.Any(p => p == token);
        }
    }
}