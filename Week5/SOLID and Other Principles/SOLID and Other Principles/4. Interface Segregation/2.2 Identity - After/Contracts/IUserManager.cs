using System.Collections.Generic;

namespace InterfaceSegregationIdentityAfter.Contracts
{
    interface IUserManager
    {
        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}
