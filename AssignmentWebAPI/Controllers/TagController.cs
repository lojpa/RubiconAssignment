using AssignmentWeb.Domain.Interfaces;
using AssignmentWeb.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentWeb.API.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : Controller
    {

        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagViewModel>>> GetTags()
        {
            var tags = await _tagService.GetTags();
            return Ok(tags);
        }
    }
}