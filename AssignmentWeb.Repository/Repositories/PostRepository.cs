using AssignmentWeb.Repository.Context;
using AssignmentWeb.Repository.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentWeb.Repository.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly RubiconContext _context;

        public PostRepository(RubiconContext context)
        {
            _context = context;
        }

        public async Task<BlogPostViewModel> GetVM(string slug)
        {
            var post = await Get(slug);

            var postMap = Mapper.Map<BlogPostViewModel>(post);

            return postMap;
        }

        public async Task<Post> Get(string slug)
        {
            var post = await _context.Posts.Include(x => x.PostTags).ThenInclude(y => y.Tag).FirstOrDefaultAsync(x => x.Slug == slug);
            post.TagList = post.PostTags.Select(x => x.TagId).ToList();

            return post;
        }


        public async Task<IEnumerable<BlogPostViewModel>> Search(string tag)
        {

            var posts = await _context.Posts.Include(x => x.PostTags).ThenInclude(x => x.Tag).ToListAsync();

            if (!string.IsNullOrWhiteSpace(tag))
            {
                posts = posts.Where(x => x.PostTags.Any(y => y.TagId == tag)).ToList();
            }

            foreach (var post in posts)
            {
                post.TagList = post.PostTags?.Select(x => x.Tag.TagId).ToList();
            }

            var listOfPosts = Mapper.Map<IEnumerable<BlogPostViewModel>>(posts);


            return listOfPosts;
        }

        public async Task<Post> Create(Post post)
        {
            post.Slug = Helper.Helper.GenerateSlug(post.Title);
            post.CreatedAt = DateTime.UtcNow;
            _context.Posts.Add(post);

            if (post.TagList == null || post.TagList.Count == 0)
                goto noTags;

            post.PostTags = new List<PostTag>();

            var dbTags = _context.Tags.Select(x => x.TagId);

            foreach (var tag in post.TagList)
            {
                if (!dbTags.Contains(tag))
                {
                    _context.Tags.Add(new Tag() { TagId = tag });
                }

                PostTag postTag = new PostTag()
                {
                    TagId = tag,
                    PostId = post.PostId
                };

                post.PostTags.Add(postTag);

            }
            noTags: await _context.SaveChangesAsync();
            post.PostTags = null;
            return post;
        }

        public async Task<Post> Update(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
            return post;

        }

        public async Task Remove(string slug)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Slug == slug);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
