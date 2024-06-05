using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class UsusariosMap : IEntityTypeConfiguration<UsuariosModel>
    {
        public void Configure(EntityTypeBuilder<UsuariosModel> builder)
        {
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.UsuarioNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioTelefone).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioSenha).IsRequired().HasMaxLength(255);
        }
    }
}
