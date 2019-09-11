using System;

namespace CleanCode.PoorMethodSignatures
{
    public class PoorMethodSignatures
    {
        public void Run()
        {
            var userService = new UserService();

            var user = userService.Login("username", "password");
            var anotherUser = userService.GetUser("username");
        }
    }

    public class UserService
    {
        private UserDbContext _dbContext = new UserDbContext();

        public User GetUser(string username)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }

        public User Login(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
            }

            return user;
        }
    }
}
