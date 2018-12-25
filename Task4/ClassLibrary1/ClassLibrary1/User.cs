using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class User
    {
        private int name;
        private int id;
        private int email;
        private int role;

        public UsersRoles UsersRoles
        {
            get => default(UsersRoles);
            set
            {
            }
        }

        public void PersonalDataEditing()
        {
            throw new System.NotImplementedException();
        }

        public void Login()
        {
            throw new System.NotImplementedException();
        }

        public void Registration()
        {
            throw new System.NotImplementedException();
        }

        public void Get()
        {
            throw new System.NotImplementedException();
        }
    }
}