using Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Models.DTOs.Images;
using System.Text.RegularExpressions;

namespace BLL.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly string wwwroot;
        private readonly IHostEnvironment env;
        private const string imgFolder = "images";
        private const string articleImagesFolder = "article-images";
        private const string userImagesFolder = "user-images";

        public ImageHelper(IHostEnvironment env)
        {
            this.env = env;
            //wwwroot = env.ContentRootPath;
            wwwroot = Path.Combine(env.ContentRootPath, "wwwroot");
        }

        /// <summary>
        /// bilinmeyen ve özel karakterleri silecek metot
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string ReplaceInvalidChars(string fileName)
        {
            string pattern = "[İıĞğÜüŞşÖöÇçé!'^+%/()=?_\\*æß@€<>#$½{}\\[\\]\\\\|~¨,;`.:\\s]";
            return Regex.Replace(fileName, pattern, "");
        }



        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);
        }


        public async Task<ImagesUploadedDTo> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder;

            if (!Directory.Exists(Path.Combine(wwwroot, imgFolder, folderName)))
                Directory.CreateDirectory(Path.Combine(wwwroot, imgFolder, folderName));

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name);

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";

            var path = Path.Combine(wwwroot, imgFolder, folderName, newFileName);

            using var stream = new FileStream(path, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();


            string message = imageType == ImageType.User
                ? $"{newFileName} isimli kullanıcı resmi başarı ile eklenmiştir."
                : $"{newFileName} isimli makale resmi başarı ile eklenmiştir";

            return new ImagesUploadedDTo()
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }
    }
}
