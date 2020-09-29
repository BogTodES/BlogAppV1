using BlogAppV1.BusinessLogic.BaseServ;
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
        public SectionsService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public Sections GetSectionWithId(long Id)
        {
            return
                unit.Sections.Get().FirstOrDefault(sec => sec.Id == Id);
        }

        public IEnumerable<Posts> Top5Posts(long sectId)
        {
            return
                unit.Posts.Get()
                    .Where(p => p.SectionId == sectId)
                    .Take(5);
        }

    }

}
