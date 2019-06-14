using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sandbox.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public string UserName { get; set; }
        public string SystemRole { get; set; }
    }
}
