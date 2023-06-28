using System;
using System.Collections.Generic;

namespace TrabajoFinal.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Correo { get; set; }
    public string? Clave { get; set; }
    public string? Imagen { get; set; }
}