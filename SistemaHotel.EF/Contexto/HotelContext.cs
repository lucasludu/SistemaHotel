using Microsoft.EntityFrameworkCore;
using SistemaHotel.Entidades.Models;

namespace SistemaHotel.EF.Contexto
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<EstadoHabitacion> EstadoHabitacions { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitacions { get; set; } = null!;
        public virtual DbSet<Piso> Pisos { get; set; } = null!;
        public virtual DbSet<Recepcion> Recepcions { get; set; } = null!;
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-T2I28GR\\SQLEXPRESS;Initial Catalog=SistemaHotel;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10BF82E812");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466423AA0EE4D");

                entity.ToTable("Cliente");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoHabitacion>(entity =>
            {
                entity.HasKey(e => e.IdEstadoHabitacion)
                    .HasName("PK__EstadoHa__EBF610CE1421AB06");

                entity.ToTable("EstadoHabitacion");

                entity.Property(e => e.IdEstadoHabitacion).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PK__Habitaci__8BBBF9016E0871B7");

                entity.ToTable("Habitacion");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Habitacions)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Habitacio__IdCat__5070F446");

                entity.HasOne(d => d.IdEstadoHabitacionNavigation)
                    .WithMany(p => p.Habitacions)
                    .HasForeignKey(d => d.IdEstadoHabitacion)
                    .HasConstraintName("FK__Habitacio__IdEst__4E88ABD4");

                entity.HasOne(d => d.IdPisoNavigation)
                    .WithMany(p => p.Habitacions)
                    .HasForeignKey(d => d.IdPiso)
                    .HasConstraintName("FK__Habitacio__IdPis__4F7CD00D");
            });

            modelBuilder.Entity<Piso>(entity =>
            {
                entity.HasKey(e => e.IdPiso)
                    .HasName("PK__Piso__F2823D8A3ABC0170");

                entity.ToTable("Piso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Recepcion>(entity =>
            {
                entity.HasKey(e => e.IdRecepcion)
                    .HasName("PK__Recepcio__83F935CAB7D28588");

                entity.ToTable("Recepcion");

                entity.Property(e => e.Adelanto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CostoPenalidad)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");

                entity.Property(e => e.FechaSalidaConfirmacion).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioInicial).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioRestante).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalPagado)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Recepcions)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Recepcion__IdCli__5535A963");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Recepcions)
                    .HasForeignKey(d => d.IdHabitacion)
                    .HasConstraintName("FK__Recepcion__IdHab__5629CD9C");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.HasKey(e => e.IdRolUsuario)
                    .HasName("PK__RolUsuar__3FC7F91FFE97243C");

                entity.ToTable("RolUsuario");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF9720D7569A");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRolUsuario)
                    .HasConstraintName("FK__Usuario__IdRolUs__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
