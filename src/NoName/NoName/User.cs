using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName
{
    class User
    {
        private string passwordHASH;
        private DateTime signupdate;
        private List<int> NewContentSinceLastVisit;
        private List<int> FavouriteContentIDs;


        public string UserName { get; }
        public DateTime SignUpDate
        {
            get { return signupdate; }
            private set { signupdate = value; }
        }

        protected string PasswordHASH
        {
            get { return passwordHASH; }
            private set { passwordHASH = value; }
        }

        
        public DateTime LogOutTime { get; protected set; }
        public Bitmap Avatar { get; private set; }

        public User() { }
        public User(string name, string passhash)
        {
            UserName = name;
            PasswordHASH = passhash;
            SignUpDate = DateTime.Today;
            Avatar = null;
        }

        private bool ChangePassword()
        {
            //recalculate password hash of some sort in some way
            throw new System.NotImplementedException();
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
            LogOutTime = DateTime.Now;;
        }
    }
}
