using System;
using System.Collections.Generic;
using System.Drawing;

namespace NoName
{

    /* don't like this class
       don't know why
       this two private List<int> is annoying me >.<
     * 
     * not sure if this class included in mapping
    */

    public class User
    {
        private List<int> _favouriteContentIDs;
        private List<int> NewContentSinceLastVisit;
        
        protected User()
        {
        }

        public User(string name, string passhash)
        {
            UserName = name;
            PasswordHash = passhash;
            SignUpDate = DateTime.Today;
            Avatar = null;
        }


        public string UserName { get; protected set; }

        public DateTime SignUpDate { get; private set; }

        protected string PasswordHash { get; private set; }


        public DateTime LogOutTime { get; protected set; }
        public Bitmap Avatar { get; private set; }

        private bool ChangePassword()
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
                //error message of some sort
                //maybe some limits as to what size the avatar should be,
                //or filetype limits
                return false;
            }
        }

        private void LogOutHandler()
        {
            LogOutTime = DateTime.Now;
        }
    }
}