﻿using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.PostVms
{
    public class PostDetailsVm
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public long SectId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public long? PhotoId { get; set; }
        public IEnumerable<CommentInfoDto> Comments { get; set; }
    }
}
