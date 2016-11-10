using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_TeamsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_Teams>
    {
        public MSmerge_conflict_FoxTick_TeamsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.StatsIncID, t.SportID, t.Abbreviation, t.CityName, t.NickName, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StatsIncID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SportID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NickName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PrimaryColor)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.SecondaryColor)
                .IsFixedLength()
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_Teams");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StatsIncID).HasColumnName("StatsIncID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.PrimaryColor).HasColumnName("PrimaryColor");
            this.Property(t => t.SecondaryColor).HasColumnName("SecondaryColor");
            this.Property(t => t.Ranking).HasColumnName("Ranking");
            this.Property(t => t.Wins).HasColumnName("Wins");
            this.Property(t => t.Loss).HasColumnName("Loss");
            this.Property(t => t.Tie).HasColumnName("Tie");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
