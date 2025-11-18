using CapGemini_Assignment.Interface;
using System;
using System.Collections.Generic;

namespace CapGemini_Assignment.Services
{
    public class OccupationService : IOccupationService
    {
        private static readonly Dictionary<string, string> OccupationToRating = new(StringComparer.OrdinalIgnoreCase)
    {
        {"Cleaner","Light Manual"},
        {"Doctor","Professional"},
        {"Author","White Collar"},
        {"Farmer","Heavy Manual"},
        {"Mechanic","Heavy Manual"},
        {"Florist","Light Manual"},
        {"Other","Heavy Manual"}
    };

        private static readonly Dictionary<string, decimal> RatingToFactor = new(StringComparer.OrdinalIgnoreCase)
    {
        {"Professional", 1.5m},
        {"White Collar", 2.25m},
        {"Light Manual", 11.50m},
        {"Heavy Manual", 31.75m}
    };

        public string GetRatingForOccupation(string occupation)
        {
            if (occupation == null) throw new ArgumentNullException(nameof(occupation));
            if (OccupationToRating.TryGetValue(occupation.Trim(), out var rating)) return rating;
            return "Heavy Manual"; // default fallback
        }

        public decimal GetFactorForRating(string rating)
        {
            if (rating == null) throw new ArgumentNullException(nameof(rating));
            if (RatingToFactor.TryGetValue(rating.Trim(), out var factor)) return factor;
            throw new ArgumentException($"Unknown rating '{rating}'");
        }
    }
}
