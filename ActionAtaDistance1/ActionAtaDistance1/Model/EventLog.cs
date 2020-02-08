using System;
using System.ComponentModel.DataAnnotations;

namespace ActionAtaDistance1.Model
{
    public partial class EventLog
    {
        public long ID { get; set; }

        [Required]
        [StringLength(128)]
        public string App { get; set; }

        [Required]
        [StringLength(30)]
        public string AppVersion { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public string MachineName { get; set; }

        [StringLength(128)]
        public string IP_Address { get; set; }

        public DateTime ActionDateTime { get; set; }

        [Required]
        [StringLength(128)]
        public string ActionTaken { get; set; }

        [StringLength(128)]
        public string TableName { get; set; }

        public long? RecordID { get; set; }

        public string Message { get; set; }

        public long? RecordsReturned { get; set; }

        public bool? Error { get; set; }

        [StringLength(25)]
        public string Created_By { get; set; }

        public DateTime? Created_On { get; set; }

        [StringLength(25)]
        public string Updated_By { get; set; }

        public DateTime? Updated_On { get; set; }
    }
}
