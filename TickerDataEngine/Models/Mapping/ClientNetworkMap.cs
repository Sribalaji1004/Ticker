using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ClientNetworkMap : EntityTypeConfiguration<ClientNetwork>
    {
        public ClientNetworkMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ClientNetworks");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.NetworkID).HasColumnName("NetworkID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
