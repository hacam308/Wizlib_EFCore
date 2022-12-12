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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> builder)
        {
            //bookdetail
            builder.HasKey(bd => bd.BookDetail_Id);
            builder.Property(bd => bd.NumberOfChapters).IsRequired();
        }
    }
}
