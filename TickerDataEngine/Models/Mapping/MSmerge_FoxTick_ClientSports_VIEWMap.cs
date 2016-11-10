using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ClientSports_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ClientSports_VIEW>
    {
        public MSmerge_FoxTick_ClientSports_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.SportID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SportID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AltShortDisplay)
                .HasMaxLength(20);

            this.Property(t => t.AltLongDisplay)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_ClientSports_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.AltShortDisplay).HasColumnName("AltShortDisplay");
            this.Property(t => t.AltLongDisplay).HasColumnName("AltLongDisplay");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
