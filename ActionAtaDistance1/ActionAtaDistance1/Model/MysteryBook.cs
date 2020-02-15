using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActionAtaDistance1.Model
{
    [Table("MysteryBook")]
    public partial class MysteryBook
    {
        public int ID { get; set; }

        public int AuthorID { get; set; }

        [Required]
        [StringLength(200)]
        public string BookTitle { get; set; }

        public DateTime? PublishDate { get; set; }

        public int MysteryGenreID { get; set; }

        public virtual Author Author { get; set; }

        public virtual MysteryGenre MysteryGenre { get; set; }
    }
}
