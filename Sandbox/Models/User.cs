using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sandbox.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
