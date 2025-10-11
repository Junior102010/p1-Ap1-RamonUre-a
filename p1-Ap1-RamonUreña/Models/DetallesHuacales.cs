using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p1_Ap1_RamonUreña.Models;

public class DetallesHuacales
{
    [Key]
    public int DetalleId { get; set; }

    public int TiposId { get; set; }

    public int Cantidad {  get; set; }

    public double Precio {  get; set; }

    public int IdEntrada { get; set; }


}
