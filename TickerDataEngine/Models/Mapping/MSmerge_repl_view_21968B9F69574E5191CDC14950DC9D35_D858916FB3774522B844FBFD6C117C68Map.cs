using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68Map()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.Username, t.ClientID, t.rowguid });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FirstName)
                .HasMaxLength(20);

            this.Property(t => t.LastName)
                .HasMaxLength(20);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Admin).HasColumnName("Admin");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
