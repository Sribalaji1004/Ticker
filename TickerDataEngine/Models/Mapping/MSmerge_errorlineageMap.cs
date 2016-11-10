using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_errorlineageMap : EntityTypeConfiguration<MSmerge_errorlineage>
    {
        public MSmerge_errorlineageMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tablenick, t.rowguid });

            // Properties
            this.Property(t => t.tablenick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lineage)
                .HasMaxLength(311);

            // Table & Column Mappings
            this.ToTable("MSmerge_errorlineage");
            this.Property(t => t.tablenick).HasColumnName("tablenick");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.lineage).HasColumnName("lineage");
        }
    }
}
