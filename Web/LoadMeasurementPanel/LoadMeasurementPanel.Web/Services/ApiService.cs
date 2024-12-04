using LoadMeasurementPanel.Web.Services.Interfaces;
using System.Text.Json;
using System.Text;
using LoadMeasurementPanel.Web.Models;

namespace LoadMeasurementPanel.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<ResumoDiarioModel> GetDailySummary(string pointName, string searchDate)
        {
            var response = await _httpClient.GetAsync($"/api/painel/resumo-diario/{pointName}/{searchDate}");
            response.EnsureSuccessStatusCode();
            var summary = await response.Content.ReadFromJsonAsync<EnergyConsumptionPerDay>() ?? new EnergyConsumptionPerDay();

            var result = new ResumoDiarioModel
            {
                ConsumoTotal = summary.TotalConsumption,
                ConsumoMedio = summary.AverageConsumption,
                HorasSemRegistro = summary.HoursWithoutRegistration,
                NomeMedidor = pointName,
                DataDaMedicao = Convert.ToDateTime(searchDate)
            };

            return result;
        }

        public async Task<MedidasDiariaModel> GetDailyMeasures(string pointName, string searchDate)
        {
            var response = await _httpClient.GetAsync($"/api/excel/buscar-registro/{pointName}/{searchDate}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MedidasDiariaModel>() ?? new MedidasDiariaModel();
        }

        public async Task<InfoMedidoresModel> GetPointsInformations()
        {
            var response = await _httpClient.GetAsync($"/api/painel/controle-pontos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<InfoMedidoresModel>() ?? new InfoMedidoresModel();
        }

        public async Task<DetalhesMedidorModel> GetMeasurePointDetailsById(long id)
        {
            var response = await _httpClient.GetAsync($"/api/painel/medidor/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DetalhesMedidorModel>() ?? new DetalhesMedidorModel();
        }

        public async Task<DetalhesMedidorModel> GetMeasurePointDetailsByName(string pointName)
        {
            var response = await _httpClient.GetAsync($"/api/painel/medidor/{pointName}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DetalhesMedidorModel>() ?? new DetalhesMedidorModel();
        }

        public async Task<List<MedidorModel>> GetAllPoints()
        {
            var response = await _httpClient.GetAsync($"/api/painel/medidores");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<MedidorModel>>() ?? new List<MedidorModel>();
        }

        /*
        public async Task<CompleteOrderModel> CreateOrder(OrderModel order)
        {
            var json = JsonSerializer.Serialize(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Pedido/registrar-pedido", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CompleteOrderModel>() ?? new CompleteOrderModel();
        }

        public async Task<bool> UpdateStatus(UpdateStatusModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Pedido/alterar-status", content);

            if (response.IsSuccessStatusCode) { return true; }

            return false;
        }
        */
    }
}
