using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentWeb.Domain.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetBlogs(string tag);
    
    }
}
