using BlogAppV1.BusinessLogic;
using BlogAppV1.ViewModels.BlogStuff;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    //[ViewComponent(Name = "smallsection")]
    public class MainScreenSectionViewComponent : ViewComponent
    {
        // pentru o sectiune, afisez titlu si primele 5 postari

        private readonly SectionsService sectionsService;

        public MainScreenSectionViewComponent(SectionsService sectionsService)
        {
            this.sectionsService = sectionsService;
        }

        public IViewComponentResult Invoke(long Id, long blogId, bool IsEditable)
        {
            var posts = sectionsService.Top5Posts(Id);
            var sect = sectionsService.GetSectionWithId(Id);

            if(IsEditable)
            {
                return View("Editable", new SmallSectionVm()
                {
                    Id = sect.Id,
                    BlogId = blogId,
                    Title = sect.Name,
                    Posts = posts
                });
            }

            return View("Default", new SmallSectionVm()
            {
                Id = sect.Id,
                BlogId = blogId,
                Title = sect.Name,
                Posts = posts
            }) ;
        }
    }
}
