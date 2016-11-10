using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ManagementGameMap : EntityTypeConfiguration<ManagementGame>
    {
        public ManagementGameMap()
        {
            // Primary Key
            this.HasKey(t => t.GameID);

            // Properties
            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Clock)
                .IsFixedLength()
                .HasMaxLength(18);

            // Table & Column Mappings
            this.ToTable("ManagementGames");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.GameStatusID).HasColumnName("GameStatusID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Clock).HasColumnName("Clock");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.HomeScore).HasColumnName("HomeScore");
            this.Property(t => t.VisitorsScore).HasColumnName("VisitorsScore");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
