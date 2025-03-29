using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVault.Model.Entities
{
    [Table("Genders")]
    public class Gender : BaseEntity
    {
        [Column("name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Genders's Name is required")]
        public string? Name { get; set; }
    }
}
