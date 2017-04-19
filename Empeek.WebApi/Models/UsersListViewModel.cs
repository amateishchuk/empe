using Empeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empeek.WebApi.Models
{
    public class UsersListViewModel
    {
        public int UsersCount { get; set; }
        public IEnumerable<object> UsersArray { get; set; }
        public int ItemsPerPage { get; set; }
        public bool SortReverse { get; set; }
    }
}