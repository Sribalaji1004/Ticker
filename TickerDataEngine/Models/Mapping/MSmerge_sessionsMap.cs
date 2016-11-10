using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_sessionsMap : EntityTypeConfiguration<MSmerge_sessions>
    {
        public MSmerge_sessionsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.session_id, t.agent_id, t.delivery_time, t.upload_time, t.download_time, t.schema_change_time, t.prepare_snapshot_time, t.delivery_rate, t.time_remaining, t.percent_complete, t.runstatus, t.timestamp });

            // Properties
            this.Property(t => t.session_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.agent_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.delivery_time)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.upload_time)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.download_time)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schema_change_time)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.prepare_snapshot_time)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.delivery_rate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.time_remaining)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.percent_complete)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.runstatus)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.timestamp)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("MSmerge_sessions");
            this.Property(t => t.subid).HasColumnName("subid");
            this.Property(t => t.session_id).HasColumnName("session_id");
            this.Property(t => t.agent_id).HasColumnName("agent_id");
            this.Property(t => t.start_time).HasColumnName("start_time");
            this.Property(t => t.end_time).HasColumnName("end_time");
            this.Property(t => t.duration).HasColumnName("duration");
            this.Property(t => t.delivery_time).HasColumnName("delivery_time");
            this.Property(t => t.upload_time).HasColumnName("upload_time");
            this.Property(t => t.download_time).HasColumnName("download_time");
            this.Property(t => t.schema_change_time).HasColumnName("schema_change_time");
            this.Property(t => t.prepare_snapshot_time).HasColumnName("prepare_snapshot_time");
            this.Property(t => t.delivery_rate).HasColumnName("delivery_rate");
            this.Property(t => t.time_remaining).HasColumnName("time_remaining");
            this.Property(t => t.percent_complete).HasColumnName("percent_complete");
            this.Property(t => t.upload_inserts).HasColumnName("upload_inserts");
            this.Property(t => t.upload_updates).HasColumnName("upload_updates");
            this.Property(t => t.upload_deletes).HasColumnName("upload_deletes");
            this.Property(t => t.upload_conflicts).HasColumnName("upload_conflicts");
            this.Property(t => t.upload_rows_retried).HasColumnName("upload_rows_retried");
            this.Property(t => t.download_inserts).HasColumnName("download_inserts");
            this.Property(t => t.download_updates).HasColumnName("download_updates");
            this.Property(t => t.download_deletes).HasColumnName("download_deletes");
            this.Property(t => t.download_conflicts).HasColumnName("download_conflicts");
            this.Property(t => t.download_rows_retried).HasColumnName("download_rows_retried");
            this.Property(t => t.schema_changes).HasColumnName("schema_changes");
            this.Property(t => t.bulk_inserts).HasColumnName("bulk_inserts");
            this.Property(t => t.metadata_rows_cleanedup).HasColumnName("metadata_rows_cleanedup");
            this.Property(t => t.runstatus).HasColumnName("runstatus");
            this.Property(t => t.estimated_upload_changes).HasColumnName("estimated_upload_changes");
            this.Property(t => t.estimated_download_changes).HasColumnName("estimated_download_changes");
            this.Property(t => t.connection_type).HasColumnName("connection_type");
            this.Property(t => t.timestamp).HasColumnName("timestamp");
            this.Property(t => t.current_phase_id).HasColumnName("current_phase_id");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.spid_login_time).HasColumnName("spid_login_time");
        }
    }
}
