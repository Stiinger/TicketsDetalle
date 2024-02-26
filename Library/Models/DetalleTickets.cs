using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class DetalleTickets
{
    [Key]
    public int DetalleId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int TicketId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Emisor { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Mensaje { get; set; } = string.Empty;
}