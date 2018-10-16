using AssignmentWeb.Domain.Interfaces;
using AssignmentWeb.Repository.Models;
using AssignmentWeb.Repository.Repositories;
using System.Threading.Tasks;

namespace AssignmentWeb.Domain.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagViewModel> GetTags()
        {
            var tags = await _tagRepository.GetAllTags();
            return tags;
        }
    }
}
