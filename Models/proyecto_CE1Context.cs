using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class proyecto_CE1Context : DbContext
    {
        public proyecto_CE1Context()
        {
        }

        public proyecto_CE1Context(DbContextOptions<proyecto_CE1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bodega> Bodega { get; set; }
        public virtual DbSet<BodegaProducto> BodegaProducto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cobro> Cobro { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<CotizacionCompra> CotizacionCompra { get; set; }
        public virtual DbSet<CotizacionDetalleCompra> CotizacionDetalleCompra { get; set; }
        public virtual DbSet<CotizacionDetalleVenta> CotizacionDetalleVenta { get; set; }
        public virtual DbSet<CotizacionVenta> CotizacionVenta { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Despacho> Despacho { get; set; }
        public virtual DbSet<Devolucion> Devolucion { get; set; }
        public virtual DbSet<DevolucionManual> DevolucionManual { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EmpleadoSucursal> EmpleadoSucursal { get; set; }
        public virtual DbSet<EnvioVenta> EnvioVenta { get; set; }
        public virtual DbSet<FacturaCompra> FacturaCompra { get; set; }
        public virtual DbSet<FacturaDetalleCompra> FacturaDetalleCompra { get; set; }
        public virtual DbSet<FacturaDetalleVenta> FacturaDetalleVenta { get; set; }
        public virtual DbSet<FacturaVenta> FacturaVenta { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<InventarioBodegaProducto> InventarioBodegaProducto { get; set; }
        public virtual DbSet<InventarioIngresoManual> InventarioIngresoManual { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<PagoCompra> PagoCompra { get; set; }
        public virtual DbSet<PagoPlanilla> PagoPlanilla { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<SueldoEmpleado> SueldoEmpleado { get; set; }
        public virtual DbSet<SueldoVendedor> SueldoVendedor { get; set; }
        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<TiendaSucursal> TiendaSucursal { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<TipoConsumo> TipoConsumo { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<TransporteEntrega> TransporteEntrega { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=proyecto_CE1;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.IdBodega)
                    .HasName("PK__Bodega__3C609E4520C8E853");

                entity.Property(e => e.IdBodega).HasColumnName("ID_Bodega");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BodegaProducto>(entity =>
            {
                entity.HasKey(e => e.IdBodegaProducto)
                    .HasName("PK__Bodega_P__CD2111E49B11530A");

                entity.ToTable("Bodega_Producto");

                entity.Property(e => e.IdBodegaProducto).HasColumnName("ID_Bodega_Producto");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estanteria)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Habitacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdBodega).HasColumnName("ID_Bodega");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.NivelEstanteria)
                    .HasColumnName("Nivel_Estanteria")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoEdificio).HasColumnName("NO_Edificio");

                entity.Property(e => e.PosicionEstanteria)
                    .HasColumnName("Posicion_Estanteria")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.BodegaProducto)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bodega_Pr__ID_Bo__07C12930");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.BodegaProducto)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bodega_Pr__ID_Pr__08B54D69");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__E005FBFF44B33809");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionEntrega)
                    .IsRequired()
                    .HasColumnName("Direccion_Entrega")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionFactura)
                    .IsRequired()
                    .HasColumnName("Direccion_Factura")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdTipoCliente).HasColumnName("ID_Tipo_Cliente");

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoClienteNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .HasConstraintName("FK__Cliente__ID_Tipo__25869641");
            });

            modelBuilder.Entity<Cobro>(entity =>
            {
                entity.HasKey(e => e.IdCobro)
                    .HasName("PK__Cobro__61FB2F9E66033706");

                entity.Property(e => e.IdCobro).HasColumnName("ID_Cobro");

                entity.Property(e => e.Correlativo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdFactura).HasColumnName("ID_Factura");

                entity.Property(e => e.IdTipoPago).HasColumnName("ID_Tipo_Pago");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Cobro)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cobro__ID_Factur__47DBAE45");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Cobro)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cobro__ID_Tipo_P__48CFD27E");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RutaFotoEmpleado)
                    .HasColumnName("Ruta_Foto_Empleado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RutaFotoProducto)
                    .HasColumnName("Ruta_Foto_Producto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCambioDolar).HasColumnName("Tipo_Cambio_Dolar");

                entity.Property(e => e.TipoCambioPesosMexicanos).HasColumnName("Tipo_Cambio_Pesos_Mexicanos");
            });

            modelBuilder.Entity<CotizacionCompra>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionCompra)
                    .HasName("PK__Cotizaci__797D277DEEE25FFD");

                entity.ToTable("Cotizacion_Compra");

                entity.Property(e => e.IdCotizacionCompra).HasColumnName("ID_Cotizacion_Compra");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCotizacion)
                    .HasColumnName("Fecha_Cotizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.CotizacionCompra)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Pr__59063A47");
            });

            modelBuilder.Entity<CotizacionDetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionDetalleCompra)
                    .HasName("PK__Cotizaci__28C78C747C6AABB8");

                entity.ToTable("Cotizacion_Detalle_Compra");

                entity.Property(e => e.IdCotizacionDetalleCompra).HasColumnName("ID_Cotizacion_Detalle_Compra");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdCotizacionCompra).HasColumnName("ID_Cotizacion_Compra");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.IdTipoConsumo).HasColumnName("ID_Tipo_Consumo");

                entity.HasOne(d => d.IdCotizacionCompraNavigation)
                    .WithMany(p => p.CotizacionDetalleCompra)
                    .HasForeignKey(d => d.IdCotizacionCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Co__5DCAEF64");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CotizacionDetalleCompra)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Cotizacio__ID_Pr__5FB337D6");

                entity.HasOne(d => d.IdTipoConsumoNavigation)
                    .WithMany(p => p.CotizacionDetalleCompra)
                    .HasForeignKey(d => d.IdTipoConsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Ti__5EBF139D");
            });

            modelBuilder.Entity<CotizacionDetalleVenta>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionDetalleVenta)
                    .HasName("PK__Cotizaci__DC1FAC9AF62818C7");

                entity.ToTable("Cotizacion_Detalle_Venta");

                entity.Property(e => e.IdCotizacionDetalleVenta).HasColumnName("ID_Cotizacion_Detalle_Venta");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdCotizacionVenta).HasColumnName("ID_Cotizacion_Venta");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("Precio_Unitario");

                entity.HasOne(d => d.IdCotizacionVentaNavigation)
                    .WithMany(p => p.CotizacionDetalleVenta)
                    .HasForeignKey(d => d.IdCotizacionVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Co__5535A963");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CotizacionDetalleVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Pr__5629CD9C");
            });

            modelBuilder.Entity<CotizacionVenta>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionVenta)
                    .HasName("PK__Cotizaci__E5AFD99C86994AC9");

                entity.ToTable("Cotizacion_Venta");

                entity.Property(e => e.IdCotizacionVenta).HasColumnName("ID_Cotizacion_Venta");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EstadoCotizacion)
                    .IsRequired()
                    .HasColumnName("Estado_Cotizacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CotizacionVenta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Cl__37A5467C");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.CotizacionVenta)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__ID_Ve__36B12243");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__249DEFBE193A4359");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_Departamento");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Despacho>(entity =>
            {
                entity.HasKey(e => e.IdDespacho)
                    .HasName("PK__Despacho__FA7B253DB01F812B");

                entity.Property(e => e.IdDespacho).HasColumnName("ID_Despacho");

                entity.Property(e => e.DiaSalida)
                    .HasColumnName("Dia_Salida")
                    .HasColumnType("date");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

                entity.Property(e => e.IdFactura).HasColumnName("ID_Factura");

                entity.Property(e => e.LugarDespacho)
                    .IsRequired()
                    .HasColumnName("Lugar_Despacho")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Despacho)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Despacho__ID_Fac__4316F928");
            });

            modelBuilder.Entity<Devolucion>(entity =>
            {
                entity.HasKey(e => e.IdDevolucion)
                    .HasName("PK__Devoluci__E8BAC41E8EA25B52");

                entity.Property(e => e.IdDevolucion).HasColumnName("ID_Devolucion");

                entity.Property(e => e.DescargarInventario)
                    .IsRequired()
                    .HasColumnName("Descargar_Inventario")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdFacturaCompra).HasColumnName("ID_Factura_Compra");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFacturaCompraNavigation)
                    .WithMany(p => p.Devolucion)
                    .HasForeignKey(d => d.IdFacturaCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devolucio__ID_Fa__778AC167");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Devolucion)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devolucio__ID_Pr__787EE5A0");
            });

            modelBuilder.Entity<DevolucionManual>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionManual)
                    .HasName("PK__Devoluci__4E4BF29108E92EB7");

                entity.ToTable("Devolucion_Manual");

                entity.Property(e => e.IdDevolucionManual).HasColumnName("ID_Devolucion_Manual");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdDevolucion).HasColumnName("ID_Devolucion");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDevolucionNavigation)
                    .WithMany(p => p.DevolucionManual)
                    .HasForeignKey(d => d.IdDevolucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devolucio__ID_De__7B5B524B");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DevolucionManual)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devolucio__ID_Pr__7C4F7684");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__B7872C90D8596A09");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEmpleado)
                    .IsRequired()
                    .HasColumnName("Codigo_Empleado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("Correo_Electronico")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_Nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Foto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Igss)
                    .HasColumnName("IGSS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Licencia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoLicencia)
                    .HasColumnName("NO_Licencia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelefono)
                    .HasColumnName("NO_Telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SueldoDevengado).HasColumnName("Sueldo_Devengado");

                entity.Property(e => e.TipoLicencia)
                    .HasColumnName("Tipo_Licencia")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TituloAlcanzado)
                    .HasColumnName("Titulo_Alcanzado")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpleadoSucursal>(entity =>
            {
                entity.HasKey(e => e.IdEmpleadoSucursal)
                    .HasName("PK__Empleado__B4554C8368D69293");

                entity.ToTable("Empleado_Sucursal");

                entity.Property(e => e.IdEmpleadoSucursal).HasColumnName("ID_Empleado_Sucursal");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_Departamento");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.Property(e => e.IdTiendaSucursal).HasColumnName("ID_Tienda_Sucursal");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.EmpleadoSucursal)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado___ID_De__17F790F9");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EmpleadoSucursal)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado___ID_Em__17036CC0");

                entity.HasOne(d => d.IdTiendaSucursalNavigation)
                    .WithMany(p => p.EmpleadoSucursal)
                    .HasForeignKey(d => d.IdTiendaSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado___ID_Ti__160F4887");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.EmpleadoSucursal)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado___ID_Ve__18EBB532");
            });

            modelBuilder.Entity<EnvioVenta>(entity =>
            {
                entity.HasKey(e => e.IdEnvioVenta)
                    .HasName("PK__Envio_Ve__0A5B5C065D4E6E8A");

                entity.ToTable("Envio_Venta");

                entity.Property(e => e.IdEnvioVenta).HasColumnName("ID_Envio_Venta");

                entity.Property(e => e.ContactoRecibir)
                    .IsRequired()
                    .HasColumnName("Contacto_Recibir")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DiaEntrega)
                    .HasColumnName("Dia_Entrega")
                    .HasColumnType("date");

                entity.Property(e => e.DiaSalida)
                    .HasColumnName("Dia_Salida")
                    .HasColumnType("date");

                entity.Property(e => e.DireccionEntrega)
                    .IsRequired()
                    .HasColumnName("Direccion_Entrega")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.HoraEntrega).HasColumnName("Hora_Entrega");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

                entity.Property(e => e.IdDespacho).HasColumnName("ID_Despacho");

                entity.Property(e => e.IdTransporteEntrega).HasColumnName("ID_Transporte_Entrega");

                entity.Property(e => e.TipoEnvio)
                    .IsRequired()
                    .HasColumnName("Tipo_Envio")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDespachoNavigation)
                    .WithMany(p => p.EnvioVenta)
                    .HasForeignKey(d => d.IdDespacho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Envio_Ven__ID_De__5165187F");

                entity.HasOne(d => d.IdTransporteEntregaNavigation)
                    .WithMany(p => p.EnvioVenta)
                    .HasForeignKey(d => d.IdTransporteEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Envio_Ven__ID_Tr__52593CB8");
            });

            modelBuilder.Entity<FacturaCompra>(entity =>
            {
                entity.HasKey(e => e.IdFacturaCompra)
                    .HasName("PK__Factura___F3E65D8DB42BEB45");

                entity.ToTable("Factura_Compra");

                entity.Property(e => e.IdFacturaCompra).HasColumnName("ID_Factura_Compra");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdCotizacionCompra).HasColumnName("ID_Cotizacion_Compra");

                entity.Property(e => e.IdDevolucion).HasColumnName("ID_Devolucion");

                entity.Property(e => e.NoFactura).HasColumnName("NO_Factura");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCotizacionCompraNavigation)
                    .WithMany(p => p.FacturaCompra)
                    .HasForeignKey(d => d.IdCotizacionCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_C__ID_Co__628FA481");
            });

            modelBuilder.Entity<FacturaDetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalleCompra)
                    .HasName("PK__Factura___B08C6FEBD194F9C0");

                entity.ToTable("Factura_Detalle_Compra");

                entity.Property(e => e.IdFacturaDetalleCompra).HasColumnName("ID_Factura_Detalle_Compra");

                entity.Property(e => e.CargarInventario)
                    .IsRequired()
                    .HasColumnName("Cargar_Inventario")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdFactura).HasColumnName("ID_Factura");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.IdTipoConsumo).HasColumnName("ID_Tipo_Consumo");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturaDetalleCompra)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_D__ID_Fa__656C112C");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.FacturaDetalleCompra)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_D__ID_Pr__6754599E");

                entity.HasOne(d => d.IdTipoConsumoNavigation)
                    .WithMany(p => p.FacturaDetalleCompra)
                    .HasForeignKey(d => d.IdTipoConsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_D__ID_Ti__66603565");
            });

            modelBuilder.Entity<FacturaDetalleVenta>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalleVenta)
                    .HasName("PK__Factura___9E8ACA94DEC0F06A");

                entity.ToTable("Factura_Detalle_Venta");

                entity.Property(e => e.IdFacturaDetalleVenta).HasColumnName("ID_Factura_Detalle_Venta");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_Factura_Venta");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("Precio_Unitario");

                entity.HasOne(d => d.IdFacturaVentaNavigation)
                    .WithMany(p => p.FacturaDetalleVenta)
                    .HasForeignKey(d => d.IdFacturaVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_D__ID_Fa__3F466844");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.FacturaDetalleVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_D__ID_Pr__403A8C7D");
            });

            modelBuilder.Entity<FacturaVenta>(entity =>
            {
                entity.HasKey(e => e.IdFacturaVenta)
                    .HasName("PK__Factura___5FF041B143E31853");

                entity.ToTable("Factura_Venta");

                entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_Factura_Venta");

                entity.Property(e => e.Correlativo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionEntrega)
                    .IsRequired()
                    .HasColumnName("Direccion_Entrega")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionFactura)
                    .IsRequired()
                    .HasColumnName("Direccion_Factura")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdCotizacionVenta).HasColumnName("ID_Cotizacion_Venta");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.NitCliente)
                    .IsRequired()
                    .HasColumnName("NIT_Cliente")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.FacturaVenta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_V__ID_Cl__3C69FB99");

                entity.HasOne(d => d.IdCotizacionVentaNavigation)
                    .WithMany(p => p.FacturaVenta)
                    .HasForeignKey(d => d.IdCotizacionVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_V__ID_Co__3A81B327");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.FacturaVenta)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura_V__ID_Ve__3B75D760");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK__Inventar__4FF10151A8B33D84");

                entity.Property(e => e.IdInventario).HasColumnName("ID_Inventario");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaConteo)
                    .HasColumnName("Fecha_Conteo")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.HoraConteo).HasColumnName("Hora_Conteo");

                entity.Property(e => e.IdEmpleadoEncargado).HasColumnName("ID_Empleado_Encargado");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoEncargadoNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdEmpleadoEncargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventari__ID_Em__7F2BE32F");
            });

            modelBuilder.Entity<InventarioBodegaProducto>(entity =>
            {
                entity.HasKey(e => e.IdInventarioBodegaProducto)
                    .HasName("PK__Inventar__E229209DEA648E86");

                entity.ToTable("Inventario_Bodega_Producto");

                entity.Property(e => e.IdInventarioBodegaProducto).HasColumnName("ID_Inventario_Bodega_Producto");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdBodegaProducto).HasColumnName("ID_Bodega_Producto");

                entity.Property(e => e.IdInventario).HasColumnName("ID_Inventario");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SinCambio)
                    .IsRequired()
                    .HasColumnName("Sin_Cambio")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdBodegaProductoNavigation)
                    .WithMany(p => p.InventarioBodegaProducto)
                    .HasForeignKey(d => d.IdBodegaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventari__ID_Bo__0B91BA14");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.InventarioBodegaProducto)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventari__ID_In__0C85DE4D");
            });

            modelBuilder.Entity<InventarioIngresoManual>(entity =>
            {
                entity.HasKey(e => e.IdInventarioIngresoManual)
                    .HasName("PK__Inventar__D4F7C9E365B53B30");

                entity.ToTable("Inventario_Ingreso_Manual");

                entity.Property(e => e.IdInventarioIngresoManual).HasColumnName("ID_Inventario_Ingreso_Manual");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("date");

                entity.Property(e => e.HoraIngreso).HasColumnName("Hora_Ingreso");

                entity.Property(e => e.IdEmpleadoAutorizado).HasColumnName("ID_Empleado_Autorizado");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.MotivoCarga)
                    .IsRequired()
                    .HasColumnName("Motivo_Carga")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoAutorizadoNavigation)
                    .WithMany(p => p.InventarioIngresoManual)
                    .HasForeignKey(d => d.IdEmpleadoAutorizado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventari__ID_Em__02FC7413");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioIngresoManual)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventari__ID_Pr__02084FDA");
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOferta)
                    .HasName("PK__Oferta__DA7701066670143B");

                entity.Property(e => e.IdOferta).HasColumnName("ID_Oferta");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("Fecha_Final")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_Inicio")
                    .HasColumnType("date");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.IdTipoCliente).HasColumnName("ID_Tipo_Cliente");

                entity.Property(e => e.PorcentajeDescuento).HasColumnName("Porcentaje_Descuento");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Oferta__ID_Produ__1CBC4616");

                entity.HasOne(d => d.IdTipoClienteNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Oferta__ID_Tipo___1DB06A4F");
            });

            modelBuilder.Entity<PagoCompra>(entity =>
            {
                entity.HasKey(e => e.IdPagoCompra)
                    .HasName("PK__Pago_Com__C5EFF3E2945F4043");

                entity.ToTable("Pago_Compra");

                entity.Property(e => e.IdPagoCompra).HasColumnName("ID_Pago_Compra");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPago)
                    .HasColumnName("Fecha_Pago")
                    .HasColumnType("date");

                entity.Property(e => e.IdFacturaCompra).HasColumnName("ID_Factura_Compra");

                entity.Property(e => e.IdTipoPago).HasColumnName("ID_Tipo_Pago");

                entity.HasOne(d => d.IdFacturaCompraNavigation)
                    .WithMany(p => p.PagoCompra)
                    .HasForeignKey(d => d.IdFacturaCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago_Comp__ID_Fa__73BA3083");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.PagoCompra)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago_Comp__ID_Ti__74AE54BC");
            });

            modelBuilder.Entity<PagoPlanilla>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago_Pla__AE88B42965E3DD83");

                entity.ToTable("Pago_Planilla");

                entity.Property(e => e.IdPago).HasColumnName("ID_Pago");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPago)
                    .HasColumnName("Fecha_Pago")
                    .HasColumnType("date");

                entity.Property(e => e.IdSueldoEmpleado).HasColumnName("ID_Sueldo_Empleado");

                entity.Property(e => e.IdSueldoVendedor).HasColumnName("ID_Sueldo_Vendedor");

                entity.Property(e => e.TipoPagoPlanilla)
                    .IsRequired()
                    .HasColumnName("Tipo_Pago_Planilla")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TotalSueldoEmpleado).HasColumnName("Total_Sueldo_Empleado");

                entity.Property(e => e.TotalSueldoVendedor).HasColumnName("Total_Sueldo_Vendedor");

                entity.HasOne(d => d.IdSueldoEmpleadoNavigation)
                    .WithMany(p => p.PagoPlanilla)
                    .HasForeignKey(d => d.IdSueldoEmpleado)
                    .HasConstraintName("FK__Pago_Plan__ID_Su__6FE99F9F");

                entity.HasOne(d => d.IdSueldoVendedorNavigation)
                    .WithMany(p => p.PagoPlanilla)
                    .HasForeignKey(d => d.IdSueldoVendedor)
                    .HasConstraintName("FK__Pago_Plan__ID_Su__70DDC3D8");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__9B4120E20328AC12");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FotoProducto)
                    .HasColumnName("Foto_Producto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");

                entity.Property(e => e.IdTipoClienteA).HasColumnName("ID_Tipo_Cliente_A");

                entity.Property(e => e.IdTipoClienteB).HasColumnName("ID_Tipo_Cliente_B");

                entity.Property(e => e.IdTipoClienteC).HasColumnName("ID_Tipo_Cliente_C");

                entity.Property(e => e.IdTipoClienteD).HasColumnName("ID_Tipo_Cliente_D");

                entity.Property(e => e.IdTipoClienteE).HasColumnName("ID_Tipo_Cliente_E");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioClienteA).HasColumnName("Precio_Cliente_A");

                entity.Property(e => e.PrecioClienteB).HasColumnName("Precio_Cliente_B");

                entity.Property(e => e.PrecioClienteC).HasColumnName("Precio_Cliente_C");

                entity.Property(e => e.PrecioClienteD).HasColumnName("Precio_Cliente_D");

                entity.Property(e => e.PrecioClienteE).HasColumnName("Precio_Cliente_E");

                entity.Property(e => e.PrecioCompra).HasColumnName("Precio_Compra");

                entity.Property(e => e.PrecioVentaPublicoGeneral).HasColumnName("Precio_Venta_Publico_General");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__ID_Pro__2F10007B");

                entity.HasOne(d => d.IdTipoClienteANavigation)
                    .WithMany(p => p.ProductoIdTipoClienteANavigation)
                    .HasForeignKey(d => d.IdTipoClienteA)
                    .HasConstraintName("FK__Producto__ID_Tip__2A4B4B5E");

                entity.HasOne(d => d.IdTipoClienteBNavigation)
                    .WithMany(p => p.ProductoIdTipoClienteBNavigation)
                    .HasForeignKey(d => d.IdTipoClienteB)
                    .HasConstraintName("FK__Producto__ID_Tip__2B3F6F97");

                entity.HasOne(d => d.IdTipoClienteCNavigation)
                    .WithMany(p => p.ProductoIdTipoClienteCNavigation)
                    .HasForeignKey(d => d.IdTipoClienteC)
                    .HasConstraintName("FK__Producto__ID_Tip__2C3393D0");

                entity.HasOne(d => d.IdTipoClienteDNavigation)
                    .WithMany(p => p.ProductoIdTipoClienteDNavigation)
                    .HasForeignKey(d => d.IdTipoClienteD)
                    .HasConstraintName("FK__Producto__ID_Tip__2D27B809");

                entity.HasOne(d => d.IdTipoClienteENavigation)
                    .WithMany(p => p.ProductoIdTipoClienteENavigation)
                    .HasForeignKey(d => d.IdTipoClienteE)
                    .HasConstraintName("FK__Producto__ID_Tip__2E1BDC42");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__7D65272FB6BBF278");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");

                entity.Property(e => e.ClasificacionProveedor)
                    .IsRequired()
                    .HasColumnName("Clasificacion_Proveedor")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("Correo_Electronico")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DespachoLocal)
                    .IsRequired()
                    .HasColumnName("Despacho_Local")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Envio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContacto)
                    .IsRequired()
                    .HasColumnName("Nombre_Contacto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("Razon_Social")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SueldoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdSueldoEmpleado)
                    .HasName("PK__Sueldo_E__0240B50B5FBD89F2");

                entity.ToTable("Sueldo_Empleado");

                entity.Property(e => e.IdSueldoEmpleado).HasColumnName("ID_Sueldo_Empleado");

                entity.Property(e => e.Anio).HasColumnType("date");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.Property(e => e.Mes).HasColumnType("date");

                entity.Property(e => e.TotalPago).HasColumnName("Total_Pago");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.SueldoEmpleado)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sueldo_Em__ID_Em__6A30C649");
            });

            modelBuilder.Entity<SueldoVendedor>(entity =>
            {
                entity.HasKey(e => e.IdSueldoVendedor)
                    .HasName("PK__Sueldo_V__166D6424158B7B8C");

                entity.ToTable("Sueldo_Vendedor");

                entity.Property(e => e.IdSueldoVendedor).HasColumnName("ID_Sueldo_Vendedor");

                entity.Property(e => e.Anio).HasColumnType("date");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");

                entity.Property(e => e.Mes).HasColumnType("date");

                entity.Property(e => e.TotalComision).HasColumnName("Total_Comision");

                entity.Property(e => e.TotalPago).HasColumnName("Total_Pago");

                entity.Property(e => e.TotalVenta).HasColumnName("Total_Venta");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.SueldoVendedor)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sueldo_Ve__ID_Ve__6D0D32F4");
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PK__Tienda__91024DF403D35C77");

                entity.Property(e => e.IdTienda).HasColumnName("ID_Tienda");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("Correo_Electronico")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasColumnName("Razon_Social")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiendaSucursal>(entity =>
            {
                entity.HasKey(e => e.IdTiendaSucursal)
                    .HasName("PK__Tienda_S__1F961E9C8B57542E");

                entity.ToTable("Tienda_Sucursal");

                entity.Property(e => e.IdTiendaSucursal).HasColumnName("ID_Tienda_Sucursal");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEmpleadoEncargado).HasColumnName("ID_Empleado_Encargado");

                entity.Property(e => e.IdTienda).HasColumnName("ID_Tienda");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.TiendaSucursal)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tienda_Su__ID_Ti__1332DBDC");
            });

            modelBuilder.Entity<TipoCliente>(entity =>
            {
                entity.HasKey(e => e.IdTipoCliente)
                    .HasName("PK__Tipo_Cli__5BFB0D4BB6F3AE3D");

                entity.ToTable("Tipo_Cliente");

                entity.Property(e => e.IdTipoCliente).HasColumnName("ID_Tipo_Cliente");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoConsumo>(entity =>
            {
                entity.HasKey(e => e.IdTipoConsumo)
                    .HasName("PK__Tipo_Con__3833FD91A106528A");

                entity.ToTable("Tipo_Consumo");

                entity.Property(e => e.IdTipoConsumo).HasColumnName("ID_Tipo_Consumo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoPago)
                    .HasName("PK__Tipo_Pag__4792A1BE1E7CB0DE");

                entity.ToTable("Tipo_Pago");

                entity.Property(e => e.IdTipoPago).HasColumnName("ID_Tipo_Pago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransporteEntrega>(entity =>
            {
                entity.HasKey(e => e.IdTransporteEntrega)
                    .HasName("PK__Transpor__0227D5348C6FE6A1");

                entity.ToTable("Transporte_Entrega");

                entity.Property(e => e.IdTransporteEntrega).HasColumnName("ID_Transporte_Entrega");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegreso)
                    .HasColumnName("Fecha_Regreso")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("Fecha_Salida")
                    .HasColumnType("date");

                entity.Property(e => e.HoraRegreso).HasColumnName("Hora_Regreso");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

                entity.Property(e => e.IdConductor).HasColumnName("ID_Conductor");

                entity.Property(e => e.IdVehiculo).HasColumnName("ID_Vehiculo");

                entity.Property(e => e.KilometrajeEntrada).HasColumnName("Kilometraje_Entrada");

                entity.Property(e => e.KilometrajeSalida).HasColumnName("Kilometraje_Salida");

                entity.HasOne(d => d.IdConductorNavigation)
                    .WithMany(p => p.TransporteEntrega)
                    .HasForeignKey(d => d.IdConductor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transport__ID_Co__4E88ABD4");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.TransporteEntrega)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transport__ID_Ve__4D94879B");
            });

            modelBuilder.Entity<Vehiculos>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__FEFD7E333C53D0FF");

                entity.Property(e => e.IdVehiculo).HasColumnName("ID_Vehiculo");

                entity.Property(e => e.Chasis)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.Linea)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uso)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor)
                    .HasName("PK__Vendedor__2B2A0A45FCFA0175");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComisionVenta).HasColumnName("Comision_Venta");

                entity.Property(e => e.Especializacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("Fecha_Actualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vendedor__ID_Emp__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
