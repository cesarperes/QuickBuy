using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades.ObjetoDeValor;

namespace QuickBuy.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(u => u.Id);
            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
