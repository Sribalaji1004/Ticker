using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.StatusID, t.AltDescription, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StatusID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AltDescription)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.AltDescription).HasColumnName("AltDescription");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
