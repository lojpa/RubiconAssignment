using AssignmentWeb.Repository.Context;
using AssignmentWeb.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentWeb.Repository.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly RubiconContext _context;

        public TagRepository(RubiconContext context)
        {
            _context = context;
        }

        public async Task<TagViewModel> GetAllTags()
        {
            var tags = await _context.Tags.ToListAsync();

            TagViewModel model = new TagViewModel()
            {
                Tags = new List<string>()
            };
            

            model.Tags = tags.Select(x => x.TagId).ToList();
            
            return model;
        }
    }
}
