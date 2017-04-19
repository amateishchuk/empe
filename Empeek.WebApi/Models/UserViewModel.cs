using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empeek.WebApi.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetsCount { get; set; }
        public IEnumerable<PetViewModel> Pets { get; set; }
        public bool SortReverse { get; set; }
        public int ItemsPerPage { get; set; }
    }
}