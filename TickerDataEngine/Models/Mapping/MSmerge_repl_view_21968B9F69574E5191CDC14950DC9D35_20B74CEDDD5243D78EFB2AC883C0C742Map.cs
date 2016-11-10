using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Name, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.Locked).HasColumnName("Locked");
            this.Property(t => t.Staged).HasColumnName("Staged");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
