using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Web.Models
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        { }

        public AuthorViewModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string SecondName { get; set; }
    }
}
