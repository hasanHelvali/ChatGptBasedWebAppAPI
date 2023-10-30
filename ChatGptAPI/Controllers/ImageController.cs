using ChatGptAPI.Model;
using ChatGptAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptAPI.Controllers
{
    [Route("api/image")]
    public class ImageController : ControllerBase
    {
        private readonly OpenAIImageService openAIIMageService;
        public ImageController (OpenAIImageService _openAIIMageService)
        {
            openAIIMageService = _openAIIMageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody] Image image)
            {
            if (!ModelState.IsValid)
            {
                throw new Exception("Yanlıs bir tip gonderildi.");
            }
            List<string> a = await openAIIMageService.basla(image);
            return Ok(a);
        }
    }
}
