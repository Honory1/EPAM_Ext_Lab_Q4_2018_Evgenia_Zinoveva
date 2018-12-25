using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    internal class Administrator : User
    {
        /// <value></value>
        public UsersRoles UsersRoles
        {
            get => default(UsersRoles);
            set
            {
            }
        }

        public void UsersMenegment()
        {
            throw new System.NotImplementedException();
        }
    }
}