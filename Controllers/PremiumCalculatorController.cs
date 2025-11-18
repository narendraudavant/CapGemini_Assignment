using CapGemini_Assignment.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CapGemini_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PremiumCalculatorController : ControllerBase
    {
     

        private readonly ILogger<PremiumCalculatorController> _logger;

        private readonly IOccupationService _occupationService;
        private readonly IPremiumCalculationService _calcService;

        public PremiumCalculatorController(ILogger<PremiumCalculatorController> logger,IOccupationService occupationService, IPremiumCalculationService calcService)
        {
            _logger = logger;
            _occupationService = occupationService;
            _calcService = calcService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] PremiumRequest request)
        {
            try
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
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
            }
            return BadRequest(ModelState);
        }
    }
}
