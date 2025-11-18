using System;
using System.ComponentModel.DataAnnotations;

namespace CapGemini_Assignment
{
    public class PremiumRequest
    {
        //public DateOnly Date { get; set; }

        //public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string? Summary { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 150)]
        public int AgeNextBirthday { get; set; }

        // mm/YYYY
        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "Date of Birth must be in mm/YYYY format")]
        public string DateOfBirth { get; set; }

        [Required]
        public string UsualOccupation { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Sum Insured must be > 0")]
        public decimal DeathSumInsured { get; set; }
    }



}
