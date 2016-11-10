using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_articlehistoryMap : EntityTypeConfiguration<MSmerge_articlehistory>
    {
        public MSmerge_articlehistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.session_id, t.start_time, t.inserts, t.updates, t.deletes, t.conflicts, t.rows_retried, t.percent_complete, t.relative_cost });

            // Properties
            this.Property(t => t.session_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.article_name)
                .HasMaxLength(128);

            this.Property(t => t.inserts)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.updates)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.deletes)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.conflicts)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.rows_retried)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.percent_complete)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.relative_cost)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_articlehistory");
            this.Property(t => t.session_id).HasColumnName("session_id");
            this.Property(t => t.phase_id).HasColumnName("phase_id");
            this.Property(t => t.article_name).HasColumnName("article_name");
            this.Property(t => t.start_time).HasColumnName("start_time");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.inserts).HasColumnName("inserts");
            this.Property(t => t.updates).HasColumnName("updates");
            this.Property(t => t.deletes).HasColumnName("deletes");
            this.Property(t => t.conflicts).HasColumnName("conflicts");
            this.Property(t => t.rows_retried).HasColumnName("rows_retried");
            this.Property(t => t.percent_complete).HasColumnName("percent_complete");
            this.Property(t => t.estimated_changes).HasColumnName("estimated_changes");
            this.Property(t => t.relative_cost).HasColumnName("relative_cost");
        }
    }
}
