using core8webapp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace core8webapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        public List<accounts> Accounts { get; set; }
        public string error = string.Empty;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async void OnGet()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var response = client.GetAsync(_configuration.GetValue<string>("ApiUrl")).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        Accounts = JsonSerializer.Deserialize<List<accounts>>(responseContent.ReadAsStringAsync().GetAwaiter().GetResult());
                    }
                    else
                    {
                        error = response.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                error = ex.ToString();
            }
        }
    }
}