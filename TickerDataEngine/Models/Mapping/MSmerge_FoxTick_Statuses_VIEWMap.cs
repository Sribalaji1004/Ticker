using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_Statuses_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_Statuses_VIEW>
    {
        public MSmerge_FoxTick_Statuses_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.SportID, t.Description, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SportID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_Statuses_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
