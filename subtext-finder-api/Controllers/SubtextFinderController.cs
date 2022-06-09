using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using subtext_finder_lib;

namespace subtext_finder_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtextFinderController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetIndexesOfMatchedSubtext(string text, string subtext) {
            if (text == null || subtext == null) {
                return BadRequest();
            }

            return Ok(SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext));
        }
    }
}
