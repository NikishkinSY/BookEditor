using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Web.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public ICollection<AuthorViewModel> Authors { get; set; }
        public int PageCount { get; set; }
        public string PublishingHouseName { get; set; }
        public int PublishYear { get; set; }
        [RegularExpression(@"^(?:ISBN(?:-1[03])?:?\ )?(?=[0-9X]{10}$|(?=(?:[0-9]+[-\ ]){3})[-\ 0 - 9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)(?:97[89][-\ ]?)?[0 - 9]{1,5}[-\ ]?[0 - 9]+[-\ ]?[0 - 9]+[-\ ]?[0 - 9X]$")]
        public string ISBN { get; set; }
        public byte[] Image { get; set; }
    }
}
