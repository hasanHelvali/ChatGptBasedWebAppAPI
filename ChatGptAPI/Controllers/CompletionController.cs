using ChatGptAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChatGptAPI.Controllers
{
    [Route("api/[controller]")]
    public class CompletionController : ControllerBase
    {
        private readonly OpenAISohbetService openAISohbetService;
        public CompletionController(OpenAISohbetService _openAISohbetService)
        {
            openAISohbetService = _openAISohbetService;
        }

        [HttpPost]
        public async Task<IActionResult> ChatGPTChat([FromBody] string prompt)
        {
            if (prompt == null)
            {
                throw new Exception("Yanlıs bir tip gonderildi.");
            }

            string cevap = await openAISohbetService.basla(prompt);
            var a=JsonSerializer.Serialize(cevap);
            return Ok(a);
        }
    }
}
