using System.ComponentModel.DataAnnotations;

namespace p1_Ap1_RamonUreña.Models;

    public class EntradasHuacales
    {

        [Key]
        public int IdEntrada { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int Precio {  get; set; }
    }

