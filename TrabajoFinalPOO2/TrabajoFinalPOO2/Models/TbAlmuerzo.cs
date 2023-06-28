using System;
using System.Collections.Generic;

namespace TrabajoFinal.Models;

public partial class TbAlmuerzo
{
    public string CodPro { get; set; } = null!;

    public string DesPro { get; set; } = null!;

    public decimal PrePro { get; set; }

    public int StkAct { get; set; }

    public string Img { get; set; } = null!;
}
