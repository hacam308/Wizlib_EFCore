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
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> builder)
        {
            //many to many relation
            builder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            builder
                .HasOne(b => b.Fluent_Book)
                .WithMany(b => b.Fluent_BookAuthors)
                .HasForeignKey(b => b.Book_Id);
            builder
                .HasOne(b => b.Fluent_Author)
                .WithMany(b => b.Fluent_BookAuthors)
                .HasForeignKey(b => b.Author_Id);
        }
    }
}
