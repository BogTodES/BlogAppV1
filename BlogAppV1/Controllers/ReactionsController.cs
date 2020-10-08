using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class ReactionsController : Controller
    {
        private readonly PostReactService postReactService;
        private readonly CommReactService commReactService;
        private readonly ReactionService reactionService;


        public ReactionsController(PostReactService postReactService, 
            CommReactService commReactService, ReactionService reactionService)
        {
            this.postReactService = postReactService;
            this.commReactService = commReactService;
            this.reactionService = reactionService;
        }

        public IActionResult ReactToPost(int reactId, long postId)
        {
            postReactService.ReactToPost(postId, reactId);

            return Json(new
            {
                flag = true
            });
        }

        public IActionResult ReactToComm(int reactId, long commId)
        {
            commReactService.ReactToComm(commId, reactId);

            return Json(new
            {
                flag = true
            });
        }

        public IActionResult RemoveReactFromPost(long postId)
        {
            postReactService.RemoveReactionFromPost(postId);

            return Json(new
            {
                flag = true
            });
        }

        public IActionResult RemoveReactFromComm(long commId)
        {
            commReactService.RemoveReactionFromComm(commId);

            return Json(new
            {
                flag = true
            });
        }

        [HttpGet]
        public IActionResult GetAllAvailableReactions()
        {
            var allReacts = reactionService.AllReacts();
            return ViewComponent("FloaterReactions", allReacts);
        }
    }
}
