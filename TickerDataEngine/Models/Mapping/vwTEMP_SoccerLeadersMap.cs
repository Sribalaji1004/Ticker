using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class vwTEMP_SoccerLeadersMap : EntityTypeConfiguration<vwTEMP_SoccerLeaders>
    {
        public vwTEMP_SoccerLeadersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Name, t.LastUpdated });

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

            // Table & Column Mappings
            this.ToTable("vwTEMP_SoccerLeaders");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.OnAirName).HasColumnName("OnAirName");
            this.Property(t => t.CreatedName).HasColumnName("CreatedName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.Editable).HasColumnName("Editable");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
        }
    }
}
