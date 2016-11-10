using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Name, t.RunDay, t.RunHour, t.RunMinute, t.Force, t.LastRun, t.LastSuccess, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RunDay)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.RunHour)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RunMinute)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LastFileDate)
                .HasMaxLength(20);

            this.Property(t => t.LastMessage)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RunDay).HasColumnName("RunDay");
            this.Property(t => t.RunHour).HasColumnName("RunHour");
            this.Property(t => t.RunMinute).HasColumnName("RunMinute");
            this.Property(t => t.Force).HasColumnName("Force");
            this.Property(t => t.LastRun).HasColumnName("LastRun");
            this.Property(t => t.LastFileDate).HasColumnName("LastFileDate");
            this.Property(t => t.LastSuccess).HasColumnName("LastSuccess");
            this.Property(t => t.LastMessage).HasColumnName("LastMessage");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
