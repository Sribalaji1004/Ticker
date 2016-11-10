using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_GameStatuses_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_GameStatuses_VIEW>
    {
        public MSmerge_FoxTick_GameStatuses_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Description, t.rowguid });

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_GameStatuses_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
