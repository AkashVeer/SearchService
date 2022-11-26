using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchServiceLSM.Service;

namespace SearchServiceLSM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Enter valid search term");
            }

            var result = await searchService.Search(text);
            return Ok(result);
        }
    }
}
