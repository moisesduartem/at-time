namespace AtTime.JwtAuthentication.Services
{
    public interface ITokenService
    {
        public string GenerateToken(string name, string role);
    }
}