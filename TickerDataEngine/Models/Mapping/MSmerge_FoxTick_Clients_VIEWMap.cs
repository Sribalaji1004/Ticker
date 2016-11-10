using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_Clients_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_Clients_VIEW>
    {
        public MSmerge_FoxTick_Clients_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.rowguid });

            // Properties
            this.Property(t => t.Abbreviation)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.SponsorSync)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_Clients_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LockClient).HasColumnName("LockClient");
            this.Property(t => t.SponsorSync).HasColumnName("SponsorSync");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
