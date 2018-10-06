using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Helpers
{
    public static class ImageManager
    {
        public static string GetImagePath(HttpPostedFileBase img, IUnitOfWork unitOfWork, string path)
        {
            if(img == null)
            {
                return null;
            }

            string imgName = img.FileName;
            var result = unitOfWork.Posts.Find(p => p.Img == imgName);

            int i = 0;
            string fName = Path.GetFileNameWithoutExtension(imgName);
            string fExt = Path.GetExtension(imgName);

            while (result.Count() != 0)
            {
                i++;
                result = unitOfWork.Posts.Find(
                    p => p.Img == (fName + i.ToString() + fExt));
            }

            imgName = (i > 0)
                ? String.Concat(fName, i.ToString(), fExt)
                : imgName;
            
            img.SaveAs(path + imgName);

            return imgName;
        }
    }
}