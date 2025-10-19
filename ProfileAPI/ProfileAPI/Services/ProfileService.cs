using ProfileAPI.DTOs;
using ProfileAPI.Interfaces;
using System.Text.Json;

namespace ProfileAPI.Services
{
   
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProfileDto> GetProfileAsync()
        {
            string catFact = "Could not fetch cat fact at the moment.";
            try
            {
                var response = await _httpClient.GetAsync("https://catfact.ninja/fact", HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();
                    using var doc = await JsonDocument.ParseAsync(stream);
                    catFact = doc.RootElement.GetProperty("fact").GetString() ?? catFact;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cat fact: {ex.Message}");
            }

            return new ProfileDto
            {
                Status = "success",
                User = new UserDto
                {
                    Email = "your_email@example.com",
                    Name = "Your Full Name",
                    Stack = "C# / .NET Web API"
                },
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Fact = catFact
            };
        }
    }

}
