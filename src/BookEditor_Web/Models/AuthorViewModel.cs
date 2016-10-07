using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Web.Models
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
