using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class ReactionService : BaseService
    {
        // serviciu pt admin pt a adauga si alte reactii in viitor
        public ReactionService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public int RegisterNewReaction()
        {
            // incarc o raectie noua (nume + img)
            return 1;
        }

        public IEnumerable<ReactTypes> AllReacts()
        {
            return
                unit.ReactTypes.Get().ToList();
        }

        public ReactTypes GetreactWithId(int reactId)
        {
            return
                unit.ReactTypes.Get().FirstOrDefault(r => r.Id == reactId);
        }
    }
}
