using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empeek.Domain.Abstract
{
    public interface IOwnerRepository
    {
        IEnumerable<User> Users { get; }
        IEnumerable<Pet> Pets { get; }
        void AddUser(User user);
        void DeleteUser(User user);

        IEnumerable<Pet> GetPetsByUserId(int userId);
        void AddPet(Pet pet);
        void DeletePet(Pet pet);
    }
}
