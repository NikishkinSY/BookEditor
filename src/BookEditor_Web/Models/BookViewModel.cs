using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Web.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Header { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }

        [Required]
        [Range(0, 10000)]
        public int PageCount { get; set; }

        [StringLength(30)]
        public string PublishingHouseName { get; set; }

        [Range(1800, 2100)]
        public int PublishYear { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^(?:ISBN(?:-1[03])?:?\ )?(?=[0-9X]{10}$|(?=(?:[0-9]+[-\ ]){3})[-\ 0 - 9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)(?:97[89][-\ ]?)?[0 - 9]{1,5}[-\ ]?[0 - 9]+[-\ ]?[0 - 9]+[-\ ]?[0 - 9X]$")]
        public string ISBN { get; set; }

        public byte[] Image { get; set; }
    }
}
