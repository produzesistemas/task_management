
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;
internal class TaskHistoryMap : IEntityTypeConfiguration<TaskHistory>
{
    public void Configure(EntityTypeBuilder<TaskHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(512);
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.TaskId).IsRequired();
        builder.Property(x => x.CreateDate).IsRequired();
        builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.NoAction);

    }
}
