using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96EMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96E>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96EMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ImporterID, t.EntryType, t.Entry, t.EntryDate, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ImporterID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EntryType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Entry)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96E");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ImporterID).HasColumnName("ImporterID");
            this.Property(t => t.EntryType).HasColumnName("EntryType");
            this.Property(t => t.Entry).HasColumnName("Entry");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
