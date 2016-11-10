using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
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
            this.ToTable("Teams");
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
        }
    }
}
