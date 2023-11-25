using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ActionAtaDistance1.Model
{
    [Table("MysteryBook")]
    public partial class MysteryBook : ObservableObject
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
                    OnPropertyChanged();
                }
            }
        }

        public int MysteryGenreID { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }

        [JsonIgnore]
        public virtual MysteryGenre MysteryGenre { get; set; }
    }
}
