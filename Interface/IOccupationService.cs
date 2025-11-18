namespace CapGemini_Assignment.Interface
{
    public interface IOccupationService
    {
        string GetRatingForOccupation(string occupation);
        decimal GetFactorForRating(string rating);
    }

}
