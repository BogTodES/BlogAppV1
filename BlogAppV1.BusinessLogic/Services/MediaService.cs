using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class MediaService : BaseService
    {
        public MediaService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        private Media AddPhoto(MemoryStream imgStream)
        { 
            Media img = new Media();
            img.Content = imgStream.ToArray();

            imgStream.Close();
            imgStream.Dispose();

            unit.Media.Insert(img);
            return img;
        }

        public int AddUserPhoto(MemoryStream imgStream)
        {
            return ExecuteInTransaction(unit =>
            {
                var userId = int.Parse(CurrentUser.Id);

                var usr = unit.Users.Get().FirstOrDefault(u => u.Id == userId);

                if (usr.Photo != null)
                    unit.Media.Delete(usr.Photo);

                usr.Photo = AddPhoto(imgStream);

                return unit.Complete();
            });
        }

        public int AddBlogPhoto(MemoryStream imgStream, long blogId)
        {
            return ExecuteInTransaction(unit =>
            {
                var b = unit.Users.Get().FirstOrDefault(bl => bl.Id == blogId);
                b.Photo = AddPhoto(imgStream);

                if (b.Photo != null)
                    unit.Media.Delete(b.Photo);

                return unit.Complete();
            });
        }

        public int AddSectPhoto(MemoryStream imgStream, long sectId)
        {
            return ExecuteInTransaction(unit =>
            {
                var s = unit.Users.Get().FirstOrDefault(sc => sc.Id == sectId);
                s.Photo = AddPhoto(imgStream);

                if (s.Photo != null)
                    unit.Media.Delete(s.Photo);

                return unit.Complete();
            });
        }

        public Media GetImageForUser(int userId)
        {
            var usr = unit.Users.Get().FirstOrDefault(usr => usr.Id == userId);
            return usr.Photo;
        }

        public Media GetImageForBlog(long blogId)
        {
            var blg = unit.Users.Get().FirstOrDefault(b => b.Id == blogId);
            return blg.Photo;
        }

        public Media GetImageForSect(long sectId)
        {
            var sc = unit.Users.Get().FirstOrDefault(s => s.Id == sectId);
            return sc.Photo;
        }
    }
}
