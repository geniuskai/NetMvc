using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.Domain.Security
{
    [Table("Users", Schema = "Security")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserAccount { get; set; }
        [Required]
        [MinLength(6)]
        public string UserPassword { get; set; }
        [Required]
        [MaxLength(10)]
        public string UserName { get; set; }

        public override string ToString()
        {
            return UserName;
        }
    }
}
