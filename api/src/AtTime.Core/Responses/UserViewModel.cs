using AtTime.Core.Models;

namespace AtTime.Core.Responses
{
    public class UserViewModel
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
        }
    }
}
