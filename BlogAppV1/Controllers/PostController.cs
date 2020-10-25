using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.ViewModels.PostVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService postService;
        private readonly CommentService commentService;
        /*private readonly UserBlogService userBlogService;
        private readonly UserInfoService userInfoService;*/
        private readonly PostReactService postReactService;

        public PostController(PostService postService, 
            CommentService commentService, UserBlogService userBlogService, 
            UserInfoService userInfoService)
        {
            this.postService = postService;
            this.commentService = commentService;
            /*this.userBlogService = userBlogService;
            this.userInfoService = userInfoService;*/
        }

        [HttpPost]
        public IActionResult AddPost(string newTitle, string newBody, long sectionId)
        {
            if (newBody is null)
                newBody = string.Empty;
            postService.AddPost(newTitle, newBody, sectionId);

            return Json(new { 
                flag = true 
            });
        }

        public IActionResult RemovePost(long postId)
        {
            postService.DeletePost(postId);

            return Json(new {
                flag = true
            });
        }

        [HttpGet]
        public IActionResult PostWith(long postId)
        {
            var post = postService.PostWithId(postId);

            if (post is null)
                return NotFound("The Post you are looking for has been deleted or is inaccessible");

            var tempComms = postService.CommentsOfPost(postId).ToList();
            var poster = postService.GetPosterInfo(postId);

            return View("PostDetailsPage", new PostDetailsVm()
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Date = post.Date,
                SectId = post.SectionId,
                OwnerId = poster.PosterId,
                OwnerUsername = poster.PosterUsername,
                PhotoId = post.PhotoId,
                Comments = tempComms
            });
        }

        [HttpPost]
        public IActionResult AddComment(string body, long postId)
        {
            if (body is null)
                body = string.Empty;
            commentService.AddComment(body, postId);

            return Json(new
            {
                flag = true
            });
        }

        /*public IActionResult RemoveComment(long commId, long postId)
        {
            commentService.RemoveComment(commId);
            return PostWith(postId);
        }*/

        public IActionResult RemoveComment(long commId)
        {
            commentService.RemoveComment(commId);
            return Json(new {
                flag = true
            });
        }
    }
}
