using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HealthForge.AspNetDemo.Models;

namespace code.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20161214112409_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthForge.AspNetDemo.Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.HasKey("ISBN");

                    b.ToTable("Books");
                });
        }
    }
}
