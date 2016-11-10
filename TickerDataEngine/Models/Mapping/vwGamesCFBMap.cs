using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class vwGamesCFBMap : EntityTypeConfiguration<vwGamesCFB>
    {
        public vwGamesCFBMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.VisitorsID, t.HomeID, t.VisitorsAbbreviation, t.HomeAbbreviation, t.VisitorsNickName, t.HomeNickName, t.VisitorsScore, t.HomeScore, t.Clock, t.Status, t.LastUpdated, t.VisitorWins, t.VisitorLoss, t.VisitorTie, t.HomeWins, t.HomeLoss, t.HomeTie });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Matchup)
                .HasMaxLength(23);

            this.Property(t => t.VisitorsID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VisitorsAbbreviation)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.HomeAbbreviation)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.VisitorsCityName)
                .HasMaxLength(50);

            this.Property(t => t.HomeCityName)
                .HasMaxLength(50);

            this.Property(t => t.VisitorsNickName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.HomeNickName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.VisitorsCity)
                .HasMaxLength(50);

            this.Property(t => t.HomeCity)
                .HasMaxLength(50);

            this.Property(t => t.VisitorsScore)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeScore)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Clock)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(18);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.VisitorWins)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VisitorLoss)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.VisitorTie)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeWins)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeLoss)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeTie)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwGamesCFB");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Matchup).HasColumnName("Matchup");
            this.Property(t => t.VisitorsID).HasColumnName("VisitorsID");
            this.Property(t => t.HomeID).HasColumnName("HomeID");
            this.Property(t => t.VisitorsRanking).HasColumnName("VisitorsRanking");
            this.Property(t => t.HomeRanking).HasColumnName("HomeRanking");
            this.Property(t => t.VisitorsAbbreviation).HasColumnName("VisitorsAbbreviation");
            this.Property(t => t.HomeAbbreviation).HasColumnName("HomeAbbreviation");
            this.Property(t => t.VisitorsCityName).HasColumnName("VisitorsCityName");
            this.Property(t => t.HomeCityName).HasColumnName("HomeCityName");
            this.Property(t => t.VisitorsNickName).HasColumnName("VisitorsNickName");
            this.Property(t => t.HomeNickName).HasColumnName("HomeNickName");
            this.Property(t => t.VisitorsCity).HasColumnName("VisitorsCity");
            this.Property(t => t.HomeCity).HasColumnName("HomeCity");
            this.Property(t => t.VisitorsScore).HasColumnName("VisitorsScore");
            this.Property(t => t.HomeScore).HasColumnName("HomeScore");
            this.Property(t => t.Clock).HasColumnName("Clock");
            this.Property(t => t.GameStatusID).HasColumnName("GameStatusID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.GameDateTime).HasColumnName("GameDateTime");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.VisitorWins).HasColumnName("VisitorWins");
            this.Property(t => t.VisitorLoss).HasColumnName("VisitorLoss");
            this.Property(t => t.VisitorTie).HasColumnName("VisitorTie");
            this.Property(t => t.HomeWins).HasColumnName("HomeWins");
            this.Property(t => t.HomeLoss).HasColumnName("HomeLoss");
            this.Property(t => t.HomeTie).HasColumnName("HomeTie");
        }
    }
}
