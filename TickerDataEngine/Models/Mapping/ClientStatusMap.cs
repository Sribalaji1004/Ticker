using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ClientStatusMap : EntityTypeConfiguration<ClientStatus>
    {
        public ClientStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AltDescription)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("ClientStatuses");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.AltDescription).HasColumnName("AltDescription");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
