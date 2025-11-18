using CapGemini_Assignment.Interface;

namespace CapGemini_Assignment.Services
{
    public class PremiumCalculationService : IPremiumCalculationService
    {
        // uses the formula as provided in the brief.
        public decimal CalculateMonthlyPremium(decimal deathSumInsured, decimal factor, int ageNextBirthday)
        {
            // Formula: (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12
            decimal result = (deathSumInsured * factor * ageNextBirthday) / 1000m * 12m;
            return Math.Round(result, 2);
        }
    }

}
