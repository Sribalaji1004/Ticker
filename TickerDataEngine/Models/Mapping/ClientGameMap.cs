using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ClientGameMap : EntityTypeConfiguration<ClientGame>
    {
        public ClientGameMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClientGames");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.AltSortOrder).HasColumnName("AltSortOrder");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
