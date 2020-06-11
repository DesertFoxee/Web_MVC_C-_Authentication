using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authrz.Models
{
    public class User
    {
        private string username;
        private string password;
        private string role;

        public User(string rol)
        {
            role = rol;
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}