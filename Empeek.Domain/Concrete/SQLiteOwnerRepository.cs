using Empeek.Domain.Abstract;
using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empeek.Domain.Concrete
{
    public class SQLiteOwnerRepository : IOwnerRepository, IDisposable
    {
        private SQLiteContext db = new SQLiteContext();

        public IEnumerable<User> Users
        {
            get
            {
                return db.Users.ToList();
            }
        }

        public IEnumerable<Pet> Pets
        {
            get
            {
                return db.Pets.ToList();
            }
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public void AddPet(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();
        }

        public void DeletePet(Pet pet)
        {
            db.Pets.Remove(pet);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
