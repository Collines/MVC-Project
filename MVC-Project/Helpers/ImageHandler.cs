using shopping.Models;

namespace MVC_Project.Helpers
{
    public class ImageHandler
    {
        public static Image EncodeImage(IFormFile file)
        {
            Image image = new()
            {
                Title = file.FileName
            };
            MemoryStream ms = new();
            file.CopyTo(ms);
            image.ImageData = ms.ToArray();
            ms.Close();
            ms.Dispose();
            return image;
        }

        public static string GetImageURI(Image img)
        {
            string imageDataURL = "";
            if (img != null)
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                string imgType = img.Title.Split(".")[^1];
                imageDataURL = string.Format($"data:image/{imgType};base64,{imageBase64Data}") ?? "";
            }
            return imageDataURL;
        }
    }
}
