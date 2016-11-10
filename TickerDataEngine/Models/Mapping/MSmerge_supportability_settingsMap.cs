using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_supportability_settingsMap : EntityTypeConfiguration<MSmerge_supportability_settings>
    {
        public MSmerge_supportability_settingsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.support_options, t.log_severity, t.log_modules, t.log_file_size, t.no_of_log_files, t.upload_interval, t.delete_after_upload });

            // Properties
            this.Property(t => t.web_server)
                .HasMaxLength(128);

            this.Property(t => t.support_options)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.log_severity)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.log_modules)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.log_file_path)
                .HasMaxLength(255);

            this.Property(t => t.log_file_name)
                .HasMaxLength(128);

            this.Property(t => t.log_file_size)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.no_of_log_files)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.upload_interval)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.delete_after_upload)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.custom_script)
                .HasMaxLength(2048);

            this.Property(t => t.message_pattern)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("MSmerge_supportability_settings");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.subid).HasColumnName("subid");
            this.Property(t => t.web_server).HasColumnName("web_server");
            this.Property(t => t.support_options).HasColumnName("support_options");
            this.Property(t => t.log_severity).HasColumnName("log_severity");
            this.Property(t => t.log_modules).HasColumnName("log_modules");
            this.Property(t => t.log_file_path).HasColumnName("log_file_path");
            this.Property(t => t.log_file_name).HasColumnName("log_file_name");
            this.Property(t => t.log_file_size).HasColumnName("log_file_size");
            this.Property(t => t.no_of_log_files).HasColumnName("no_of_log_files");
            this.Property(t => t.upload_interval).HasColumnName("upload_interval");
            this.Property(t => t.delete_after_upload).HasColumnName("delete_after_upload");
            this.Property(t => t.custom_script).HasColumnName("custom_script");
            this.Property(t => t.message_pattern).HasColumnName("message_pattern");
            this.Property(t => t.last_log_upload_time).HasColumnName("last_log_upload_time");
            this.Property(t => t.agent_xe).HasColumnName("agent_xe");
            this.Property(t => t.agent_xe_ring_buffer).HasColumnName("agent_xe_ring_buffer");
            this.Property(t => t.sql_xe).HasColumnName("sql_xe");
        }
    }
}
