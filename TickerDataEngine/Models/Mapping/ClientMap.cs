using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Abbreviation)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.SponsorSync)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Clients");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LockClient).HasColumnName("LockClient");
            this.Property(t => t.SponsorSync).HasColumnName("SponsorSync");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
