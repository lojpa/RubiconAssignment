using AssignmentWeb.Repository.Models;
using System.Threading.Tasks;

namespace AssignmentWeb.Repository.Repositories
{
    public interface ITagRepository
    {
        Task<TagViewModel> GetAllTags();
    }
}
