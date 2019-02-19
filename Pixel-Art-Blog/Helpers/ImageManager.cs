using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Helpers.Interfaces;
using Pixel_Art_Blog.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Helpers
{
    public class ImageManager : IImageManager
    {
        private int MAX_SUPPORTED = 10 * 1024 * 1024;
        private string[] SUPPORTED_EXTENSIONS = new []
        {
            ".png",
            ".jpeg",
            ".jpg"
        };

        public string SaveImage(HttpPostedFileBase img, string path)
        {
            if(img == null)
                return null;
            if(img.ContentLength == 0)
                return null;
            if (img.ContentLength > MAX_SUPPORTED)
                return null;
            if (!SUPPORTED_EXTENSIONS.Any(i => i == Path.GetExtension(img.FileName)))
                return null;

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
            img.SaveAs(path + fileName);

            return fileName;
        }
    }
}