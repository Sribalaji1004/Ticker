using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_BannersMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_Banners>
    {
        public MSmerge_conflict_FoxTick_BannersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_Banners");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Banner).HasColumnName("Banner");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
