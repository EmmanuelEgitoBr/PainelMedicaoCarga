using LoadMeasurementPanel.Worker.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using LoadMeasurementPanel.Worker.Models.MeasureModels;

namespace LoadMeasurementPanel.Worker.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<string> RecordExcelData(IEnumerable<DailyEnergy> measures)
        {
            var json = JsonSerializer.Serialize(measures);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/ExcelFile/gravar-dados", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<string>() ?? "";
        }
    }
}
