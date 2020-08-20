using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GradutionProject.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        [MinLength(4)]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.(com)$", ErrorMessage = "Invalid Email format")]
        //[EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
