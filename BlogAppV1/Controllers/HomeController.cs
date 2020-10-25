using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogAppV1.Models;
using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;

namespace BlogAppV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SearchService searchService;
        private readonly FriendsService friendsService;
        private readonly BlockService blockService;
        private readonly ReactionService reactionService;

        public HomeController(ILogger<HomeController> logger, 
                              SearchService searchService, 
                              FriendsService friendsService, 
                              BlockService blockService,
                              ReactionService reactionService)
        {
            _logger = logger;
            this.searchService = searchService;
            this.friendsService = friendsService;
            this.blockService = blockService;
            this.reactionService = reactionService;
        }

        public IActionResult Index()
        {
            return View();   
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}
