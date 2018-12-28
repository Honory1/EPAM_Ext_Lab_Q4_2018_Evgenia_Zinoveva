namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User : IBaseRepository<User>//todo pn user отдельно, UserRepository отдельно. Не нужно смешивать доменную сущность и DAL сущность. Разнести на два класса
    {
        public string name;
        public int id;
        public string email;
        public string role;

        public User()
        {
            string Name = null;
            int Id = -1;
            string Email = null;
            string Role = null;
        }

        public User(int id, string name, string email, string role)
        {
            string Name = name;
            int Id = id;
            string Email = email;
            string Role = role;
        }

        private List<User> users = new List<User>();

        public void LoadUser()
        {
            users.Add(new User() { id = 1, name = "john", email = "hj@hj", role = "admin" });
            users.Add(new User() { id = 2, name = "kris", email = "ol@ol", role = "moderator" });
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

        public User Get(int id)
        {
            User getUser = null;
            foreach (var e in users)
            {
                if (e.id == id)
                {
                    getUser = e;              
                }
            }

            return getUser;
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return users;
            throw new NotImplementedException();
        }

        public bool Save(User entity)
        {
            bool count = true;
            foreach (var e in users)
            {
                if (e.email == entity.email)
                {
                    count = false;
                }
            }

            if (count)
            {
                users.Add(entity);
            }

            return count;
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool count = false;
            foreach (var e in users)
            {
                if (e.id == id)
                {
                    users.RemoveAt(e.id);
                    count = true;
                }
            }

            return count;
            throw new NotImplementedException();
        }
    }
}