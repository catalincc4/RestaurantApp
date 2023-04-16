using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entities
{
  public  enum Role
    {
        Admin,
        Employee
    }
    public class User
    {
        private String username;
        private String password;
        private String name;
        private Role role;

        public User(string username, string password, string name, Role role)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.role = role;
        }

        public User()
        {
        }

        public String getUserName()
        {
            return username;
        }
        
        public String getPassword()
        {
            return password;
        }

        public String getName()
        {
            return name;
        }

        public Role getRole()
        {
            return role;
        }

        public void setUsername(String username)
        {
            this.username=username;
        }
        public void setPassword(String password)
        {
            this.password = password;
        }
        public void setName(String name)
        {
            this.name = name;
        }

        public void setRole(Role role)
        {
            this.role = role;
        }


    }
}
