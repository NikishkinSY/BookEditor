using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookEditor_Model.Entities
{
    public class Book: IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Header { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        [Required]
        public int PageCount { get; set; }
        
        [MaxLength(30)]
        public string PublishingHouseName { get; set; }
        
        public int PublishYear { get; set; }

        [MaxLength(20)]
        public string ISBN { get; set; }

        public byte[] Image { get; set; }
    }
}
