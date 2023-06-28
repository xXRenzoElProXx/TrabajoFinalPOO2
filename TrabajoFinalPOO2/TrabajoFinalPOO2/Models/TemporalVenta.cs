namespace TrabajoFinal.Models
{
    public class TemporalVenta
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public bool vacio { get; set; }
        public double total { get; set; }
        public double total_pagar { get; set; }
    }
}