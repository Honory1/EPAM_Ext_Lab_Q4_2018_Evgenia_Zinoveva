using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    internal class Moderator : User
    {
        public UsersRoles UsersRoles
        {
            get => default(UsersRoles);
            set
            {
            }
        }

        public void ArticleModeration()
        {
            throw new System.NotImplementedException();
        }

        public void CommentModeration()
        {
            throw new System.NotImplementedException();
        }
    }
}