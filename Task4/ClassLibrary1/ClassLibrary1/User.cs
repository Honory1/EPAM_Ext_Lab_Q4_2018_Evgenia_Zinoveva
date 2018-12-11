using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class User : UsersList
    {
        private int Name;
        private int ID;

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
    }
}