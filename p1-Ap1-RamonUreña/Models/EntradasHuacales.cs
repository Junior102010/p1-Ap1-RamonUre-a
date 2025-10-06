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
    [Range(1, int.MaxValue, ErrorMessage = "El Valor Minimo es 1")]
    public int Cantidad { get; set; }
        [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El Valor Minimo es 1")]
        public double Precio {  get; set; }
    }

