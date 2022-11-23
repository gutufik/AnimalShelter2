using System.ComponentModel.DataAnnotations;

namespace AnimalShelterWeb.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Логин")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage="Минимальная длина имени - 3 символа"), MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Минимальная длина фамилии - 3 символа"), MinLength(3)]
        public string LastName { get; set; }
    }
}
