using shopping.Models;
using System.Diagnostics.Metrics;

namespace MVC_Project.Helpers
{
    public class ImageHandler
    {
        public static Image EncodeImage(IFormFile file)
        {
            Image image = new();
            image.Title = file.FileName;
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            image.ImageData = ms.ToArray();
            ms.Close();
            ms.Dispose();
            return image;
        }

        public static string GetImageURI(Image img)
        {
            string imageDataURL="";
            if (img != null)
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                string imgType = img.Title.Split(".")[img.Title.Split(".").Length - 1];
                imageDataURL = string.Format($"data:image/{imgType};base64,{imageBase64Data}") ?? "";
            }
            return imageDataURL;
        }
    }
}
