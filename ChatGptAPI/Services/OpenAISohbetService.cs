using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace ChatGptAPI.Services
{
    public class OpenAISohbetService
    {
        private readonly IOpenAIService openAIService;
        public OpenAISohbetService(IOpenAIService _openAIService)
        {
            openAIService = _openAIService;
        }

         string cevap = "";

        public async Task<string> basla(string prompt)
        {

            CompletionCreateResponse sonuc = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt,
                MaxTokens = 1000,
            }, Models.TextDavinciV3);
            cevap = sonuc.Choices[0].Text;//ize ilk gelen sonucu seciyoruz.
            return cevap;

        }
    }
}
