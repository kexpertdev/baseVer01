using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("ClaimPicture")]
    public class ClaimPicture
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        //public long ID { get; set; }


        //[ScaffoldColumn(false)]
        [Required, StringLength(255)]
        public string ImageName { get; set; }
        [Display(Name="Snapshot"), Column(TypeName = "varchar(MAX)")]
        public string ImageSmall { get; set; }
        [Display(Name = "Image"), Column(TypeName = "varchar(MAX)")]
        public string ImageFull { get; set; }
        //[Column(TypeName = "image")]
        //public byte[] Image { get; set; }
        [Display(Name = "Image date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset ImageDate { get; set; }
        //usercode of the client, or Client/ClaimExpert/AppUser
        [Display(Name = "Uploaded by"), StringLength(50)]
        public string UploadedBy { get; set; }


        [ForeignKey("Claimant"), Required]
        public int Claimant_ID { get; set; }
        [ForeignKey("PictureType"), Required]
        public ClaimImageSetTypes PictureType_ID { get; set; }


        public virtual ClaimContact Claimant { get; set; }
        public virtual ClaimPictureType PictureType { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
