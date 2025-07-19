using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace StudentManager.Controllers
{
    public class AiController : Controller
    {
        private readonly IHttpClientFactory _httpFactory;

        public AiController(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ask(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
                return BadRequest("Please enter a question.");

            var client = _httpFactory.CreateClient("deepseek");

            // Detect if user is asking for explanation
            bool wantsExplanation = new[] { "explain", "how", "why", "what is", "describe", "detail", "step", "process", "example" }
                .Any(keyword => question.ToLower().Contains(keyword));

            var payload = new
            {
                model = "deepseek-r1:1.5b",
                messages = new[]
                {
                    new {
                        role = "system",
                        content = wantsExplanation ?
                            "You are a helpful science tutor. Provide clear, concise explanations when asked. Use bullet points or numbered steps when appropriate." :
                            "You are a precise answer bot. Provide only the exact answer to factual questions without any additional explanation unless specifically requested."
                    },
                    new { role = "user", content = question }
                },
                max_tokens = wantsExplanation ? 500 : 150,
                temperature = wantsExplanation ? 0.7 : 0.3
            };

            var resp = await client.PostAsJsonAsync("v1/chat/completions", payload);
            if (!resp.IsSuccessStatusCode)
            {
                var err = await resp.Content.ReadAsStringAsync();
                return StatusCode(500, $"AI service error: {err}");
            }

            var result = await resp.Content.ReadFromJsonAsync<ChatCompletionResponse>();
            if (result?.choices == null || result.choices.Length == 0)
                return StatusCode(500, "Empty response from AI service");

            var answer = result.choices[0].message.content.Trim();

            // For non-explanation answers, ensure it's concise
            if (!wantsExplanation)
            {
                // Remove any introductory phrases
                answer = Regex.Replace(answer, @"^(?:The answer is|It is|That would be)\s*", "", RegexOptions.IgnoreCase);
                answer = answer.Trim();

                // If answer ends with a period but is short, remove it
                if (answer.Length < 25 && answer.EndsWith("."))
                {
                    answer = answer[..^1];
                }
            }

            return Json(new { answer });
        }

        public class ChatCompletionResponse
        {
            public Choice[] choices { get; set; }
            public class Choice
            {
                public Message message { get; set; }
            }
            public class Message
            {
                public string content { get; set; }
            }
        }
    }
}