using System;

namespace Domain.Users
{
    public class Admin : User
    {
        protected Admin()
        {
        }

        private void BlockUser()
        {
            throw new NotImplementedException();
        }

        private void UnblockUser()
        {
            throw new NotImplementedException();
        }
    }
}