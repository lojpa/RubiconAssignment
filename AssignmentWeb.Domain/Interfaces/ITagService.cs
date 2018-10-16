using AssignmentWeb.Repository.Models;
using System.Threading.Tasks;

namespace AssignmentWeb.Domain.Interfaces
{
    public interface ITagService
    {
        Task<TagViewModel> GetTags();
    }
}
