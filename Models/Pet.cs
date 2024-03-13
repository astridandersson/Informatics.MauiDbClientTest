using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Informatics.MauiDbClientTest.Models
{
    [Table("Pet")]
    public class Pet
    {
        [Key]
        [Column("PetId")]
        [MaxLength(40)]
        public string? PetId { get; set; }

        [Column("PetName")]
        [MaxLength(40)]
        public string? PetName { get; set; }

        [Column("PetBreed")]
        [MaxLength(40)]
        public string? PetBreed { get; set; }

        [Column("PetAge")]
        public int PetAge { get; set; }

        [Column("OwnerId")]
        [MaxLength(40)]
        [ForeignKey("Owner")]
        public string? OwnerId { get; set; }

        // Navigation property for the related row in the Owner table
        public virtual Owner? Owner { get; set; }
    }
}
