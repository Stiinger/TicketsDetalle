using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }
    [Required(ErrorMessage = "Debe ingresar una fecha.")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Today;
    [ForeignKey("Clientes")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string SolicitadoPor { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Asunto { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Descripcion { get; set; } = string.Empty;

    [ForeignKey("Tickets")]
    public ICollection<DetalleTickets> TicketsDetalle { get; set; } = new List<DetalleTickets>();
}