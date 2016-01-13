using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Attachment")]
    public class Attachment
    {
        [Key]
        public Guid GUID { get; set; }
        //public long ID { get; set; }


        public string AttachmentPath {get;set;}
        [Column(TypeName = "varchar(MAX)")]
        public string ImageBase64String { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        //user, to do !?
        public string UploadedBy { get; set; }

        public Claim Claim { get; set; }
        public AttachmentType AttachmentType { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
    }
}
