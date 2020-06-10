using System.ComponentModel.DataAnnotations;

namespace PersonalLogger.Models.AccountModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }
}