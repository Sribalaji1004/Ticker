using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ClientSportMap : EntityTypeConfiguration<ClientSport>
    {
        public ClientSportMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AltShortDisplay)
                .HasMaxLength(20);

            this.Property(t => t.AltLongDisplay)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ClientSports");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.AltShortDisplay).HasColumnName("AltShortDisplay");
            this.Property(t => t.AltLongDisplay).HasColumnName("AltLongDisplay");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
