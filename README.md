#ASP NET MVC 串接外部API

使用外部API(OpenWeather API)實作

##步驟一

建立帳號取得API

##步驟二

在appsettings.json 設定API Key 

##步驟三 

利用官方提供的json 建立相對應的model

##步驟四

建立URL

string apiKey = _configuration["OpenWeatherMap:ApiKey"] ?? "YOUR_OPENWEATHERMAP_API_KEY";
string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
string requestUrl = $"{baseUrl}?q={city}&units=metric&lang=zh_tw&appid={apiKey}";

##步驟五

發送 GET 請求
var response = await client.GetAsync(requestUrl);

##步驟六

將拿到的資料反序列化至Model後return View
var weatherData = await response.Content.ReadFromJsonAsync<OpenWeatherMapResponse>();
return View("Weather",weatherData);
