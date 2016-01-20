using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ClaimPicture")]
    public class ClaimPicture
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        //public long ID { get; set; }


        [Display(Name="Snapshot"), Column(TypeName = "varchar(MAX)")]
        public string ImageSmall { get; set; }
        [Display(Name = "Image"), Column(TypeName = "varchar(MAX)")]
        public string ImageFull { get; set; }
        //[Column(TypeName = "image")]
        //public byte[] Image { get; set; }
        [Display(Name = "Image date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ImageDate { get; set; }
        //usercode of the client, or Client/ClaimExpert/AppUser
        [Display(Name = "Uploaded by"), StringLength(50)]
        public string UploadedBy { get; set; }


        public virtual ClaimContactPerson Claimant { get; set; }
        public virtual Claim Claim { get; set; }
        public virtual ClaimPictureType PictureType { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
