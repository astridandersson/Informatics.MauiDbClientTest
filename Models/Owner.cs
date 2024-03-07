 using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;

namespace Informatics.MauiDbClientTest.Models;

[Table("Owner")]
public class Owner
{
    [Key]
    [Column("OwnerId")]
    [MaxLength(40)]
    public string OwnerId { get; set; }

    [Column("OwnerName")]
    [MaxLength(40)]
    public string OwnerName { get; set; }

    [Column("OwnerPhoneNumber")]
    [MaxLength(40)]
    public string OwnerPhoneNumber { get; set; }
  
     [Column("OwnerEmail")]
    [MaxLength(40)]
     public string OwnerEmail { get; set; }

    [Column("OwnerAddress")]
    [MaxLength(40)]
    public string OwnerAddress { get; set; }
   
 
    // Navigation property for the related rows in the Pet table
    public virtual ICollection<Pet> Pets { get; set; }

}
