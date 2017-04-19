using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Empeek.Domain.Entities
{
    [DataContract]
    [Table("tblUser")]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [DataMember]
        [NotMapped]
        public int PetsCount { get; set; }

        [DataMember]
        public virtual ICollection<Pet> Pets { get; set; }

        public User()
        {
            Pets = new List<Pet>();
            PetsCount = Pets.Count;
        }
    }
}
