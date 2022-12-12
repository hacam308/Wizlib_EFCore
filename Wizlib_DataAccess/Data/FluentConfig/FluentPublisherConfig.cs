using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Wizlib_Model.Models;

namespace Wizlib_DataAccess.Data.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> builder)
        {
            //publisher
            builder.HasKey(b => b.Publisher_Id);
            builder.Property(b => b.Location).IsRequired();
            builder.Property(b => b.Name).IsRequired();
        }
    }
}
