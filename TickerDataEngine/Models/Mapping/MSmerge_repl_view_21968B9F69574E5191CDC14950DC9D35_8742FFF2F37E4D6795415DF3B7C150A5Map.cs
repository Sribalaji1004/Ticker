using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.SportID, t.Description, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SportID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
