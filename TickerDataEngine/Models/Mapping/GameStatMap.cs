using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class GameStatMap : EntityTypeConfiguration<GameStat>
    {
        public GameStatMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.StatName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.StatValue)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("GameStats");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.StatName).HasColumnName("StatName");
            this.Property(t => t.StatValue).HasColumnName("StatValue");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
