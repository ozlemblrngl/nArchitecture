using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(b => b.Id);
            builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId");
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.Property(b => b.Price).HasColumnName("Price").IsRequired();
            builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl").IsRequired();
            //builder.HasIndex(indexExpression: b => b.Name, name: "UK_Cources_Name").IsUnique();

            builder.HasOne(c => c.Category)
              .WithMany(ct => ct.Courses)
              .HasForeignKey(c => c.CategoryId);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }

    }
}
