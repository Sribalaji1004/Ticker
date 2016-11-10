using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSdynamicsnapshotjobMap : EntityTypeConfiguration<MSdynamicsnapshotjob>
    {
        public MSdynamicsnapshotjobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.name, t.pubid, t.job_id, t.agent_id, t.dynamic_snapshot_location, t.partition_id, t.computed_dynsnap_location });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.agent_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dynamic_filter_login)
                .HasMaxLength(128);

            this.Property(t => t.dynamic_filter_hostname)
                .HasMaxLength(128);

            this.Property(t => t.dynamic_snapshot_location)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.partition_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSdynamicsnapshotjobs");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.job_id).HasColumnName("job_id");
            this.Property(t => t.agent_id).HasColumnName("agent_id");
            this.Property(t => t.dynamic_filter_login).HasColumnName("dynamic_filter_login");
            this.Property(t => t.dynamic_filter_hostname).HasColumnName("dynamic_filter_hostname");
            this.Property(t => t.dynamic_snapshot_location).HasColumnName("dynamic_snapshot_location");
            this.Property(t => t.partition_id).HasColumnName("partition_id");
            this.Property(t => t.computed_dynsnap_location).HasColumnName("computed_dynsnap_location");
        }
    }
}
