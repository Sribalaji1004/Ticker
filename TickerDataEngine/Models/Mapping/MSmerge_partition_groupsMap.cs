using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_partition_groupsMap : EntityTypeConfiguration<MSmerge_partition_groups>
    {
        public MSmerge_partition_groupsMap()
        {
            // Primary Key
            this.HasKey(t => t.partition_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MSmerge_partition_groups");
            this.Property(t => t.partition_id).HasColumnName("partition_id");
            this.Property(t => t.publication_number).HasColumnName("publication_number");
            this.Property(t => t.maxgen_whenadded).HasColumnName("maxgen_whenadded");
            this.Property(t => t.using_partition_groups).HasColumnName("using_partition_groups");
            this.Property(t => t.is_partition_active).HasColumnName("is_partition_active");
        }
    }
}
