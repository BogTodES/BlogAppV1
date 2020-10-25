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

        public Media GetPhoto(long photoId)
        {
            return
                unit.Media.Get().FirstOrDefault(ph => ph.Id == photoId);
        }

        public int DeletePhoto(long photoId)
        {
            return ExecuteInTransaction(unit =>
            {
                var img = unit.Media.Get().FirstOrDefault(ph => ph.Id == photoId);
                if (img != null)
                    unit.Media.Delete(img);

                return unit.Complete();
            });
        }


        public int AddUserPhoto(MemoryStream imgStream)
        {
            return ExecuteInTransaction(unit =>
            {
                var userId = int.Parse(CurrentUser.Id);
                var usr = unit.Users.Get().FirstOrDefault(u => u.Id == userId);
                var oldImg = unit.Media.Get().FirstOrDefault(ph => ph.Id == usr.PhotoId);

                if (oldImg != null && oldImg.Id != 7)
                    unit.Media.Delete(oldImg);

                usr.Photo = AddPhoto(imgStream);
                return unit.Complete();
            });
        }

        public int AddBlogPhoto(MemoryStream imgStream, long blogId)
        {
            return ExecuteInTransaction(unit =>
            {
                var b = unit.Blogs.Get().FirstOrDefault(bl => bl.Id == blogId);
                var oldImg = unit.Media.Get().FirstOrDefault(ph => ph.Id == b.PhotoId);

                if (oldImg != null)
                    unit.Media.Delete(oldImg);

                b.Photo = AddPhoto(imgStream);
                return unit.Complete();
            });
        }

        public int AddSectPhoto(MemoryStream imgStream, long sectId)
        {
            return ExecuteInTransaction(unit =>
            {
                var s = unit.Sections.Get().FirstOrDefault(sc => sc.Id == sectId);
                var oldImg = unit.Media.Get().FirstOrDefault(ph => ph.Id == s.PhotoId);

                if (oldImg != null)
                    unit.Media.Delete(oldImg);

                s.Photo = AddPhoto(imgStream);
                return unit.Complete();
            });
        }

        public int AddPostPhoto(MemoryStream imgStream, long postId)
        {
            return ExecuteInTransaction(unit =>
            {
                var p = unit.Posts.Get().FirstOrDefault(sc => sc.Id == postId);
                var oldImg = unit.Media.Get().FirstOrDefault(ph => ph.Id == p.PhotoId);

                if (oldImg != null)
                    unit.Media.Delete(oldImg);

                p.Photo = AddPhoto(imgStream);
                return unit.Complete();
            });
        }

        public Media GetImageForUser(int userId)
        {
            var usr = unit.Users.Get().FirstOrDefault(usr => usr.Id == userId);
            return GetPhoto(usr.PhotoId.Value);
        }

        public Media GetImageForBlog(long blogId)
        {
            var blg = unit.Blogs.Get().FirstOrDefault(b => b.Id == blogId);
            return GetPhoto(blg.PhotoId.Value);
        }

        public Media GetImageForSect(long sectId)
        {
            var sc = unit.Sections.Get().FirstOrDefault(s => s.Id == sectId);
            return GetPhoto(sc.PhotoId.Value);
        }

        public Media GetImageForPost(long postId)
        {
            var po = unit.Posts.Get().FirstOrDefault(p => p.Id == postId);
            return GetPhoto(po.PhotoId.Value);
        }
    }
}
