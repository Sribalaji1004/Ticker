using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Name, t.GroupAnimationTypeID, t.LastUpdated, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            this.Property(t => t.CreatedName)
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.Header)
                .HasMaxLength(50);

            this.Property(t => t.GroupAnimationTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.OnAirName).HasColumnName("OnAirName");
            this.Property(t => t.CreatedName).HasColumnName("CreatedName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.GroupAnimationTypeID).HasColumnName("GroupAnimationTypeID");
            this.Property(t => t.Editable).HasColumnName("Editable");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
