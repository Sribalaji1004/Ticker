using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class AlertMap : EntityTypeConfiguration<Alert>
    {
        public AlertMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Alert1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Alerts");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.AlertID).HasColumnName("AlertID");
            this.Property(t => t.AlertTimeStamp).HasColumnName("AlertTimeStamp");
            this.Property(t => t.Alert1).HasColumnName("Alert");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
