using System.ComponentModel.DataAnnotations;

namespace p1_Ap1_RamonUreña.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId {  get; set; }


    public string? TipoColor { get; set; }

    public string? TipoTamano { get; set; }

    public int Existencia {  get; set; }
}
