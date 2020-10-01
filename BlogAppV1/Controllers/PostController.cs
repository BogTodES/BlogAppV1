using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService postService;
        private readonly CommentService commentService;
        private readonly BlogService blogService;

        public PostController(PostService postService, 
            CommentService commentService, BlogService blogService)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.blogService = blogService;
        }

        public IActionResult PostWith(long postId)
        {
            var post = postService.PostWithId(postId);
            var comms = postService.CommentsOfPost(postId);
            var owner = blogService.OwnerOfBlog()

            return View("PostDetails");
        }
    }
}
