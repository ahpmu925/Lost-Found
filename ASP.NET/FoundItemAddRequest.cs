using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LostandFound.Models.Requests
{
    public class FoundItemAddRequest
    {
        [Required]
        [MinLength(2)]
        public string Item { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$")]
        public string PhoneNo { get; set; }
        [Required]
        [MinLength(2)]
        public string Location { get; set; }
        [MinLength(5)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
