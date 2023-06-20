using System.ComponentModel.DataAnnotations;

namespace FarmFood.ViewModels.PersonalProfile
{
    public class EditingProfileViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string CityOfResidence { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Не указан аккаунт WhatsApp")]
        public string WhatsApp { get; set; }

        [Required(ErrorMessage = "Не указан аккаунт VKontakte")]
        public string VKontakte { get; set; }

        [Required(ErrorMessage = "Не указан аккаунт Telegram")]
        public string Telegram { get; set; }
    }
}
