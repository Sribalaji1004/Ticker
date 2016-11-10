using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_Users_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_Users_VIEW>
    {
        public MSmerge_FoxTick_Users_VIEWMap()
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
            this.ToTable("MSmerge_FoxTick_Users_VIEW");
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
