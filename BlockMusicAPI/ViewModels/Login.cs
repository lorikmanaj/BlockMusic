using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockMusicAPI.ViewModels
{
    public class Login
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Login() { }

        public Login(string userName, string password)
        {
            UserName = UserName;
            Password = password;
        }

        public Login(int userID, string userName)
        {
            UserID = userID;
            UserName = userName;
        }

        public Login(int userID, string userName, string password)
        {
            UserID = userID;
            UserName = UserName;
            Password = password;
        }
    }
}
