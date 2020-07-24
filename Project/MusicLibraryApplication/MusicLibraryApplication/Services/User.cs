using System;

namespace MusicLibrary.Application.Services
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        internal User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        
        }
    }
}