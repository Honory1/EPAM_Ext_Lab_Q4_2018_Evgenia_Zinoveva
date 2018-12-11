using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Blog
    {
        public User User
        {
            get => default(User);
            set
            {
            }
        }

        public void BlogCreate()
        {
            throw new System.NotImplementedException();
        }

        public void BlogDelete()
        {
            throw new System.NotImplementedException();
        }

        public void ArticleCreate()
        {
            throw new System.NotImplementedException();
        }

        public void ArticleDelete()
        {
            throw new System.NotImplementedException();
        }
    }
}