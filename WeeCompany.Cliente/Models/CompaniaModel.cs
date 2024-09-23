using Dominio;
using System.ComponentModel.DataAnnotations;

namespace WeeCompany.Cliente.Models
{
    public class CompaniaModel
    {
        [Required(ErrorMessage = "El nombre de compañia es obligatorio.")]
        [RegularExpression(@"^[A-Z a-z0-9ÑñáéíóúÁÉÍÓÚ\\-\\_]+$",
            ErrorMessage = "El Nombre de compañia debe ser alfanumérico.")]
        public string NombreCompania { get; set; }

        [Required(ErrorMessage = "El nombre de contacto es obligatorio.")]
        [RegularExpression(@"^[A-Z a-z0-9ÑñáéíóúÁÉÍÓÚ\\-\\_]+$",
            ErrorMessage = "El Nombre de contacto debe ser alfanumérico.")]
        public string NombrePersonaContacto { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(50)]
        public string CorreoElectronico { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(12, ErrorMessage = "El número es demasiado largo")]
        public string Telefono { get; set; }
    }
}
