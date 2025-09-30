namespace PadelClubSystem.Entities.Entities
{
    public class Pago
    {

        public int PagoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public decimal Monto { get; set; }
        public string Metodo { get; set; } = "Efectivo"; 

        // Relaciones
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

    }
}
