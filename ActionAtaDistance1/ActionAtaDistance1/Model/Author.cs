namespace ActionAtaDistance1.Model
{
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author : ViewModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            MysteryBooks = new HashSet<MysteryBook>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleInitial { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        private DateTime? dateOfBirth;
        public DateTime? DateOfBirth 
        { 
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth != value)
                {
                    dateOfBirth = value;
                    RaisePropertyChanged();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MysteryBook> MysteryBooks { get; set; }
    }
}
