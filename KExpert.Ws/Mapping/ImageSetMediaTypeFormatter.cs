//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Net.Http;
//using System.Net.Http.Formatting;
//using System.Net.Http.Headers;
//using KE.Entities.WsMobile;
//using System.Threading.Tasks;
//using System.IO;
//using System.Text.RegularExpressions;

//namespace KExpert.Ws.Mapping
//{
//    public class ImageSetMediaTypeFormatter : MediaTypeFormatter
//    {
//        public ImageSetMediaTypeFormatter()
//        {
//            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
//        }

//        public override bool CanReadType(Type type)
//        {
//            return type == typeof(ImageSet);
//        }

//        public override bool CanWriteType(Type type)
//        {
//            return false;
//        }

//        public async override Task<object> ReadFromStreamAsync(
//            Type type,
//            Stream readStream,
//            HttpContent content,
//            IFormatterLogger formatterLogger)
//        {
//            var provider = await content.ReadAsMultipartAsync();

//            var modelContent = provider.Contents
//                .FirstOrDefault(c => c.Headers.ContentDisposition.Name.NormalizeName() == "imageset");

//            var imageSet = await modelContent.ReadAsAsync<ImageSet>();

//            var fileContents = provider.Contents
//                .Where(c => c.Headers.ContentDisposition.Name.NormalizeName().Matches(@"image\d+"))
//                .ToList();

//            imageSet.Images = new List<Image>();
//            foreach (var fileContent in fileContents)
//            {
//                imageSet.Images.Add(new Image
//                {
//                    ImageData = await fileContent.ReadAsByteArrayAsync(),
//                    MimeType = fileContent.Headers.ContentType.MediaType,
//                    FileName = fileContent.Headers.ContentDisposition.FileName.NormalizeName()
//                });
//            }

//            return imageSet;

//        }
//    }

//    public static class StringExtenstions
//    {
//        public static string NormalizeName(this string text)
//        {
//            return text.Replace("\"", "");
//        }

//        public static bool Matches(this string text, string pattern)
//        {
//            return Regex.IsMatch(text, pattern);
//        }
//    }
//}