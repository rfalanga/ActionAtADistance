using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActionAtaDistance1.Model
{
    [Table("MysteryBook")]
    public partial class MysteryBook : ViewModelBase
    {
        public int ID { get; set; }

        public int AuthorID { get; set; }

        [Required]
        [StringLength(200)]
        public string BookTitle { get; set; }

        private DateTime? publishDate;
        public DateTime? PublishDate 
        { 
            get { return publishDate; }
            set
            {
                if (publishDate != value)
                {
                    publishDate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int MysteryGenreID { get; set; }

        public virtual Author Author { get; set; }

        public virtual MysteryGenre MysteryGenre { get; set; }
    }
}
