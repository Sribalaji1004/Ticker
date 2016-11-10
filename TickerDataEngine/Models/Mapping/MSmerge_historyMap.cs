using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_historyMap : EntityTypeConfiguration<MSmerge_history>
    {
        public MSmerge_historyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.agent_id, t.comments, t.error_id, t.timestamp, t.updateable_row, t.time });

            // Properties
            this.Property(t => t.agent_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.comments)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.error_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.timestamp)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("MSmerge_history");
            this.Property(t => t.session_id).HasColumnName("session_id");
            this.Property(t => t.agent_id).HasColumnName("agent_id");
            this.Property(t => t.comments).HasColumnName("comments");
            this.Property(t => t.error_id).HasColumnName("error_id");
            this.Property(t => t.timestamp).HasColumnName("timestamp");
            this.Property(t => t.updateable_row).HasColumnName("updateable_row");
            this.Property(t => t.time).HasColumnName("time");
        }
    }
}
