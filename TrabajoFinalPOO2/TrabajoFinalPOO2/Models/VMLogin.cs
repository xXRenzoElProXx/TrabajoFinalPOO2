using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal.Models
{
    public class VMLogin
    {
        [Required(ErrorMessage = "Necesita poner el Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Necesita poner la Contraseña")]
        public string PassWord { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}