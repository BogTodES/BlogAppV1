using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.ViewModels.PostVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService postService;
        private readonly CommentService commentService;
        private readonly UserBlogService userBlogService;
        private readonly UserInfoService userInfoService;

        public PostController(PostService postService, 
            CommentService commentService, UserBlogService userBlogService, UserInfoService userInfoService)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.userBlogService = userBlogService;
            this.userInfoService = userInfoService;
        }

        public IActionResult PostWith(long postId)
        {
            var post = postService.PostWithId(postId);
            var comms = postService.CommentsOfPost(postId);
            var poster = postService.GetPosterInfo(postId);

            return View("PostDetails", new PostDetailsVm()
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Date = post.Date,
                SectId = post.SectionId,
                OwnerId = poster.PosterId,
                OwnerUsername = poster.PosterUsername,
                Comments = comms
            });
        }
    }
}
