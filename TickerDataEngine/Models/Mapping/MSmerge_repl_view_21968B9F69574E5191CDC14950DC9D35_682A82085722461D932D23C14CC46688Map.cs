using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Client, t.EntryType, t.Entry, t.EntryDate, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Client)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.EntryType)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Entry)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Client).HasColumnName("Client");
            this.Property(t => t.EntryType).HasColumnName("EntryType");
            this.Property(t => t.Entry).HasColumnName("Entry");
            this.Property(t => t.Temperature).HasColumnName("Temperature");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
