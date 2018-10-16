using AssignmentWeb.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentWeb.Repository.Repositories
{
    public interface IPostRepository
    {
        Task<BlogPostViewModel> GetVM(string slug);
        Task<Post> Get(string slug);
        Task<IEnumerable<BlogPostViewModel>> Search(string tag);
        Task<Post> Create(Post post);
        Task<Post> Update(Post post);
        Task Remove(string slug);
    }
}
