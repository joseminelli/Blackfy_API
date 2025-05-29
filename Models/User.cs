using System.ComponentModel.DataAnnotations;

namespace blackfy_API.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não está em um formato válido.")] 
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Phone { get; set; } = string.Empty;
    }
}
