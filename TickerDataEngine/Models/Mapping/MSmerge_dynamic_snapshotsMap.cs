using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_dynamic_snapshotsMap : EntityTypeConfiguration<MSmerge_dynamic_snapshots>
    {
        public MSmerge_dynamic_snapshotsMap()
        {
            // Primary Key
            this.HasKey(t => t.partition_id);

            // Properties
            this.Property(t => t.partition_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dynamic_snapshot_location)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MSmerge_dynamic_snapshots");
            this.Property(t => t.partition_id).HasColumnName("partition_id");
            this.Property(t => t.dynamic_snapshot_location).HasColumnName("dynamic_snapshot_location");
            this.Property(t => t.last_updated).HasColumnName("last_updated");
            this.Property(t => t.last_started).HasColumnName("last_started");

            // Relationships
            this.HasRequired(t => t.MSmerge_partition_groups)
                .WithOptional(t => t.MSmerge_dynamic_snapshots);

        }
    }
}
