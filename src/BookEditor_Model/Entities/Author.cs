using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookEditor_Model.Entities
{
    public class Author: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string SecondName { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
