using AtTime.Core.Models;

namespace AtTime.Core.Responses
{
    public class LoginViewModel
    {
        public UserViewModel User { get; private set; }
        public string Token { get; private set; }

        public LoginViewModel(User user, string token)
        {
            User = new UserViewModel(user);
            Token = token;
        }
    }
}
