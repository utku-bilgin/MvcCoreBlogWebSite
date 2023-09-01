using Core.Enums;
using Microsoft.AspNetCore.Http;
using Models.DTOs.Images;

namespace BLL.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImagesUploadedDTo> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
