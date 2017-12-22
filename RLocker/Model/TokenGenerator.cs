using System;
using RLocker.Model.Intrefaces;

namespace RLocker.Model
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
    }
}