using BookEditor_Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Model.Entities
{
    public class Book: IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Header { get; set; }

        public ICollection<Author> Authors { get; set; }

        [Required]
        [Range(0,10000)]
        public int PageCount { get; set; }
        
        [MaxLength(30)]
        public string PublishingHouseName { get; set; }

        [Range(1800, 2100)]
        public int PublishYear { get; set; }

        [RegularExpression(@"^(?:ISBN(?:-1[03])?:?\ )?(?=[0-9X]{10}$|(?=(?:[0-9]+[-\ ]){3})[-\ 0 - 9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)(?:97[89][-\ ]?)?[0 - 9]{1,5}[-\ ]?[0 - 9]+[-\ ]?[0 - 9]+[-\ ]?[0 - 9X]$")]
        public string ISBN { get; set; }

        public byte[] Image { get; set; }
    }
}
