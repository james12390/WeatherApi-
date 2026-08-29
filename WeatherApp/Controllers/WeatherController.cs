using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        // 注入 IHttpClientFactory 與 IConfiguration 以讀取 appsettings.json
        public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public IActionResult Weather()
        {
            return View();
        }
        public async Task<IActionResult> getWeather(string city)
        {
            string apiKey = _configuration["OpenWeatherMap:ApiKey"] ?? "YOUR_OPENWEATHERMAP_API_KEY";

            // 2. 建立 API 請求 URL (預設語言設為繁體中文 zh_tw，單位設為公制 metric)
            string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
            string requestUrl = $"{baseUrl}?q={city}&units=metric&lang=zh_tw&appid={apiKey}";

            var client = _httpClientFactory.CreateClient();

            try
            {
                // 3. 發送 GET 請求
                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    // 4. 反序列化 JSON 至 Model
                    var weatherData = await response.Content.ReadFromJsonAsync<OpenWeatherMapResponse>();
                    return View("Weather",weatherData);
                }

                // API 回傳非 200 狀態碼（例如：404 找不到城市、401 Key 無效）
                ViewBag.ErrorMessage = $"找不到「{city}」的天氣資料或 API 密鑰無效（HTTP {response.StatusCode}）。";
                return View("Error");
            }
            catch (HttpRequestException ex)
            {
                // 網路連線錯誤
                ViewBag.ErrorMessage = $"網路請求發生錯誤：{ex.Message}";
                return View("Error");
            }
        }
    }
}
