using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_log_filesMap : EntityTypeConfiguration<MSmerge_log_files>
    {
        public MSmerge_log_filesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.file_name, t.upload_time, t.log_file_type });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.web_server)
                .HasMaxLength(128);

            this.Property(t => t.file_name)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.log_file_type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_log_files");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.subid).HasColumnName("subid");
            this.Property(t => t.web_server).HasColumnName("web_server");
            this.Property(t => t.file_name).HasColumnName("file_name");
            this.Property(t => t.upload_time).HasColumnName("upload_time");
            this.Property(t => t.log_file_type).HasColumnName("log_file_type");
            this.Property(t => t.log_file).HasColumnName("log_file");
        }
    }
}
