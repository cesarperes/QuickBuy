using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(u => u.Id);
            builder
                .Property(u => u.DataPedido)
                .IsRequired();
            builder
                .Property(u => u.DataPrevisaoEntrega)
                .IsRequired();
            builder
                .Property(u => u.Cep)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(u => u.Estado)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Cidade)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(u => u.EnderecoCompleto)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(u => u.NumeroEndereco)
                .IsRequired()
                .HasMaxLength(100);



        }
    }
}
