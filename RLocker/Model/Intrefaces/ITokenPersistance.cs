using System.Collections.Generic;

namespace RLocker.Model.Intrefaces
{
    public interface ITokenPersistance
    {
        List<string> GetTokens();

        void SaveToken(string token);
    }
}
