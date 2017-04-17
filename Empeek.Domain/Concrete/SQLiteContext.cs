using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empeek.Domain.Concrete
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
