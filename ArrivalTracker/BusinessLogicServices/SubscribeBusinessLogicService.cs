using ArrivalTracker.Data.Dtos.ImportDtos;
using Newtonsoft.Json;

namespace ArrivalTracker.BusinessLogicServices;

public class SubscribeBusinessLogicService : ISubscribeBusinessLogicService
{
    private readonly string _callbackUrl = "https://localhost:44317/api/arrive";
    private readonly string _todayDate = DateTime.Now.ToString("yyyy-MM-dd");
    private readonly HttpClient _httpClient;
    private TokenImportDto _token;

    public SubscribeBusinessLogicService(HttpClient client)
    {
        _httpClient = client;
    }

    public async Task SubscribeToFourthArrivalService()
    {
        string path = $"http://localhost:51396/api/clients/subscribe?date={_todayDate}&callback={_callbackUrl}";
        var responce = await _httpClient.GetAsync(path);
        if (responce == null || !responce.IsSuccessStatusCode)
        {
            var code = responce.StatusCode.ToString() ?? "NULL";
            throw new Exception($"Subscription was not successfull!{code}");
        }

        var json = await responce.Content.ReadAsStringAsync();
        _token = JsonConvert.DeserializeObject<TokenImportDto>(json);
    }

    public string GetToken()
    {
        return _token.Token;
    }
    public DateTime GetTokenExperationDate()
    {
        return _token.Expires;
    }
}
