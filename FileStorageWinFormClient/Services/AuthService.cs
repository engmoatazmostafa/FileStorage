using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FileStorageWinFormClient.Models;
using Newtonsoft.Json;

namespace FileStorageWinFormClient.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private string _baseUrl;

        public AuthService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            // Prepare login data (adjust based on your API requirements)
            var loginData = new { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                // Define the API endpoint for login
                string loginEndpoint = $"{_baseUrl}/api/users/authenticate";

                try
                {
                    // Send POST request with login data
                    var response = client. (loginEndpoint, content);

                    // Check for successful response
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        // Parse the response to extract the login token (adjust based on API response format)
                        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        string token = responseObject?.token;  // Assuming "token" is the key holding the login token

                        return token;
                    }
                    else
                    {
                        throw new Exception($"Error logging in: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                     throw new Exception($"Error: {ex.Message}");
                }
            }
        }
    }
}
