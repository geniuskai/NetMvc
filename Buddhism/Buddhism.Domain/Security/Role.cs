using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.Domain.Security
{
    [Table("Roles", Schema = "Security")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(20)]
        public string RoleName { get; set; }
    }
}
