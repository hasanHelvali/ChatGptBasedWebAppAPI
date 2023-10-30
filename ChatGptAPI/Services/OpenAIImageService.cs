using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using ChatGptAPI.Model;
using Microsoft.AspNetCore.Mvc;


namespace ChatGptAPI.Services
{
    public class OpenAIImageService
    {
        private readonly IOpenAIService openAIService;

        public OpenAIImageService(IOpenAIService _openAIService)
        {
            openAIService = _openAIService;
        }
        

        public async Task<List<string>> basla(Image image )
        {
            ImageCreateResponse sonuc = await openAIService.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = image.Prompt,
                N = image.Piece,
                Size = Sizeable(image.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "test"
            }); ;

            var a = sonuc.Results.Select(r => r.Url).ToList();
            return a;

        }
        private string Sizeable(int size)
        {
            var boyut = size switch
            {
                256 => StaticValues.ImageStatics.Size.Size256,
                512 => StaticValues.ImageStatics.Size.Size512,
                1024 => StaticValues.ImageStatics.Size.Size1024,
                _ => StaticValues.ImageStatics.Size.Size256
            };
            return boyut;
        }
    }
}
