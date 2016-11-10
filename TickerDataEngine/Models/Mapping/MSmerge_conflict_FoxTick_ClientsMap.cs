using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_ClientsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_Clients>
    {
        public MSmerge_conflict_FoxTick_ClientsMap()
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
            this.ToTable("MSmerge_conflict_FoxTick_Clients");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LockClient).HasColumnName("LockClient");
            this.Property(t => t.SponsorSync).HasColumnName("SponsorSync");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
