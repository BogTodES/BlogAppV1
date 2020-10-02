﻿using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic
{
    public class SectionsService : BaseService
    {
        public SectionsService(UnitOfWork unit, 
            CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public int AddSection(string name, long blogId)
        {
            return ExecuteInTransaction(unit =>
            {
                var newSect = new Sections()
                {
                    Name = name,
                    IsSystemCreated = false
                };
                unit.Sections.Insert(newSect);

                var newBlogSect = new BlogsSections()
                {
                    BlogId = blogId,
                    Section = newSect
                };
                unit.BlogsSections.Insert(newBlogSect);

                return unit.Complete();
            });
        }

        public Sections GetSectionWithId(long Id)
        {
            return
                unit.Sections.Get().FirstOrDefault(sec => sec.Id == Id);
        }

        public IEnumerable<Posts> AllPosts(long sectId)
        {
            return
                unit.Posts.Get()
                    .Where(p => p.SectionId == sectId);
        }

        public IEnumerable<Posts> Top5Posts(long sectId)
        {
            return
                unit.Posts.Get()
                    .Where(p => p.SectionId == sectId)
                    .Take(5);
        }

        public IEnumerable<Blogs> BlogsUsingSectId(long sectId)
        {
            // aflu ce blog-uri folosesc sectiunea cu Id specificat

            var q = unit.BlogsSections.Get().Where(bls => bls.SectionId == sectId);

            var blogs = unit.Blogs.Get().ToList();
            var resultList = new List<Blogs>();
            foreach(var bl in q)
            {
                var blog = blogs.FirstOrDefault(b => b.Id == bl.BlogId);

                resultList.Add(blog);
            }

            return resultList;
        }

    }

}
