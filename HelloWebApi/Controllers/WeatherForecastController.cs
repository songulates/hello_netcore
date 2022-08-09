using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [ApiController]// Controller eylemlerinin bir Http response döneceğini taahhüt eden attribute dur.
    [Route("[controller]s")] //bu endpointe bu kontolerin ismi ile erişilir.
    public class WeatherForecastController : ControllerBase //WeatherForecastController burada resource //controllerbasedan kalıtım alırlar
//classkey wordu ile  WeatherForecastController adında bir sınıf oluşuyo ve ControllerBase adında başka sınıftan kalıtım aLmış
//ControllerBase özelliklerini kendine miras almı(inheritance ve onları kullanıyo)
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;//logger implemente edilmiş mikrosoft ogout yapısınu kullanarak çalışıyo

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")] //attribüte geriye bir liste veya veri önen metod asağısı action metod
    //parametre vermediğimizde
        public IEnumerable<WeatherForecast> Get() //WeatherForecast adında bir liste bir array dönüyo IEnumerable clası ile
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast // WeatherForecast nesnesi oluşturuluyo
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),  
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();//bir liste dönüyo
        }

        [HttpGet("{id}")] //attribüte geriye bir liste veya veri önen metod asağısı action metod
    //api/WeatherForecast/3 route
        public ActionResult<WeatherForecast> GetById(string id) //WeatherForecast adında bir liste bir array dönüyo IEnumerable clası ile
        {
            var rng=new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast // WeatherForecast nesnesi oluşturuluyo
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),  
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray()[0];//bir liste dönüyo
        }

    }
}
