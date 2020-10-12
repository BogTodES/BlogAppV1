using BlogAppV1.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    public class FloaterReactionsViewComponent : ViewComponent
    {
        private readonly ReactionService reactionService;

        public FloaterReactionsViewComponent(ReactionService reactionService)
        {
            this.reactionService = reactionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var reacts = reactionService.AllReacts();
            return View("FloaterReactions", reacts);
        }
    }
}
