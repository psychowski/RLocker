namespace RLocker.Model.Intrefaces
{
    public interface ITokenManager
    {
        bool ValidateToken(string token);
        string GenerateToken();
    }
}
