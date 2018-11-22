using AssignmentWeb.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentWeb.Domain.Interfaces
{
    public interface IPostService
    {
        Task<BlogPostViewModel> GetPostVM(string slug);
        Task<Post> GetPost(string slug);
        Task<IEnumerable<BlogPostViewModel>> Search(string tag);
        Task<BlogPostViewModel> Create(Post post);
        Task<Post> Update(Post post);
        Task Delete(string slug);

    }
}
