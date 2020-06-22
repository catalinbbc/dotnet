using System.Collections.Generic;

namespace InterfaceSegregationIdentityAfter
{
    using InterfaceSegregationIdentityAfter.Contracts;

    public class UserManager : IUserManager
    {
        public IEnumerable<IUser> GetAllUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public IUser GetUserByName(string name)
        {
            throw new System.NotImplementedException();
        }

    }
}
