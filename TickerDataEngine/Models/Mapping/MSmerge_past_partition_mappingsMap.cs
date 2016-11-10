using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_past_partition_mappingsMap : EntityTypeConfiguration<MSmerge_past_partition_mappings>
    {
        public MSmerge_past_partition_mappingsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.publication_number, t.tablenick, t.rowguid, t.partition_id, t.reason });

            // Properties
            this.Property(t => t.publication_number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tablenick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.partition_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_past_partition_mappings");
            this.Property(t => t.publication_number).HasColumnName("publication_number");
            this.Property(t => t.tablenick).HasColumnName("tablenick");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.partition_id).HasColumnName("partition_id");
            this.Property(t => t.generation).HasColumnName("generation");
            this.Property(t => t.reason).HasColumnName("reason");
        }
    }
}
