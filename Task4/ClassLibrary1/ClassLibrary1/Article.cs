﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Article
    {
        private int Content;
        private int Headline;
        private int IdArticle;
        private int TagsArticle;

        public Blog Blog
        {
            get => default(Blog);
            set
            {
            }
        }

        public void EditArticle()
        {
            throw new System.NotImplementedException();
        }
    }
}