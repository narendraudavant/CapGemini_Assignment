using CapGemini_Assignment.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CapGemini_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<PremiumRequest> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new PremiumRequest
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        private readonly IOccupationService _occupationService;
        private readonly IPremiumCalculationService _calcService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IOccupationService occupationService, IPremiumCalculationService calcService)
        {
            _logger = logger;
            _occupationService = occupationService;
            _calcService = calcService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] PremiumRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var rating = _occupationService.GetRatingForOccupation(request.UsualOccupation);
            var factor = _occupationService.GetFactorForRating(rating);

            var premium = _calcService.CalculateMonthlyPremium(request.DeathSumInsured, factor, request.AgeNextBirthday);

            var response = new
            {
                name = request.Name,
                ageNextBirthday = request.AgeNextBirthday,
                dateOfBirth = request.DateOfBirth,
                occupation = request.UsualOccupation,
                occupationRating = rating,
                occupationFactor = factor,
                deathSumInsured = request.DeathSumInsured,
                monthlyPremium = premium
            };

            return Ok(response);
        }
    }
}
