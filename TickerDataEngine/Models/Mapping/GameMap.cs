using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Clock)
                .HasMaxLength(8);

            this.Property(t => t.Header)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Games");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.StatsIncID).HasColumnName("StatsIncID");
            this.Property(t => t.VisitorsID).HasColumnName("VisitorsID");
            this.Property(t => t.HomeID).HasColumnName("HomeID");
            this.Property(t => t.VisitorsScore).HasColumnName("VisitorsScore");
            this.Property(t => t.HomeScore).HasColumnName("HomeScore");
            this.Property(t => t.GameStatusID).HasColumnName("GameStatusID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Clock).HasColumnName("Clock");
            this.Property(t => t.GameDateTime).HasColumnName("GameDateTime");
            this.Property(t => t.BoxScore).HasColumnName("BoxScore");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.ScoreAlertID).HasColumnName("ScoreAlertID");
            this.Property(t => t.LastVisitorsScore).HasColumnName("LastVisitorsScore");
            this.Property(t => t.LastHomeScore).HasColumnName("LastHomeScore");
            this.Property(t => t.DetailsPreScore).HasColumnName("DetailsPreScore");
            this.Property(t => t.DetailsPostScore).HasColumnName("DetailsPostScore");
            this.Property(t => t.StatusIDPreScore).HasColumnName("StatusIDPreScore");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.ScoreDescription).HasColumnName("ScoreDescription");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.BlockData).HasColumnName("BlockData");
            this.Property(t => t.ScoreLastUpdated).HasColumnName("ScoreLastUpdated");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
