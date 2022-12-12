using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Wizlib_Model.Models;

namespace Wizlib_DataAccess.Data.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> builder)
        {
            //book
            builder.HasKey(b => b.Book_Id);
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            //one to one relation between book and bokdetail
            builder
                .HasOne(b => b.Fluent_BookDetail)
                .WithOne(b => b.Fluent_Book)
                .HasForeignKey<Fluent_Book>("BookDetail_Id");
            builder
                .HasOne(b => b.Fluent_Publisher)
                .WithMany(b => b.Fluent_Books)
                .HasForeignKey(b => b.Publisher_Id);
        }
    }
}
