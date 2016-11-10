using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_replinfoMap : EntityTypeConfiguration<MSmerge_replinfo>
    {
        public MSmerge_replinfoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.repid, t.use_interactive_resolver, t.validation_level, t.resync_gen, t.login_name, t.sync_info });

            // Properties
            this.Property(t => t.validation_level)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.resync_gen)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.login_name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.hostname)
                .HasMaxLength(128);

            this.Property(t => t.merge_jobid)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.sync_info)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("MSmerge_replinfo");
            this.Property(t => t.repid).HasColumnName("repid");
            this.Property(t => t.use_interactive_resolver).HasColumnName("use_interactive_resolver");
            this.Property(t => t.validation_level).HasColumnName("validation_level");
            this.Property(t => t.resync_gen).HasColumnName("resync_gen");
            this.Property(t => t.login_name).HasColumnName("login_name");
            this.Property(t => t.hostname).HasColumnName("hostname");
            this.Property(t => t.merge_jobid).HasColumnName("merge_jobid");
            this.Property(t => t.sync_info).HasColumnName("sync_info");
        }
    }
}
