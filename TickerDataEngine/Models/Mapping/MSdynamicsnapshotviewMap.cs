using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSdynamicsnapshotviewMap : EntityTypeConfiguration<MSdynamicsnapshotview>
    {
        public MSdynamicsnapshotviewMap()
        {
            // Primary Key
            this.HasKey(t => t.dynamic_snapshot_view_name);

            // Properties
            this.Property(t => t.dynamic_snapshot_view_name)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("MSdynamicsnapshotviews");
            this.Property(t => t.dynamic_snapshot_view_name).HasColumnName("dynamic_snapshot_view_name");
        }
    }
}
