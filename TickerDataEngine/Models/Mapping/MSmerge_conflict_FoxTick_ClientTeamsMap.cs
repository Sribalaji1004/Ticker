using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_ClientTeamsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_ClientTeams>
    {
        public MSmerge_conflict_FoxTick_ClientTeamsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.TeamID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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
            this.ToTable("MSmerge_conflict_FoxTick_ClientTeams");
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
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
