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
    [Table("tblPet")]
    public class Pet
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [DataMember]
        public int UserId { get; set; }
        [IgnoreDataMember]
        public virtual User User { get; set; }
    }
}
