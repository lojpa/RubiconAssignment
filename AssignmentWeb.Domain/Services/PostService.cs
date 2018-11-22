using AssignmentWeb.Domain.Interfaces;
using AssignmentWeb.Repository.Models;
using AssignmentWeb.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentWeb.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<BlogPostViewModel> GetPostVM(string slug)
        {
            var post = await _postRepository.GetVM(slug);
            return post;
        }

        public async Task<Post> GetPost(string slug)
        {
            var post = await _postRepository.Get(slug);
            return post;
        }

        public async Task<IEnumerable<BlogPostViewModel>> Search(string tag)
        {
            var posts = await _postRepository.Search(tag);
            return posts;
        }

        public Task<BlogPostViewModel> Create(Post post)
        {
            var createdPost = _postRepository.Create(post);
            return createdPost;
        }


        public Task<Post> Update(Post post)
        {
            var updatedPost = _postRepository.Update(post);
            return updatedPost;
        }

        public async Task Delete(string slug)
        {
            await _postRepository.Remove(slug);
        }
    }
}
