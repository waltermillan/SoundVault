using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVault.Model.Entities
{
    [Table("Albums")]
    public class Album : BaseEntity
    {
        [Column("title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Album's Title is required")]
        public string Title { get; set; }
        [Column("gender_id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Album's Gender is required")]
        public int? GenderId { get; set; }

        public Gender? Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Album's Gender is required")]
        [Column("song_count")]
        [Range(1, int.MaxValue, ErrorMessage = "Song Count needs to be grater than 0")]
        public int SongCount { get; set; }
        [Column("total_duration")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Album's Total Duration is required")]
        public string TotalDuration { get; set; }

        [Column("cover")]
        public string? Cover { get; set; }
    }
}
