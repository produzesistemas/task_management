using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    internal class TaskMap : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(512);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Priority).IsRequired().HasMaxLength(5);
            builder.Property(x => x.DueDate).IsRequired();
            builder.Property(x => x.ProjectId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
