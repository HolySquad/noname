using System;
using System.Drawing;
using Utils;

namespace Domain.Users
{
    public class User
    {
        protected User()
        {
        }

        public User(string name, string passhash)
        {
            Login = name;
            PasswordHash = passhash;
            SignUpDate = DateTime.Today;
            Avatar = null;
        }

        public string Email { get; protected set; }

        public string Login { get; protected set; }

        public DateTime SignUpDate { get; private set; }

        protected string PasswordHash { get; private set; }

        public DateTime LogOutTime { get; protected set; }

        public Bitmap Avatar { get; protected set; }

        protected virtual void ChangePassword()
        {
            //recalculate password hash of some sort in some way
            throw new NotImplementedException();
        }

        private bool ChangeAvatar(Bitmap bmp)
        {
            try
            {
                //some setter rules
                Avatar = new Bitmap(bmp);
                return true;
            }
            catch (Exception e)
            {
                Logger.AddToLog("Failed avatar change.", e);
                //error message of some sort
                //maybe some limits as to what size the avatar should be,
                //or filetype limits
                return false;
            }
        }

        protected virtual void LogOutHandler()
        {
            LogOutTime = DateTime.Now;
        }

        protected virtual void ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}