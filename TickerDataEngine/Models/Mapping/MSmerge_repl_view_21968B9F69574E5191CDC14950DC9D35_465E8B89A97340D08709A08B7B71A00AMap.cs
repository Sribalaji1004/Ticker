using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00AMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00A>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00AMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.StatsIncID, t.TeamID, t.StatsIncTeamID, t.FirstName, t.LastName, t.Position, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.StatsIncID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StatsIncTeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Position)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00A");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StatsIncID).HasColumnName("StatsIncID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.StatsIncTeamID).HasColumnName("StatsIncTeamID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
