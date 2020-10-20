using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.FriendVms
{
    public class FriendRequestVm
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public Media SenderPhoto { get; set; }
        public Media ReceiverPhoto { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
    }
}
