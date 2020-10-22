using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class BlocksController : Controller
    {
        private readonly BlockService blockService;
        private readonly FriendsService friendsService;

        public BlocksController(BlockService blockService, FriendsService friendsService)
        {
            this.blockService = blockService;
            this.friendsService = friendsService;
        }


        public IActionResult BlockUser(int blockedId)
        {
            var rows = blockService.BlockPersonal(blockedId);
            rows += friendsService.Unfriend(blockedId);

            return RedirectToActionPermanent("Index", "Home");
        }

        public IActionResult UnblockUser(int blockedId)
        {
            var rows = blockService.UnblockPersonal(blockedId);
            return Json(new
            {
                flag = rows >= 0
            });
        }

        [Authorize("Moderator")]
        public IActionResult SoftBan(int blockedId)
        {
            var rows = blockService.SoftBlock(blockedId);
            return RedirectToActionPermanent("ProfileOf", "UserInfo", new { blockedId });
        }
        
        [Authorize("Admin")]
        public IActionResult HardBan(int blockedId)
        {
            var rows = blockService.HardBlock(blockedId);
            return RedirectToActionPermanent("ProfileOf", "UserInfo", new { blockedId });
        }

        [Authorize("Moderator")]
        public IActionResult LiftBan(int blockedId)
        {
            var rows = blockService.RemoveBan(blockedId);
            return RedirectToActionPermanent("ProfileOf", "UserInfo", new { blockedId });
        }
    }
}
