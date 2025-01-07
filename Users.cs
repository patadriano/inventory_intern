using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Inventory
{
    public class Users
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
    public class Post
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostDesc { get; set; }
    }
}