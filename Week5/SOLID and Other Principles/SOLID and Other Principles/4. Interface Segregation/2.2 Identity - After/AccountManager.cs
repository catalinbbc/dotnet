namespace InterfaceSegregationIdentityAfter
{
    using System.Collections.Generic;

    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountManager : IAccount
    {
        public bool RequireUniqueEmail { get; set; }

        public int MinRequiredPasswordLength { get; set; }

        public int MaxRequiredPasswordLength { get; set; }

        public void Register(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }


    }
}
