using AssignmentWeb.Domain.Interfaces;
using AssignmentWeb.Repository.Helper;
using AssignmentWeb.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentWeb.API.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<BlogPostViewModel>> GetPost(string slug)
        {
            var post = await _postService.GetPostVM(slug);
            if (post == null)
                return NotFound();
            return Ok(new { blogPost = post });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostViewModel>>> GetPosts(string tag)
        {
            var posts = await _postService.Search(tag);
            return Ok(new { blogPosts = posts, postsCount = posts.Count() });
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Create(Post post)
        {
            var createdPost = await _postService.Create(post);
            return Ok(createdPost);
        }

        [HttpPut("{slug}")]
        public async Task<ActionResult<Post>> Update(string slug, string title, string description, string body)
        {
            var existingPost = await _postService.GetPost(slug);

            if (existingPost == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                existingPost.Title = title;
                existingPost.Slug = Helper.GenerateSlug(title);
            }
            existingPost.Body = body ?? existingPost.Body;
            existingPost.Description = description ?? existingPost.Description;

            var updatedPost = await _postService.Update(existingPost);
            return Ok(updatedPost);
        }

        [HttpDelete("{slug}")]
        public async Task<ActionResult> Delete(string slug)
        {
            await _postService.Delete(slug);
            return NoContent();
        }






    }
}