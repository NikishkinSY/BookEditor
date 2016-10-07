using BookEditor_Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Model.Entities
{
    public class Author: IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string SecondName { get; set; }
    }
}
