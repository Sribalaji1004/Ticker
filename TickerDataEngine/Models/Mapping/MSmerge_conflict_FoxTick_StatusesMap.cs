using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_StatusesMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_Statuses>
    {
        public MSmerge_conflict_FoxTick_StatusesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.SportID, t.Description, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SportID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_Statuses");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SportID).HasColumnName("SportID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
