using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ClientTeamMap : EntityTypeConfiguration<ClientTeam>
    {
        public ClientTeamMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.AltAbbreviation)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.AltCityName)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.AltNickName)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.AltPrimaryColor)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.AltSecondaryColor)
                .IsFixedLength()
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("ClientTeams");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.AltAbbreviation).HasColumnName("AltAbbreviation");
            this.Property(t => t.AltCityName).HasColumnName("AltCityName");
            this.Property(t => t.AltNickName).HasColumnName("AltNickName");
            this.Property(t => t.AltPrimaryColor).HasColumnName("AltPrimaryColor");
            this.Property(t => t.AltSecondaryColor).HasColumnName("AltSecondaryColor");
            this.Property(t => t.AltRanking).HasColumnName("AltRanking");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
