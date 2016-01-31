using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.WsMobile
{

    public class ImageSetCollection
    {
        public List<ImageSet> ImageSets { get; set; }
    }

    public class ImageSet
    {
        public string Name { get; set; }

        public ClaimImageSetTypes ImageSetType { get; set; }

        public List<Image> Images { get; set; }
    }


    public class Image
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public string Base64Image { get; set; }

        //public byte[] ImageData { get; set; }
    }
}
