using AutoMapper;
using BlogAppV1.DataAccess;
using BlogAppV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.Code.Mappings
{
    public class UserInfoTOUserProfile : Profile
    {
        public UserInfoTOUserProfile()
        {
            CreateMap<UserInfoVm, Users>();
        }
    }
}
