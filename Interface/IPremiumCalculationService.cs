namespace CapGemini_Assignment.Interface
{
    public interface IPremiumCalculationService
    {
        decimal CalculateMonthlyPremium(decimal deathSumInsured, decimal factor, int ageNextBirthday);
    }

}
