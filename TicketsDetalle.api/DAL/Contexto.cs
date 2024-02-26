using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace TicketsDetalle.api.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<DetalleTickets> DetalleTickets { get; set; }
        public DbSet<Clientes> Clientes { get; set; } = default!;
    }
}